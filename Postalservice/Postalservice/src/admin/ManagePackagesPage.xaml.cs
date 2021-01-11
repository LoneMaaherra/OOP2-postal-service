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
    /// Interaction logic for ManagePackagesPage.xaml
    /// </summary>
    public partial class ManagePackagesPage : Page
    {
        private MainWindow mainWindow;
        public ManagePackagesPage(MainWindow mainWindow)
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

        private void CheckOutPackage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("managePackages");
        }

        private void AddPackage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("addParcel");
        }
    }
}
