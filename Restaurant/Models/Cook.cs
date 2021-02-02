using Restaurant.Moels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Cook
    {
        private object order;
        public void SubmitRequest(int quantity, OrderTypes type)
        {
            if (type == OrderTypes.Chicken)
            {
                order = new ChickenOrder(quantity);
            }
            else
            {
                order = new EggOrder(quantity);
            }
        }

        public string PrepareFood()
        {
            if (order is ChickenOrder)
            {

                ChickenOrder c = (ChickenOrder)order;
                for (int i = 0; i < c.GetQuantity(); i++)
                {
                    c.CutUp();
                }
                c.Cook();
                return "indicating preparation has been completed";
            }
            else if (order is EggOrder)
            {
                var rotten = 0;
                EggOrder e = (EggOrder)order;
                for (int i = 0; i < e.GetQuantity(); i++)
                {
                    try
                    {
                        e.Crack();
                    }
                    catch
                    {
                        rotten++;
                    }
                    e.DiscardShell();
                }
                e.Cook();
                return "indicating preparation has been completed " + rotten.ToString();
            }
            throw new Exception("Hey Guy You haven't instance!");
        }
    }
}
