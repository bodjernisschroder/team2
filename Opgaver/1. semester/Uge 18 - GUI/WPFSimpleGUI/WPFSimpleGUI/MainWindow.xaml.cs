using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSimpleGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Giv knap et navn under properties med hungarian case efterfulgt af pascalcase.
        // Dobbelklik på knappen, hvorefter en metode bliver oprettet for knappen i .cs filen
        private void btnScrollUp_Click(object sender, RoutedEventArgs e)
        {
            string temp = txtbox1.Text;
            txtbox1.Text = txtbox2.Text;
            txtbox2.Text = txtbox3.Text;
            txtbox3.Text = txtbox4.Text;
            txtbox4.Text = temp;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtbox1.Clear();
            txtbox2.Clear();
            txtbox3.Clear();
            txtbox4.Clear();
        }

        private void btnScrollDown_Click(object sender, RoutedEventArgs e)
        {
            string temp = txtbox4.Text;
            txtbox4.Text = txtbox3.Text;
            txtbox3.Text = txtbox2.Text;
            txtbox2.Text = txtbox1.Text;
            txtbox1.Text = temp;
        }
    }
}