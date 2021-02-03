using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Order
    {
        public Order(int quantity)
        {
            this.Quantity = quantity;
        }

        protected int Quantity;

        public virtual void Cook() { }

        public int GetQuantity()
        {
            return this.Quantity;
        }
    }
}
