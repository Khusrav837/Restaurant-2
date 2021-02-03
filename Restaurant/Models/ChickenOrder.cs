using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class ChickenOrder : Order
    {
        public ChickenOrder(int quantity) : base(quantity)
        {
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void CutUp() { }
    }
}
