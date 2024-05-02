using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for SavePopup.xaml
    /// </summary>
    public partial class LoadPopup : Window
    {
        public string FilePath { get; set; }
        public LoadPopup()
        {
            InitializeComponent();
        }

        private void btnLoadGennemse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
                txtboxLoadPath.Text = FilePath;
            }
        }

        private void btnLoadOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnLoadFortryd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
