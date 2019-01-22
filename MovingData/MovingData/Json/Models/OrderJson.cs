using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MovingData.Json.Models
{
    public class OrderJson
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("orderItems")]
        public List<OrderItemJson> OrderItems { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}
