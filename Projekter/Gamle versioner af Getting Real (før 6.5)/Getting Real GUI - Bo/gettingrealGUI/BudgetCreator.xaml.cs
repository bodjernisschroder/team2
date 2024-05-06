using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace GettingReal
{
    /// <summary>
    /// Interaction logic for TilbudControl.xaml
    /// </summary>
    public partial class BudgetCreator : UserControl
    {
        public static ObservableCollection<BudgetItem> BudgetItems { get; set; }


        public BudgetCreator()
        {
            InitializeComponent();
            BudgetItems = new ObservableCollection<BudgetItem>();
            myDataGrid.ItemsSource = BudgetItems;
        }

        private void btnNewBudget_Click(object sender, RoutedEventArgs e)
        {
            NewItemPopup newItemPopup = new NewItemPopup();

            if (newItemPopup.ShowDialog() == true)
            {
                UpdateTotal();
                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = BudgetItems;
            }
        }

        private void btnSaveBudget_Click(object sender, RoutedEventArgs e)
        {
            SavePopup saveDialog = new SavePopup();

            if (saveDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveDialog.FilePath))
                {
                    foreach (var item in BudgetItems)
                    {
                        writer.WriteLine($"{item.Description},{item.Amount}");
                    }
                }
            }
        }

        private void btnLoadBudget_Click(object sender, RoutedEventArgs e)
        {
            LoadPopup loadDialog = new LoadPopup();

            if (loadDialog.ShowDialog() == true)
            {
                BudgetItems.Clear();

                using (StreamReader reader = new StreamReader(loadDialog.FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');

                        var newItem = new BudgetItem(double.Parse(parts[1]), parts[0]);
                        BudgetItems.Add(newItem);
                    }
                }
                UpdateTotal();
            }
        }

        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (BudgetItem)button.DataContext;
            BudgetItems.Remove(item);

            if (BudgetItems.Count == 0) lblTotalPris.Content = $"0,00 kr.";
            else UpdateTotal();
        }
        private void UpdateTotal()
        {
            var totalPrice = BudgetItems.Sum(item => item.Amount);
            lblTotalPris.Content = $"{totalPrice:C}";
        }
    }
}
