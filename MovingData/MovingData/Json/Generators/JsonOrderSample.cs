using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Json.Models;
using Newtonsoft.Json;

namespace MovingData.Json.Generators
{
    public static class JsonOrderSample
    {
        public static Order CreateOrder(int orderId)
        {
            var order = new Order();
            order.Id = orderId;

            var p1 = new Product()
            {
                Id = "SKU456",
                Description = "Espresso Grinder",
                UnitCost = 100.00M,
                UoM = UnitOfMeasure.Each
            };

            var p2 = new Product()
            {
                Id = "PCN-24967",
                Description = "12 Gauge Wire, Insulated",
                UnitCost = 0.45M,
                UoM = UnitOfMeasure.Meter
            };

            order.AddLineItem(p1, 1M);
            order.AddLineItem(p2, 0.45M);

            return order;
        }
    }
}
