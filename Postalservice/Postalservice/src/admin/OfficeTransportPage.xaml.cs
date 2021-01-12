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
using Postalservice.src.api;

namespace Postalservice.src.admin
{
    /// <summary>
    /// Interaction logic for OfficeTransportPage.xaml
    /// </summary>
    public partial class OfficeTransportPage : Page
    {
        private MainWindow mainWindow;
        public OfficeTransportPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void ReturnTrue_CanExecute(object value, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ReturnToStartPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.currentOffice = null;
            mainWindow.Content = mainWindow.GetPage("start");
        }
        private void GoToHomePage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("officeHome");
        }

        #region Tab buttons
        private void ManageTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ManageTab.Visibility = Visibility.Visible;
            AddTab.Visibility = Visibility.Hidden;
            PackTab.Visibility = Visibility.Hidden;

            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        
        private void AddTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddTab.Visibility = Visibility.Visible;
            ManageTab.Visibility = Visibility.Hidden;
            PackTab.Visibility = Visibility.Hidden;

            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void PackTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            PackTab.Visibility = Visibility.Visible;
            ManageTab.Visibility = Visibility.Hidden;
            AddTab.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        #region Manage buttons
        private void Arrival_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void Depart_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        #region Add buttons
        private void AddTransport_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void CancelTransport_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        #region Pack buttons
        private void ClearStorageFilter_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void PackAll_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void ClearFilter_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void UnpackAll_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion
    }
}
