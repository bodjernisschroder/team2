using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace GettingReal
{
    public partial class NewItemPopup : Window
    {
        public string ProductName { get; set; }
        public int ProductTimeEstimate { get; set; }

        public DataHandler CatalogueDataHandler { get; set; }

        public NewItemPopup()
        {
            InitializeComponent();

            CatalogueDataHandler = new DataHandler("ydelser.txt");
            CatalogueDataHandler.LoadCatalogue();

            // Dette skal gentages hver gang NewItemPopup kaldes,
            // ligesom andre værdier, såsom lstSelection.Items skal nulstilles
            // Lige nu køres nedenstående kun ved new NewItemPopup (selvfølgelig)
            // Derfor crasher programmet, når vi forsøger at tilføje en ny.
            for (int i = 0; i < Catalogue.CategorizedProducts.Keys.Count; i++)
            {
                lstSelection.Items.Add(new ListBoxItem { Content = Catalogue.CategorizedProducts.Keys.ElementAt(i) } );
            }
        }

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
