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

namespace Postalservice.src.customer
{
    /// <summary>
    /// Interaction logic for UserSendingParcelPage.xaml
    /// </summary>
    public partial class UserSendingParcelPage : Page
    {
        private MainWindow mainWindow;
        public UserSendingParcelPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }
    }
}