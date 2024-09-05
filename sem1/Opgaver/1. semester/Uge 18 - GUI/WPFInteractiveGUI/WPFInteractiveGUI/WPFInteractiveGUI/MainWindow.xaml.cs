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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller();
        }

        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();
            btnDeletePerson.IsEnabled = true;
            btnUp.IsEnabled = true;
            btnDown.IsEnabled = true;
            txtFirstName.IsEnabled = true;
            txtLastName.IsEnabled = true;
            txtAge.IsEnabled = true;
            txtTelephoneNo.IsEnabled = true;
            lblPersonCount.Content = $"Person Count: {controller.PersonCount}";
            lblIndex.Content = $"Index: {controller.PersonIndex}";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtTelephoneNo.Clear();
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
            if(controller.PersonCount  == 0)
            {
                btnDeletePerson.IsEnabled = false;
                btnUp.IsEnabled = false;
                btnDown.IsEnabled = false;
                txtFirstName.IsEnabled = false;
                txtLastName.IsEnabled = false;
                txtAge.IsEnabled = false;
                txtTelephoneNo.IsEnabled = false;
            }
            lblPersonCount.Content = $"Person Count: {controller.PersonCount}";
            lblIndex.Content = $"Index: {controller.PersonIndex}";
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            txtFirstName.Text = controller.CurrentPerson.FirstName;
            txtLastName.Text = controller.CurrentPerson.LastName;
            txtAge.Text = $"{controller.CurrentPerson.Age}";
            txtTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            lblIndex.Content = $"Index: {controller.PersonIndex}";
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            txtFirstName.Text = controller.CurrentPerson.FirstName;
            txtLastName.Text = controller.CurrentPerson.LastName;
            txtAge.Text = $"{controller.CurrentPerson.Age}";
            txtTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            lblIndex.Content = $"Index: {controller.PersonIndex}";
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            controller.CurrentPerson.FirstName = txtFirstName.Text;
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            controller.CurrentPerson.LastName = txtLastName.Text;
        }

        private void txtAge_LostFocus(object sender, RoutedEventArgs e)
        {
            controller.CurrentPerson.Age = int.Parse(txtAge.Text);
        }

        private void txtTelephoneNo_LostFocus(object sender, RoutedEventArgs e)
        {
            controller.CurrentPerson.TelephoneNo = txtTelephoneNo.Text;
        }
    }
}
