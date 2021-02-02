

using System;

namespace Restaurant.Models
{
    
    public class Server
    {
        private object[][] items = new object[8][];
        private Cook cook;
        private string[] resultOfCooks;
        int customerIndex = 0;
        Boolean sendedToCook = false;
        Boolean served = false;

        public Server()
        {
            cook = new Cook();
        }

        public void Receive(int chickenQuantity, int eggQuantity, Drinks? drink)
        {
            int j = 0;
                if (customerIndex == 8)
                {
                    throw new Exception("All customers already gave you orders!");
                }
                var ordersCount = chickenQuantity + eggQuantity;
                if (drink != null)
                {
                    ordersCount++;
                }
                items[customerIndex] = new object[ordersCount];
                while (j < chickenQuantity)
                {
                   items[customerIndex][j] = OrderTypes.Chicken;
                   j++;
                }

                while (j < chickenQuantity + eggQuantity)
                {
                   items[customerIndex][j] = OrderTypes.Egg;
                   j++;
                }

                if (drink != null)
                {
                    items[customerIndex][j] = drink;
                }

                customerIndex++;
        }

        public void SendToCook()
        {
            if (customerIndex < 8)
            {
                throw new Exception("You didn't get order of customers!");
            }
            if (sendedToCook)
            {
                throw new Exception("You already cooked!");
            }
            sendedToCook = true;
            resultOfCooks = new string[8];
            var chicken = 0;
            var egg = 0;
            Drinks? drink = null;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < items[i].Length; j++)
                {
                    if (items[i][j] is OrderTypes)
                    {
                        if((OrderTypes)items[i][j] == OrderTypes.Chicken)
                        {
                            chicken++;
                        }
                        else
                        {
                            egg++;
                        }
                    }
                    else
                    {
                        drink = (Drinks)items[i][j];
                    }
                }
                cook.SubmitRequest(chicken, OrderTypes.Chicken);
                cook.PrepareFood();
                cook.SubmitRequest(egg, OrderTypes.Egg);
                cook.PrepareFood();
                resultOfCooks[i] = $"Customer {i} is served {chicken} chicken, {egg} egg, ";
                if (drink == null)
                {
                    resultOfCooks[i] += "no drinks";
                }
                else
                {
                    resultOfCooks[i] += $"{drink}";
                }
            }
        }

        public string[] Serve()
        {
            if (served)
            {
                throw new Exception("Customers already served!");
            }
            if (!sendedToCook)
            {
                throw new Exception("You didn't cook!");
            }
            served = true;
            return resultOfCooks;
        }
    }

    public enum OrderTypes : short
    {
        Chicken,
        Egg
    }

    public enum Drinks : short
    {
        Tea,
        Juice,
        RC_Cola,
        Coca_Cola
    }
}
