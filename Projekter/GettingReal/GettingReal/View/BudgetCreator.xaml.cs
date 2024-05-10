using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Input;
using System.Diagnostics.Eventing.Reader;

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for TilbudControl.xaml
    /// </summary>
    public partial class BudgetCreator : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool customPricesLocked = false;

        public BudgetCreator()
        {
            InitializeComponent();

            DataContext = new BudgetController();

            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.CreateBudget();
            UpdateGrid();
        }

        private void NewBudget_Click(object sender, RoutedEventArgs e)
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

        private void SaveBudget_Click(object sender, RoutedEventArgs e)
        {
            SavePopup saveDialog = new SavePopup();

            if (saveDialog.ShowDialog() == true)
            {
                List<Product> products = BudgetController.Budget.Products;
                DataHandler.SaveBudgetToFile(saveDialog.FilePath, products);
            }
        }

        private void LoadBudget_Click(object sender, RoutedEventArgs e)
        {
            LoadPopup loadDialog = new LoadPopup();
            if (loadDialog.ShowDialog() == true)
            {
                DataHandler dataHandler = new DataHandler();
                BudgetController budgetController = (BudgetController)DataContext;
                dataHandler.LoadBudgetFromFile(loadDialog.FilePath, budgetController);
            }
            UpdateGrid();
        }


        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.SelectAll();
            DataObject dataObj = new DataObject();
            Clipboard.SetDataObject(dataObj, true);
            myDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;

        }


        private void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            BudgetController budgetController = (BudgetController)DataContext;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                TextBox editedTextBox = e.EditingElement as TextBox;
                Product product = e.Row.Item as Product;
                ProductController productController = new ProductController();

                var columnHeader = e.Column.Header.ToString();

                if (columnHeader == "Pris")
                {
                    productController.MakeCustomPrice(product, int.Parse(editedTextBox.Text));
                }
                else if (columnHeader == "Time Estimat")
                {
                    if (customPricesLocked == false)
                    {
                        productController.ChangeTimeEstimate(product, int.Parse(editedTextBox.Text), BudgetController.Budget.PriceLevel);
                    }
                    else productController.ChangeTimeEstimate(product, int.Parse(editedTextBox.Text));
                }
            }

            budgetController.UpdateSum();
            UpdateGrid();
        }

        private void PriceLevel_Click(object sender, RoutedEventArgs e)
        {
            BudgetController budgetController = (BudgetController)DataContext;
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            switch (btn.Name)
            {
                case "btnPriceLevelLow":
                    budgetController.ChangePriceLevel(PriceLevel.Low, customPricesLocked);
                    btnPriceLevelMedium.IsEnabled = true;
                    btnPriceLevelHigh.IsEnabled = true;
                    break;
                case "btnPriceLevelMedium":
                    budgetController.ChangePriceLevel(PriceLevel.Medium, customPricesLocked);
                    btnPriceLevelLow.IsEnabled = true;
                    btnPriceLevelHigh.IsEnabled = true;
                    break;
                case "btnPriceLevelHigh":
                    budgetController.ChangePriceLevel(PriceLevel.High, customPricesLocked);
                    btnPriceLevelLow.IsEnabled = true;
                    btnPriceLevelMedium.IsEnabled = true;
                    break;
                default:
                    break;
            }
            UpdateGrid();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customPricesLocked = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            customPricesLocked = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Product product = (Product)button.DataContext;
            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.RemoveProduct(product);
            UpdateGrid();
        }

        private void TextRabat_LostFocus(object sender, RoutedEventArgs e)
        {
            BudgetController budgetController = (BudgetController)DataContext;
            budgetController.ApplyDiscount(int.Parse(txtRabat.Text));
            UpdateGrid();
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                (sender as UIElement).MoveFocus(request);
            }
        }

        private void UpdateGrid()
        {
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = BudgetController.Budget.Products;
            lblTotalPris.Content = $"{BudgetController.Budget.Sum:C}";
        }

  

    }
}
