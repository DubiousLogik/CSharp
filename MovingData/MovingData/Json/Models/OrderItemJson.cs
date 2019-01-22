using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MovingData.Json.Models
{
    public class OrderItemJson
    {
        [JsonProperty("lineItemNumber")]
        public int LineItemNumber { get; set; }

        [JsonProperty("product")]
        public ProductJson Product { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("lineItemCost")]
        public decimal LineItemCost { get; set; }
    }
}
