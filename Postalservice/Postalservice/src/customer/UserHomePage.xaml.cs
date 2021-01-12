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

namespace Postalservice.src.customer
{
    /// <summary>
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Page
    {
        private MainWindow mainWindow;


        public UserHomePage(MainWindow mainWindow)
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
            mainWindow.currentCustomer = null;
            mainWindow.Content = mainWindow.GetPage("start");
        }

        private void GoToParcelSendingPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            UserSendingParcelPage page = (UserSendingParcelPage)mainWindow.GetPage("userSendingParcel");
            page.Parcels = mainWindow.currentCustomer.ParcelFrom;
            mainWindow.Content = page;
        }
        private void GoToParcelRecievingPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            UserRecievingParcelPage page = (UserRecievingParcelPage)mainWindow.GetPage("userRecievingParcel");
            page.Parcels = mainWindow.currentCustomer.ParcelTo;
            mainWindow.Content = page;
        }
    }
}
