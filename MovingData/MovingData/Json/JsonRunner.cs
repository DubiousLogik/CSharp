using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Json.Generators;
using Newtonsoft.Json;

namespace MovingData.Json
{
    public static class JsonRunner
    {
        public static void Run()
        {
            var order = JsonOrderSample.CreateOrder(24);
            string orderJson = JsonConvert.SerializeObject(order);
            Console.WriteLine("Order JSON:");
            Console.WriteLine(orderJson);
        }
    }
}
