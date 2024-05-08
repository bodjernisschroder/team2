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

        // Programmet crasher hvis man dobbeltklikker et sted i grid'et, der ikke har en værdi
        private void LstSelection_DoubleClick(object sender, EventArgs e)
        {
            if (!(lstSelection.SelectedItem is string))
            {
                ListBoxItem selectedItem = (ListBoxItem)lstSelection.SelectedItem;
                string category = selectedItem.Content.ToString();
                lstSelection.Items.Clear();
                List<string> productsInCategory = Catalogue.CategorizedProducts[category];
                foreach (string product in productsInCategory)
                {
                    Trace.WriteLine(product);
                    lstSelection.Items.Add(product);
                }
                // Gør så timeestimatfeltet først er synligt efter dette - eller enabled, hvis synligt
                // er for kompliceret eller kræver et helt nyt vindue
            }
        }
        private void btnAddNewItemOK_Click(object sender, RoutedEventArgs e)
        {
            // Indbyg, at den er disabled indtil product er valgt i stedet for dette
            //if (selectedProduct == null)
            //{
            //    MessageBox.Show("Vælg en ydelse fra listen for at fortsætte...");
            //    return;
            //}

            BudgetController budgetController = new BudgetController();
            ProductName = (string)lstSelection.SelectedItem;
            ProductTimeEstimate = int.Parse(txtTimeEstimat.Text);
            budgetController.AddProduct(ProductName, ProductTimeEstimate);
            DialogResult = true;
            Close();
        }
        private void btnAddNewItemFortryd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        //Min tanke med metoden her var at oprette knap, hvis man ønsker at tilføje en ny ydelse fra en anden
        // kategori uden at trykke på 'fortryd'. 
        private void btnPreviousSection_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
