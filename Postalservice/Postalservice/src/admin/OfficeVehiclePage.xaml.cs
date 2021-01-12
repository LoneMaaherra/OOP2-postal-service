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

namespace Postalservice.src.admin
{
    /// <summary>
    /// Interaction logic for OfficeVehiclePage.xaml
    /// </summary>
    public partial class OfficeVehiclePage : Page
    {
        private MainWindow mainWindow;
        public OfficeVehiclePage(MainWindow mainWindow)
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

        private void Ok_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }
        private void Cancel_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }

        private void VehiclesTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            VehiclesTab.Visibility = Visibility.Visible;
            AddVehicleTab.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }
        private void AddTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddVehicleTab.Visibility = Visibility.Visible;
            VehiclesTab.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }
    }
}
