using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Entities;
using MovingData.Json.Models;

namespace MovingData.Json.Transforms
{
    public static class OrderJsonTransformer
    {
        public static OrderJson ConvertToOrderJson(Order order)
        {
            if (order == null)
            {
                return null;
            }

            var orderJson = new OrderJson()
            {
                Id = order.Id,
                OrderItems = OrderItemJsonTransformer.ConvertListToOrderItemjson(order.OrderItems),
                Subtotal = order.Subtotal,
                Tax = order.Tax,
                Total = order.Total
            };

            return orderJson;
        }
    }
}
