using Restaurant.Moels;
using System;
using System.Windows;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee Employee = new Employee();
        object[][] items = new object[8][];
        int customerIndex = 0;
        string[] cookResults = new string[8];
        Boolean cooked = false;
        Boolean served = false;
        public MainWindow()
        {
            InitializeComponent();
            drinks.Items.Add(Drinks.Tea);
            drinks.Items.Add(Drinks.Juice);
            drinks.Items.Add(Drinks.RC_Cola);
            drinks.Items.Add(Drinks.Coca_Cola);
        }

        private void getOrder_Click(object sender, RoutedEventArgs e)
        {
            int j = 0;
            try
            {
                if (customerIndex == 8) {
                    throw new Exception("All customers already gave you orders!");
                }
                var quantityChicken = int.Parse(chickenQuantity.Text);

                if (quantityChicken < 0)
                {
                    throw new Exception("Quantity can't to be less 0!");
                }

                var quantityEgg = int.Parse(eggQuantity.Text);

                if (quantityEgg < 0)
                {
                    throw new Exception("Quantity can't to be less 0!");
                }

                var drink = drinks.SelectedItem;
                var ordersCount = quantityChicken + quantityEgg;
                if (drink != null)
                {
                    ordersCount++;
                }
                items[customerIndex] = new object[ordersCount];
                if (quantityChicken > 0)
                {
                    var chiken = new ChickenOrder(quantityChicken);
                    while (j < quantityChicken)
                    {
                        items[customerIndex][j] = chiken;
                        j++;
                    }
                }

                if (quantityEgg > 0)
                {
                    var egg = new EggOrder(quantityEgg);

                    eggQuality.Content = $"Egg Quality: {egg.GetQuality()}";

                    while (j < quantityChicken + quantityEgg)
                    {
                        items[customerIndex][j] = egg;
                        j++;
                    }
                }

                if (drink != null)
                {
                    items[customerIndex][j] = drink;
                }

                customerIndex++;
            }
            catch(Exception ex)
            {
                Results.Items.Add(ex.Message);
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cooked)
                {
                    throw new Exception("Already cooked!");
                }
                cooked = true;

                for (int i = 0; i < 8; i++)
                {


                    var chikensCook = 0;
                    var eggsCook = 0;
                    Drinks? drink = null;
                    for (int j = 0; j < items[i].Length; j++)
                    {
                        if (items[i][j] is EggOrder)
                        {
                            var egg = (EggOrder)items[i][j];
                            if (egg.GetQuality() < 25)
                            {
                                break;
                            }
                            Employee.PrepareFood(egg);
                            eggsCook = egg.GetQuantity();
                        }
                        if (items[i][j] is ChickenOrder)
                        {
                            var chicken = (ChickenOrder)items[i][j];
                            Employee.PrepareFood(chicken);
                            chikensCook = chicken.GetQuantity();
                        }
                        if (items[i][j] is Drinks)
                        {
                            drink = (Drinks)items[i][j];
                        }
                    }
                    cookResults[i] = $"Customer {i} is served {chikensCook} chicken, {eggsCook} egg, ";
                    if (drink == null)
                    {
                        cookResults[i] += "no drinks";
                    }
                    else
                    {
                        cookResults[i] += $"{drink}";
                    }
                }
            }
            catch(Exception ex)
            {
                Results.Items.Add(ex.Message);
            } 
        }

        private void Serve_Click(object sender, RoutedEventArgs e)
        {
            if(served)
            {
                Results.Items.Add("Already served!");
                return;
            }
            served = true;
            for(int i = 0; i < 8; i++)
            {
                Results.Items.Add(cookResults[i]);
            }
            Results.Items.Add("Please enjoy your food!");
        }
    }
    enum Drinks : short
    {
        Tea,
        Juice,
        RC_Cola,
        Coca_Cola
    }
}
