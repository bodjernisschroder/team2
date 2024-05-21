using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;
using System.Windows.Data;

namespace GettingReal
{
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
            //Kalder metoden nedenfor for, når der klikkes på knappen i programmet
            CopyToClipboard(myDataGrid);
        }

        // Metoden, som sikrer, at Kopiering af datagrid virker
        private void CopyToClipboard(DataGrid datagrid)
        {
            StringBuilder myStringBuilder = new StringBuilder();
            myStringBuilder.AppendLine("<html><body><table>");

            // Samler navne i kolonner
            myStringBuilder.Append("<tr>");

            // Vi bruger et for loop her i stedet for et for each,
            // så den sidste kolonne med 'delete' ikke kommer med 
            for (int i = 0; i < datagrid.Columns.Count-1; i++)
            {
                myStringBuilder.AppendFormat("<th>{0}</th>", datagrid.Columns[i].Header);
            }
            myStringBuilder.AppendLine("</tr>");

            // Tilføjer rækker
            foreach (var item in datagrid.Items)
            {
                myStringBuilder.Append("<tr>");

                // Samme princip med for loops er også gældende her - bare for rækker
                for (int j = 0; j < datagrid.Columns.Count -1; j++)
                {
                    if (datagrid.Columns[j] is DataGridBoundColumn boundColumn)
                    {
                     
                        var binding = boundColumn.Binding as Binding;
                        if (binding != null)
                        {
                            var path = binding.Path.Path;
                            var value = item.GetType().GetProperty(path)?.GetValue(item, null)?.ToString();
                            myStringBuilder.AppendFormat("<td>{0}</td>", value);
                        }
                    }
                }
                myStringBuilder.AppendLine("</tr>");
            }
            myStringBuilder.AppendLine("</table></body></html>");
            string clipboardHtml = FormatHtmlClipboard(myStringBuilder.ToString());
            Clipboard.SetText(clipboardHtml, TextDataFormat.Html);
        }
        private string FormatHtmlClipboard(string html)
        {
            const string Header =
                "Version:0.9\r\n" +
                "StartHTML:00000097\r\n" +
                "EndHTML:{0}\r\n" +
                "StartFragment:00000131\r\n" +
                "EndFragment:{1}\r\n";

            const string StartFragment = "<!--StartFragment-->";
            const string EndFragment = "<!--EndFragment-->";

            string htmlDocument = StartFragment + html + EndFragment;

            int startHtml = Header.Length - 8;
            int endHtml = startHtml + htmlDocument.Length;
            int startFragment = startHtml + StartFragment.Length;
            int endFragment = startFragment + html.Length;

            string header = string.Format(Header, endHtml.ToString("D9"), endFragment.ToString("D9"));

            return header + htmlDocument;
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