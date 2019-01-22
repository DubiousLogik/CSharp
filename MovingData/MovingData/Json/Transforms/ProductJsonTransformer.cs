using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Entities;
using MovingData.Json.Models;

namespace MovingData.Json.Transforms
{
    public static class ProductJsonTransformer
    {
        public static ProductJson ConvertToProductJson(Product product)
        {
            if (product == null)
            {
                return null;
            }

            var productJson = new ProductJson()
            {
                Id = product.Id,
                Description = product.Description,
                UnitCost = product.UnitCost,
                UnitOfMeasureDescription = product.UnitOfMeasureDescription,
                UoM = product.UoM
            };

            return productJson;
        }
    }
}
