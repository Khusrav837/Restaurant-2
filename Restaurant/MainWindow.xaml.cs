using Restaurant.Models;
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
        Server Server = new Server();
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
            try
            {
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

                var drink = (Drinks)drinks.SelectedItem;

                Server.Receive(quantityChicken, quantityEgg, drink);
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
                Server.SendToCook();
            }
            catch(Exception ex)
            {
                Results.Items.Add(ex.Message);
            } 
        }

        private void Serve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var resultOfCooks = Server.Serve();
                for (int i = 0; i < resultOfCooks.Length; i++)
                {
                    Results.Items.Add(resultOfCooks[i]);
                }
                Results.Items.Add("Please enjoy your food!");
            }
            catch(Exception ex)
            {
                Results.Items.Add(ex.Message);
            }
        }
    }
}
