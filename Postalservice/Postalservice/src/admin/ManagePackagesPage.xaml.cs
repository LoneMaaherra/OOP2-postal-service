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
    /// Interaction logic for ManagePackagesPage.xaml
    /// </summary>
    public partial class ManagePackagesPage : Page
    {
        private MainWindow mainWindow;

        public List<Parcel> Parcels
        {
            get { return (List<Parcel>)this.GetValue(ParcelsProperty); }
            set { this.SetValue(ParcelsProperty, value); }
        }

        public static readonly DependencyProperty ParcelsProperty = DependencyProperty.Register(
           "Parcels", typeof(List<Parcel>), typeof(ManagePackagesPage), new PropertyMetadata());

        public ManagePackagesPage(MainWindow mainWindow)
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
