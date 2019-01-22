using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingData.Entities
{
    public class OrderItem
    {
        public int LineItemNumber { get; set; }

        public Product Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal LineItemCost { get; set; }
    }
}
