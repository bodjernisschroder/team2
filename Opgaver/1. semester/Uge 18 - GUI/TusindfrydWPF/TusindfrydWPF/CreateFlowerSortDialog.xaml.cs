using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {
        public string name;
        public string picturePath;
        public int productionTime;
        public int halfLifeTime;
        public int size;

        public CreateFlowerSortDialog()
        {
            InitializeComponent();
        }

        private void txtNavn_LostFocus(object sender, RoutedEventArgs e)
        {
            name = txtNavn.Text;
        }

        private void txtBilledeSti_LostFocus(object sender, RoutedEventArgs e)
        {
            picturePath = txtBilledeSti.Text;
        }

        private void txtProduktionstid_LostFocus(object sender, RoutedEventArgs e)
        {
            productionTime = int.Parse(txtProduktionstid.Text);
        }

        private void txtHalveringstid_LostFocus(object sender, RoutedEventArgs e)
        {
            halfLifeTime = int.Parse(txtHalveringstid.Text);
        }

        private void txtStørrelse_LostFocus(object sender, RoutedEventArgs e)
        {
            size = int.Parse(txtStørrelse.Text);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNavn.Text) ||
                !string.IsNullOrEmpty(txtBilledeSti.Text) ||
                !string.IsNullOrEmpty(txtProduktionstid.Text) ||
                !string.IsNullOrEmpty(txtHalveringstid.Text) ||
                !string.IsNullOrEmpty(txtStørrelse.Text))
            {
                
            }
            else
            {
                btnOk.IsEnabled = true;
                FlowerSort flowerSort = new FlowerSort(name, picturePath, productionTime, halfLifeTime, size);

                MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
                mainWindow.flowerSorts.Add(flowerSort);

                mainWindow.UpdateFlowerList();

                this.Close();
            }
        }




        private void btnFortryd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
