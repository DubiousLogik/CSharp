using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Entities;
namespace MovingData.OrderManagement
{
    public class OrderSampleGenerator
    {
        public static Order CreateOrder(int orderId, Dictionary<string,Product> catalog)
        {
            var order = new Order();
            order.Id = orderId;

            Product p1 = catalog["SKU456"];
            Product p2 = catalog["PCN-24967"];

            order.AddLineItem(p1, 1M);
            order.AddLineItem(p2, 0.45M);

            return order;
        }
    }
}
