using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.Entities;

namespace MovingData.ProductCatalog
{
    public class CatalogManager
    {
        public CatalogManager() { }

        public Dictionary<string, Product> Load()
        {
            var catalog = new Dictionary<string, Product>();

            var p1 = new Product()
            {
                Id = "SKU456",
                Description = "Espresso Grinder",
                UnitCost = 100.00M,
                UoM = UnitOfMeasure.Each,
                UnitOfMeasureDescription = UnitOfMeasure.Each.ToString()
            };

            catalog.Add(p1.Id, p1);

            var p2 = new Product()
            {
                Id = "PCN-24967",
                Description = "12 Gauge Wire, Insulated",
                UnitCost = 0.45M,
                UoM = UnitOfMeasure.Meter,
                UnitOfMeasureDescription = UnitOfMeasure.Meter.ToString()
            };

            catalog.Add(p2.Id, p2);

            return catalog;
        }
    }
}
