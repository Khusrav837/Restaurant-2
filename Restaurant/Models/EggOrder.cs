using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Moels
{
    public class EggOrder : Order
    {
        private int Quality;

        public EggOrder(int quantity) : base(quantity)
        {
            Random rand = new Random();
            this.Quality = rand.Next(101);
        }

        public int GetQuality()
        {
            return this.Quality;
        }

        public void Crack()
        {
            if (this.Quality < 25)
            {
                throw new Exception("Quality is less!");
            }
        }

        public void DiscardShell() { }
    }
}
