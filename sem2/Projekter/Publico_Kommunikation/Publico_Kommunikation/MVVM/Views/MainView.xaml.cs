using System.Windows;

namespace Publico_Kommunikation_Project.MVVM.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception("This is a test exception.");
        }
    }
}
