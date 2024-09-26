﻿using System;
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
using Microsoft.Extensions.Configuration;
using RegionSyd.ViewModel;

namespace RegionSyd.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AssignmentsView : Window
    {
        public AssignmentsView()
        {
            InitializeComponent();

            // Retrieve the connection string from app settings
            string connectionString = (Application.Current as App)?.Configuration.GetConnectionString("RegionSydDatabase");

            if (connectionString == null)
            {
                MessageBox.Show("Connection string not found.");
                // Handle the error accordingly, maybe close the application
            }
             
            DataContext = new AssignmentsViewModel(connectionString);
        }
    }
}