using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.ProductCatalog;
using Newtonsoft.Json;

namespace MovingData.Json.Models
{
    public class ProductJson
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("unitCost")]
        public decimal UnitCost { get; set; }

        [JsonProperty("unitOfMeasure")]
        public UnitOfMeasure UoM { get; set; }

        [JsonProperty("unitOfMeasureDescription")]
        public string UnitOfMeasureDescription { get; set; }
    }
}
