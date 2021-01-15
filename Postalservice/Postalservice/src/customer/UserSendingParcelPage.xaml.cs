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
    /// Interaction logic for UserSendingParcelPage.xaml
    /// </summary>
    public partial class UserSendingParcelPage : Page
    {
        private MainWindow mainWindow;

        public UserSendingParcelPage(MainWindow mainWindow)
        {           
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void ParcelList_PropertyChanged(object sender)
        {
            ListBox lBox = (ListBox)sender;
            
            Parcel p = (Parcel)lBox.SelectedItem;
            MyParcelInfo.Parcel = p;
            MyParcelInfo.DataContext = p;
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
        private void ReturnToUserHomePage_Execute(object sender, ExecutedRoutedEventArgs e)
        {          
            mainWindow.Content = mainWindow.GetPage("userHomePage");
        }

        public void RefreshPage()
        {
            MyParcelList.Parcels = mainWindow.currentCustomer.ParcelFrom;
            MyParcelList.Items.Refresh();
        }
    }
}
