using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovingData.ProductCatalog;

namespace MovingData.Entities
{
    public class Product
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal UnitCost { get; set; }

        public UnitOfMeasure UoM { get; set; }

        public string UnitOfMeasureDescription { get; set; }
    }
}
