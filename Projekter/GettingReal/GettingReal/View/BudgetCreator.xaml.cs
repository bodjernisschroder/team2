using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for TilbudControl.xaml
    /// </summary>
    public partial class BudgetCreator : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

                //:C viser et tal som en valuta i stedet, som default bruger den samme valuta som det system brugeren sidder på.
                lblTotalPris.Content = $"{BudgetController.Budget.Sum:C}";
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

        private void PriceColumn_LostFocus(object sender, RoutedEventArgs e)
        {
            DataRowView row = ((FrameworkElement)sender).DataContext as DataRowView;

            int price = (int)row["Price"];
            Product product = (Product)row["Product"];

            //string price = ((sender as FrameworkElement).DataContext as DataRowView)["PriceColumn"].ToString();

            ProductController productController = new ProductController();
            productController.MakeCustomPrice(product, price);

            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.UpdateSum();

            myDataGrid.Items.Refresh();
            lblTotalPris.Content = $"{BudgetController.Budget.Sum:C}";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Product product = (Product)button.DataContext;
            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.RemoveProduct(product);
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = BudgetController.Budget.Products;
            lblTotalPris.Content = $"{BudgetController.Budget.Sum:C}";
        }
    }
}
