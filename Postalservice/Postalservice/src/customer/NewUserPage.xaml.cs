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

namespace Postalservice.src.customer
{
    /// <summary>
    /// Interaction logic for NewUserPage.xaml
    /// </summary>
    public partial class NewUserPage : Page
    {
        private MainWindow mainWindow;
        public NewUserPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Ok_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Dictionary<string, string> CustomerDict = new Dictionary<string, string>()
            {
                {"Id",TextBoxSsn.Text },
                {"Name",TextBoxName.Text },
                {"MobileNumber",TextBoxMobileNumber.Text },
                {"Street", TextBoxStreet.Text },
                {"ZipCode", TextBoxZipCode.Text },
                {"City", TextBoxCity.Text },
                {"Country", TextBoxCountry.Text }
            };

            foreach(string entry in CustomerDict.Values)
            {
                if (string.IsNullOrEmpty(entry))
                {
                    TextBlockErrorMessage.Visibility = Visibility.Visible;
                    return;
                }
            }


            if (Customer.CustomerExist(CustomerDict["Id"]))
            {
                TextBlockErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            Customer newCustomer = new Customer(CustomerDict);

            mainWindow.Content = mainWindow.GetPage("customerLogin");
        }

        private void Cancel_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (object c in GridForm.Children)
            {
                if (c.GetType().Equals(typeof(TextBox)))
                {
                    TextBox t = (TextBox)c;
                    t.Text = null;
                }
                else if (c.GetType().Equals(typeof(PasswordBox)))
                {
                    PasswordBox t = (PasswordBox)c;
                    t.Password = null;
                }
            }
            mainWindow.Content = mainWindow.GetPage("customerLogin");
        }

        private void ReturnTrue_CanExecute(object value, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ReturnToLastPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("customerLogin");
        }

        private void ReturnToHomePage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("start");
        }
    }
}
