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
    /// Interaction logic for OfficeAddParcelPage.xaml
    /// </summary>
    public partial class OfficeAddParcelPage : Page
    {
        private MainWindow mainWindow;
        public OfficeAddParcelPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Ok_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Dictionary<string, string> ParcelToDict = new Dictionary<string, string>()
            {
                {"Name",TextBoxParcelToName.Text },
                {"Street",TextBoxParcelToStreet.Text },
                {"ZipCode",TextBoxParcelToZipCode.Text },
                {"City", TextBoxParcelToCity.Text },
                {"Country", TextBoxParcelToCountry.Text }              
            };

            Dictionary<string, string> ParcelFromDict = new Dictionary<string, string>()
            {
                {"Name",TextBoxParcelFromName.Text },
                {"Street",TextBoxParcelFromStreet.Text },
                {"ZipCode",TextBoxParcelFromZipCode.Text },
                {"City", TextBoxParcelFromCity.Text },
                {"Country", TextBoxParcelFromCountry.Text }
            };

            foreach (string entry in ParcelToDict.Values)
            {
                if (string.IsNullOrEmpty(entry))
                {
                    TextBlockErrorMessage.Visibility = Visibility.Visible;
                    return;
                }
            }

            foreach (string entry in ParcelFromDict.Values)
            {
                if (string.IsNullOrEmpty(entry))
                {
                    TextBlockErrorMessage.Visibility = Visibility.Visible;
                    return;
                }
            }

            Parcel newParcel = new Parcel(ParcelToDict, ParcelFromDict);
            ClearAllFields();
            mainWindow.Content = mainWindow.GetPage("managePackages");


        }

        private void Cancel_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ClearAllFields();
            mainWindow.Content = mainWindow.GetPage("managePackages");
        }

        private void ReturnTrue_CanExecute(object value, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ReturnToLastPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("managePackages");
        }

        private void ReturnToHomePage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("officeHome");
        }

        private void ReturnToStartPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ClearAllFields();
            mainWindow.Content = mainWindow.GetPage("start");
        }

        private void ClearAllFields()
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
        }
    }
}
