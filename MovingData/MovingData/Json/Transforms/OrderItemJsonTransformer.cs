using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Entities;
using MovingData.Json.Models;

namespace MovingData.Json.Transforms
{
    public static class OrderItemJsonTransformer
    {
        public static List<OrderItemJson> ConvertListToOrderItemjson(List<OrderItem> orderItems)
        {
            var results = new List<OrderItemJson>();

            foreach (var item in orderItems)
            {
                results.Add(ConvertToOrderItemJson(item));
            }

            return results;
        }

        public static OrderItemJson ConvertToOrderItemJson(OrderItem orderItem)
        {
            var orderItemJson = new OrderItemJson()
            {
                LineItemNumber = orderItem.LineItemNumber,
                Product = ProductJsonTransformer.ConvertToProductJson(orderItem.Product),
                Quantity = orderItem.Quantity,
                LineItemCost = orderItem.LineItemCost
            };

            return orderItemJson;
        }
    }
}
