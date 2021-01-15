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
    /// Interaction logic for OfficeTransportPage.xaml
    /// </summary>
    public partial class OfficeTransportPage : Page
    {
        private MainWindow mainWindow;

        /// <summary>
        /// List of vehicles for OfficeTransportPage ListBox ItemsSource.
        /// </summary>
        public List<Transport> Transports
        {
            get { return (List<Transport>)this.GetValue(TransportsProperty); }
            set { this.SetValue(TransportsProperty, value); }
        }

        /// <summary>
        /// Dependency register for the Transports property.
        /// </summary>
        public static readonly DependencyProperty TransportsProperty = DependencyProperty.Register(
            "Transports", typeof(List<Transport>), typeof(OfficeTransportPage), new PropertyMetadata());

        /// <summary>
        /// List of vehicles for Parcel ListBox ItemsSource.
        /// </summary>
        public List<Parcel> Parcels
        {
            get { return (List<Parcel>)this.GetValue(ParcelsProperty); }
            set { this.SetValue(ParcelsProperty, value); }

        }
        /// <summary>
        /// Dependency register for the Parcels property.
        /// </summary>
        public static readonly DependencyProperty ParcelsProperty = DependencyProperty.Register(
            "Parcels", typeof(List<Parcel>), typeof(OfficeTransportPage), new PropertyMetadata());

        /// <summary>
        /// List of vehicles for Offices ListBox ItemsSource.
        /// </summary>
        public List<PostalOffice> Offices
        {
            get { return (List<PostalOffice>)this.GetValue(OfficesProperty); }
            set { this.SetValue(OfficesProperty, value); }

        }
        /// <summary>
        /// Dependency register for the Offices property.
        /// </summary>
        public static readonly DependencyProperty OfficesProperty = DependencyProperty.Register(
            "Offices", typeof(List<PostalOffice>), typeof(OfficeTransportPage), new PropertyMetadata());

        /// <summary>
        /// List of vehicles for Office transports ListBox ItemsSource.
        /// </summary>
        public List<Vehicle> Vehicles
        {
            get { return (List<Vehicle>)this.GetValue(VehiclesProperty); }
            set { this.SetValue(VehiclesProperty, value); }
        }

        /// <summary>
        /// Dependency register for the Vehicles property.
        /// </summary>
        public static readonly DependencyProperty VehiclesProperty = DependencyProperty.Register(
            "Vehicles", typeof(List<Vehicle>), typeof(OfficeTransportPage), new PropertyMetadata());

        public OfficeTransportPage(MainWindow mainWindow)
        {
            Parcels = new List<Parcel>();
            Offices = new List<PostalOffice>();
            Vehicles = new List<Vehicle>();
            Transports = new List<Transport>();
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

        #region Tab buttons
        private void ManageTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ManageTab.Visibility = Visibility.Visible;
            AddTab.Visibility = Visibility.Hidden;
            PackTab.Visibility = Visibility.Hidden;

            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        
        private void AddTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddTab.Visibility = Visibility.Visible;
            ManageTab.Visibility = Visibility.Hidden;
            PackTab.Visibility = Visibility.Hidden;

            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void PackTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            PackTab.Visibility = Visibility.Visible;
            ManageTab.Visibility = Visibility.Hidden;
            AddTab.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        #region Manage buttons
        private void Arrival_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void Depart_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        #region Add buttons
        private void Ok_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Vehicle v = (Vehicle)ComboBoxVehicle.SelectedItem;
            PostalOffice pO = (PostalOffice)ComboBoxToPO.SelectedItem;
            DateTime prelDate = DateTime.Now;
            if(pO == null || v == null || String.IsNullOrEmpty(TextBoxPrelDeparture.Text))
            {
                TextBlockError.Visibility = Visibility.Visible;
                return;
            }
            
            try
            {
                prelDate = DateTime.Parse(TextBoxPrelDeparture.Text);
            }
            catch
            {
                TextBlockError.Visibility = Visibility.Visible;
                return;
            }

            Transport transport = new Transport(v.RegNr, Int32.Parse(pO.Id), Int32.Parse(mainWindow.currentOffice.Id), null, null, prelDate);
            
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void Cancel_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        #region Pack buttons
        private void ClearStorageFilter_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void PackAll_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void ClearFilter_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        private void UnpackAll_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            mainWindow.Content = mainWindow.GetPage("manageTransports");
        }
        #endregion

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lBox = (ListBox)sender;

            Transport t = (Transport)lBox.SelectedItem;
            TransportInfoViewer.DataContext = t;

            Parcels.Clear();
            if (t == null) return;
            foreach (int parcel in DBConnectionManger.GetParcelsInTransport(Int32.Parse(t.Id)))
            {
                Parcels.Add(new Parcel(parcel.ToString()));
            }
        }

        public void LoadVehicles()
        {
            Vehicles.Clear();
            foreach (string v in DBConnectionManger.GetVehiclesAtPO(mainWindow.currentOffice.Id))
            {
                Vehicles.Add(new Vehicle(v));
            }
        }

        public void LoadOffices()
        {
            Offices.Clear();
            foreach (int id in DBConnectionManger.GetAllPostOffices())
            {
                Offices.Add(new PostalOffice(id.ToString()));
            }
        }

        public void LoadTransports()
        {
            Transports.Clear();
            foreach (int id in DBConnectionManger.GetTransportsFromPO(Int32.Parse(mainWindow.currentOffice.Id)))
            {
                Transports.Add(new Transport(id.ToString()));
            }
            foreach (int id in DBConnectionManger.GetTransportsToPO(Int32.Parse(mainWindow.currentOffice.Id)))
            {
                Transports.Add(new Transport(id.ToString()));
            }
        }

        public void ClearAddFields()
        {
            TextBoxPrelDeparture.Text = "";

        }

        public void RefreshPage()
        {
            
            LoadVehicles();
            ComboBoxVehicle.Items.Refresh();
            LoadOffices();
            ComboBoxToPO.Items.Refresh();
            LoadTransports();
            MyListBox.Items.Refresh();
        }
    }
}
