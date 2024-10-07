using System.Windows;
using Microsoft.Extensions.Configuration;
using RegionSyd.ViewModel;

namespace RegionSyd.View
{
    public partial class AssignmentsView : Window
    {
        public AssignmentsView()
        {
            InitializeComponent();

            string connectionString = (Application.Current as App)?.Configuration.GetConnectionString("RegionSydDatabase");

            if (connectionString == null)
            {
                MessageBox.Show("Connection string not found.");
            }
             
            DataContext = new AssignmentsViewModel(connectionString);
        }
    }
}
