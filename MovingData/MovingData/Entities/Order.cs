using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingData.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public List<OrderItem> OrderItems
        {
            get
            {
                return this.orderItems;
            }
        }

        public decimal Subtotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }


        private int nextOrderItemNumber;

        private List<OrderItem> orderItems;

        private decimal taxRate = 0.10M;

        public Order()
        {
            this.nextOrderItemNumber = 0;
            this.orderItems = new List<OrderItem>();
        }

        public int AddLineItem(Product p, decimal quantity)
        {
            var oi = new OrderItem()
            {
                LineItemNumber = this.nextOrderItemNumber,
                Product = p,
                LineItemCost = quantity * p.UnitCost,
                Quantity = quantity
            };

            this.orderItems.Add(oi);
            this.UpdateTotals();
            this.nextOrderItemNumber++;

            return oi.LineItemNumber;
        }

        public void UpdateTotals()
        {
            this.UpdateSubTotal();
            this.UpdateTotal();
            this.UpdateTax();
        }

        public void UpdateSubTotal()
        {
            decimal newSubTotal = 0M;

            foreach (var item in this.orderItems)
            {
                newSubTotal += item.LineItemCost;
            }

            this.Subtotal = newSubTotal;
        }

        public void UpdateTotal()
        {
            decimal newTotal = 0M;

            foreach (var item in this.orderItems)
            {
                newTotal += item.LineItemCost;
            }

            this.Total = newTotal;
        }

        public void UpdateTax()
        {
            this.Tax = this.Total * this.taxRate;
            this.Total += this.Tax;
        }

    }
}
