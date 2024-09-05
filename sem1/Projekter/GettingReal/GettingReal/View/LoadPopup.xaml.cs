using Microsoft.Win32;
using System.Windows;

namespace GettingReal
{
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