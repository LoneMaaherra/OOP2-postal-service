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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Postalservice.src.customer;

namespace Postalservice.src
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        private MainWindow mainWindow;

        public StartPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void BtnOpenCustomerPage(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("customerLogin");
        }

        public void GoToHomepage()
        {
            Content = this;
        }

        private void BtnOpenAdminLoginPage(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("adminLogin");
        }
    }
}
