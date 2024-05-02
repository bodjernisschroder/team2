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
        public Budget Budget {  get; set; }

        public BudgetCreator()
        {
            InitializeComponent();

            BudgetController budgetController = new BudgetController();
            Budget = budgetController.CreateBudget();
            myDataGrid.ItemsSource = Budget.Products;
        }

        private void btnNewBudget_Click(object sender, RoutedEventArgs e)
        {
            NewItemPopup newItemPopup = new NewItemPopup();

            // Hvad sker der her?
            //if (newItemPopup.ShowDialog() == true)
            //{
            //    UpdateTotal();
            //    myDataGrid.ItemsSource = null;
            //    myDataGrid.ItemsSource = Budget.Products;
            //}
        }

        private void btnSaveBudget_Click(object sender, RoutedEventArgs e)
        {
            SavePopup saveDialog = new SavePopup();

            if (saveDialog.ShowDialog() == true)
            {
                // Kald en metode i DataHandler, som gør dette

                //using (StreamWriter writer = new StreamWriter(saveDialog.FilePath))
                //{
                //    foreach (var item in Budget.Products)
                //    {
                //        writer.WriteLine($"{item.Description},{item.Amount}");
                //    }
                //}
            }
        }

        private void btnLoadBudget_Click(object sender, RoutedEventArgs e)
        {
            LoadPopup loadDialog = new LoadPopup();

            if (loadDialog.ShowDialog() == true)
            {
                BudgetController budgetController = new BudgetController();
                budgetController.ResetBudget(Budget);
                // Kald en metode i DataHandler, som gør dette

                //using (StreamReader reader = new StreamReader(loadDialog.FilePath))
                //{
                //    string line;
                //    while ((line = reader.ReadLine()) != null)
                //    {
                //        var parts = line.Split(',');

                //        var newItem = new Budget.Products(double.Parse(parts[1]), parts[0]);
                //        Budget.Products.Add(newItem);
                //    }
                //}
                // Budget.Products = det, der er loadet (add efter hvert load?)
                budgetController.UpdateSum(Budget);
            }
        }

        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Product product = (Budget.Products)button.DataContext;
            BudgetController budgetController = new BudgetController();
            budgetController.RemoveProduct(Budget, product);
            // Lav databinding på det herunder i stedet, altså lblTotalPris
            //if (Budget.Products.Count == 0) lblTotalPris.Content = $"0,00 kr.";
        }
    }
}
