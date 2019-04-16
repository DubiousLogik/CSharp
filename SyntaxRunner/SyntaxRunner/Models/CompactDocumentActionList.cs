using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace SyntaxRunner.Models
{
    public class CompactDocumentActionList
    {
        [JsonProperty("referenceDate")]
        public DateTime ReferenceDate { get; private set; }

        [JsonProperty("documentList")]
        public Dictionary<string, int> DocumentList { get; private set; }

        [JsonProperty("maxAgeInDays")]
        public int MaxAgeInDays { get; private set; }

        [JsonProperty("maxDocumentCount")]
        public int MaxDocumentCount { get; private set; }

        public CompactDocumentActionList(
            int maxAgeInDays,
            int maxDocumentCount,
            Dictionary<string, int> documentList = null, 
            DateTime? referenceDateOverride = null)
        {
            this.MaxAgeInDays = maxAgeInDays;
            this.MaxDocumentCount = maxDocumentCount;

            if (documentList != null && documentList.Any())
            {
                this.DocumentList = new Dictionary<string, int>(documentList, StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                this.DocumentList = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            }

            DateTime referenceDate;

            if (referenceDateOverride != null && referenceDateOverride.GetValueOrDefault() < DateTime.UtcNow)
            {
                referenceDate = referenceDateOverride.GetValueOrDefault();
            }
            else
            {
                referenceDate = DateTime.UtcNow;
            }

            this.ReferenceDate = referenceDate.Date;
        }

        public void AddItem(string documentId)
        {
            this.UpdateReferenceDate();
            this.DocumentList[documentId] = 0;
        }

        public void UpdateReferenceDate()
        {
            var newReferenceDate = new DateTime(
                year: DateTime.UtcNow.Year,
                month: DateTime.UtcNow.Month,
                day: DateTime.UtcNow.Day);

            int offset = (newReferenceDate - this.ReferenceDate).Days;

            if (this.DocumentList.Any())
            {
                foreach (var key in this.DocumentList.Keys.ToArray())
                {
                    int ageInDays = offset + this.DocumentList[key];

                    if (ageInDays >= MaxAgeInDays)
                    {
                        this.DocumentList.Remove(key);
                    }
                    else
                    {
                        this.DocumentList[key] = ageInDays;
                    }
                }
            }

            this.ReferenceDate = newReferenceDate;
        }
    }
}
