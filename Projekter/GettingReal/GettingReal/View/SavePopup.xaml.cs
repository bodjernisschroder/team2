using Microsoft.Win32;
using System.Windows;

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for SavePopup.xaml
    /// </summary>
    public partial class SavePopup : Window
    {
        public string FilePath { get; set; }
        public SavePopup()
        {
            InitializeComponent();
        }

        private void btnSaveGennemse_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dialog.FileName = "budget.txt";

            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
                txtboxSavePath.Text = $"{FilePath}{dialog.FileName}";
            }
        }

        private void btnSaveOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnSaveFortryd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
