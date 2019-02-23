using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxRunner.Models
{
    public class DocumentReferenceList
    {
        private const int MaxAgeInDays = 30;

        public DateTime ReferenceDate { get; private set; }

        public ConcurrentDictionary<string, int> DocumentList { get; private set; }

        public DocumentReferenceList(DateTime referenceDate, Dictionary<string, int> documentList)
        {
            this.ReferenceDate = new DateTime(
                year: referenceDate.Year,
                month: referenceDate.Month,
                day: referenceDate.Day);

            this.DocumentList = new ConcurrentDictionary<string, int>(documentList);
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

            if (this.DocumentList != null && this.DocumentList.Any())
            {
                foreach (var kvp in this.DocumentList)
                {
                    int ageInDays = (newReferenceDate - this.ReferenceDate).Days + kvp.Value;

                    if (ageInDays > MaxAgeInDays)
                    {
                        int returnedValue;
                        bool removedOk =this.DocumentList.TryRemove(kvp.Key, out returnedValue);
                    }
                    else
                    {
                        this.DocumentList[kvp.Key] = ageInDays;
                    }
                }
            }

            this.ReferenceDate = newReferenceDate;
        }
    }
}
