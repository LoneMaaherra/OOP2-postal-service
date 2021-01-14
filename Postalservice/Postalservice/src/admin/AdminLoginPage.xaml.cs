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
    /// Interaction logic for AdminLoginPage.xaml
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        private MainWindow mainWindow;

        public AdminLoginPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void LogInCommand_Execute(object value, ExecutedRoutedEventArgs e)
        {
            string PostOfficeName = LogInControl.TopTextBoxContent;
            string ZipCode = LogInControl.BottomTextBoxContent;

            if (!PostalOffice.OfficeExist(PostOfficeName, ZipCode)) 
            { 
                LogInControl.ErrorMessageVisibility = Visibility.Visible; 
                return; 
            }

            mainWindow.currentOffice = new PostalOffice(DBConnectionManger.GetOfficeId(PostOfficeName, ZipCode).ToString());
            LogInControl.Reset();
            mainWindow.Content = mainWindow.GetPage("officeHome");
            // @TODO: handle user specific data?
        }

        private void ReturnTrue_CanExecute(object value, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ReturnToLastPage_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            LogInControl.Reset();
            mainWindow.Content = mainWindow.GetPage("start");
        }
    }
}
