using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for TilbudControl.xaml
    /// </summary>
    public partial class BudgetCreator : UserControl
    {

        public BudgetCreator()
        {
            InitializeComponent();

            DataContext = new BudgetController();

            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.CreateBudget();
        }

        private void btnNewBudget_Click(object sender, RoutedEventArgs e)
        {
            NewItemPopup newItemPopup = new NewItemPopup();

            if (newItemPopup.ShowDialog() == true)
            {
                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = BudgetController.Budget.Products;
                BudgetController budgetController = (BudgetController)DataContext;
                budgetController.UpdateSum();
                lblTotalPris.Content = BudgetController.Budget.Sum;
            }
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
                BudgetController budgetController = (BudgetController)DataContext;
                budgetController.ResetBudget();
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
                budgetController.UpdateSum();
            }
        }

        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Product product = (Product)button.DataContext;
            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.RemoveProduct(product);
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = BudgetController.Budget.Products;
            lblTotalPris.Content = BudgetController.Budget.Sum;
        }
    }
}
