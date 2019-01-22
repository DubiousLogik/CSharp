using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Entities;
using MovingData.Json.Models;
using MovingData.OrderManagement;
using MovingData.Json.Transforms;
using Newtonsoft.Json;

namespace MovingData.Json
{
    public static class JsonRunner
    {
        public static void Run(Order order)
        {
            // Convert to WireFormat with Json Properties
            var orderJson = OrderJsonTransformer.ConvertToOrderJson(order);

            string orderJsonOutput = JsonConvert.SerializeObject(order);

            Console.WriteLine("Order JSON:");
            Console.WriteLine(orderJsonOutput);
        }
    }
}
