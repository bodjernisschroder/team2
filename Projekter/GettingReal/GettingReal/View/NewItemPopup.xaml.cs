using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    public partial class NewItemPopup : Window
    {
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (Catalogue.CategorizedProducts.Any(category => category.Value.Contains(value)))
                {
                    _productName = value;
                }
                else
                {
                    throw new ArgumentException("The product does not exist in any category.");
                }
            }
        }

        private int _productTimeEstimate;

        public int ProductTimeEstimate
        {
            get { return _productTimeEstimate; }
            set
            {
                if (value > 0)
                {
                    _productTimeEstimate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(ProductTimeEstimate), "Product time estimate must be greater than 0.");
                }
            }
        }

        private DataHandler _catalogueDataHandler;

        public DataHandler CatalogueDataHandler
        {
            get { return _catalogueDataHandler; }
            set
            {
                if (value != null)
                {
                    _catalogueDataHandler = value;
                }
                else
                {
                    throw new ArgumentException("Catalogue data handler cannot be null");
                }
            }
        }

        public NewItemPopup()
        {
            InitializeComponent();

            CatalogueDataHandler = new DataHandler("ydelser.txt");
            CatalogueDataHandler.LoadCatalogue();

            for (int i = 0; i < Catalogue.CategorizedProducts.Keys.Count; i++)
            {
                lstSelection.Items.Add(new ListBoxItem { Content = Catalogue.CategorizedProducts.Keys.ElementAt(i) } );
            }
        }

        private void LstSelection_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelection.SelectedItem is ListBoxItem selectedItem)
            {
                string category = selectedItem.Content.ToString();
                lstSelection.Items.Clear();
                List<string> productsInCategory = Catalogue.CategorizedProducts[category];
                foreach (string product in productsInCategory)
                {
                    lstSelection.Items.Add(new ListBoxItem { Content = product });
                }
                txtTimeEstimat.IsEnabled = true;
            }
            UpdateOKButtonState();
        }


        private void btnAddNewItemOK_Click(object sender, RoutedEventArgs e)
        {
            BudgetController budgetController = new BudgetController();

            if (lstSelection.SelectedItem is ListBoxItem selectedItem)
            {
                if (int.TryParse(txtTimeEstimat.Text, out int timeEstimate) && timeEstimate > 0)
                {
                    ProductName = selectedItem.Content.ToString();
                    ProductTimeEstimate = timeEstimate;
                    budgetController.AddProduct(ProductName, ProductTimeEstimate);
                    DialogResult = true;
                    Close();
                }
            }
        }
        private void btnAddNewItemFortryd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnPreviousSection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateOKButtonState()
        {
            bool productSelected = lstSelection.SelectedItem != null;
            bool timeIsValid = int.TryParse(txtTimeEstimat.Text, out int timeEstimate) && timeEstimate > 0; 

            btnAddNewItemOK.IsEnabled = productSelected && timeIsValid; 
        }
        private void TxtTimeEstimat_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOKButtonState();
        }
    }
}
