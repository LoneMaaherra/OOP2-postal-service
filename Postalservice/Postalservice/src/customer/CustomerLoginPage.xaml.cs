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
    /// Interaction logic for CustomerLoginPage.xaml
    /// </summary>
    public partial class CustomerLoginPage : Page
    {
        private MainWindow mainWindow;
        public ICommand NewUserBtnClicked { get; set; }

        public CustomerLoginPage(MainWindow mainWindow)
        {
            NewUserBtnClicked = new RelayCommand(BtnCreateNewUser, ReturnTrue);
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void BtnCreateNewUser(object value)
        {
            Console.WriteLine("HALLLÅ!! <-----------------");
            ReturnToLastPage(null, null);
        }

        private bool ReturnTrue(object value)
        {
            return true;
        }

        private void ReturnToLastPage(object sender, RoutedEventArgs e)
        {
            
            mainWindow.Content = mainWindow.GetPage("start");

        }

    }
}
