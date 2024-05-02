using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    public partial class NewItemPopup : Window
    {

        public NewItemPopup()
        {
            InitializeComponent();

            // Erstattes af dictionary loaded fra DataHandler
            //string[] lines = File.ReadAllLines("C:\\Users\\bosch\\Dropbox\\PC\\Desktop\\Skole\\boprivate\\Projekter\\Getting Real UI\\gettingrealGUI\\dummydata.txt");
            //foreach (var line in lines)
            //{
            //    var parts = line.Split(',');
            //    lstSelection.Items.Add(new ListBoxItem { Content = parts[1] });
            //}
        }

        private void btnAddNewItemOK_Click(object sender, RoutedEventArgs e)
        {
            string selectedProduct = (string)lstSelection.SelectedProduct;

            // Disabled indtil product er valgt i stedet
            //if (selectedProduct == null)
            //{
            //    MessageBox.Show("Vælg en ydelse fra listen for at fortsætte...");
            //    return;
            //}

            string description = selectedProduct.Content.ToString();

            ComboBoxItem selectedPriceLevel = (ComboBoxItem)cbDropdown.SelectedItem;
            string priceLevelString = selectedPriceLevel.Content.ToString().ToLower();

            double priceLevel = priceLevelString switch
            {
                "low" => 1100,
                "middel" => 1350,
                "høj" => 1600,
            };

            double timeEstimat = double.Parse(txtTimeEstimat.Text);
            double rabat = double.Parse(txtRabat.Text) / 100;
            double totalPrice = (timeEstimat * priceLevel) * (1 - rabat);

            totalPrice = Math.Ceiling(totalPrice / 1000) * 1000;

            BudgetItem newItem = new BudgetItem(totalPrice, description);
            BudgetCreator.BudgetItems.Add(newItem);

            Trace.WriteLine("OK");

            DialogResult = true;
            Close();
        }
        private void btnAddNewItemFortryd_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Fortryd");

            DialogResult = false;
            Close();
        }
    }
}
