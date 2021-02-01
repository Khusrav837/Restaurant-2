using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class Employee
    {
        public Employee()
        {

        }

        public string Inspect(object o)
        {
            if (o is EggOrder)
            {
                EggOrder e = (EggOrder)o;
                return e.GetQuality().ToString();
            }
            return "specifies no inspection is required";
        }

        public string PrepareFood(object o)
        {
            if (o is ChickenOrder)
            {

                ChickenOrder c = (ChickenOrder)o;
                for (int i = 0; i < c.GetQuantity(); i++)
                {
                    c.CutUp();
                }
                c.Cook();
                return "indicating preparation has been completed";
            }
            else if (o is EggOrder)
            {
                var rotten = 0;
                EggOrder e = (EggOrder)o;
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
