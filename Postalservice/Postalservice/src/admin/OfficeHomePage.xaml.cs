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
    /// Interaction logic for OfficeHomePage.xaml
    /// </summary>
    public partial class OfficeHomePage : Page
    {
        private MainWindow mainWindow;
        public OfficeHomePage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.DataContext = mainWindow;
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
        private void GoToManagePackagesPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("managePackages");
        }
        private void GoToManageTransportsPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }

        private void GoToManageVehiclesPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("officeHome");
        }
    }
}
