using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using Postalservice.src;
using Postalservice.src.api;

namespace Postalservice.src.customer
{
    /// <summary>
    /// Interaction logic for CustomerLoginPage.xaml
    /// </summary>
    public partial class CustomerLoginPage : Page
    {
        private MainWindow mainWindow;

        public CustomerLoginPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void LogInCommand_CanExecute(object value, CanExecuteRoutedEventArgs e)
        {
            if (LogInControl.TopTextBoxContent != null)
            {
                SecureString pword = LogInControl.GetPassword();
                //string spword = CustomCommands.SecureStringToString(pword);
                if (pword.Length > 5) 
                    e.CanExecute = true;
            }
        }

        private void LogInCommand_Execute(object value, ExecutedRoutedEventArgs e)
        {
            string UserId = LogInControl.TopTextBoxContent;
            if (!Customer.CustomerExist(UserId)) { LogInControl.ErrorMessageVisibility = Visibility.Visible; return; }
            DBConnectionManger.GetCustomer(LogInControl.TopTextBoxContent);
            mainWindow.Content = mainWindow.GetPage("userPage");
            // @TODO: handle user specific data?
        }

        private void BtnCreateNewUser_Execute(object value, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("createUser");
        }

        private void ReturnTrue_CanExecute(object value, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ReturnToLastPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("start");
        }

    }
}
