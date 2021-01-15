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
    /// Interaction logic for OfficeVehiclePage.xaml
    /// </summary>
    public partial class OfficeVehiclePage : Page
    {
        private MainWindow mainWindow;

        /// <summary>
        /// List of vehicles for OfficeVehiclePage ListBox ItemsSource.
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
            "Vehicles", typeof(List<Vehicle>), typeof(OfficeVehiclePage), new PropertyMetadata());

        /// <summary>
        /// List of vehicle types for OfficeVehiclePage Add vehicle combobox ItemsSource.
        /// </summary>
        public List<VehicleType> VehicleTypes
        {
            get { return (List<VehicleType>)this.GetValue(VehicleTypesProperty); }
            set { this.SetValue(VehicleTypesProperty, value); }
        }

        /// <summary>
        /// Dependency register for the VehicleTypes property.
        /// </summary>
        public static readonly DependencyProperty VehicleTypesProperty = DependencyProperty.Register(
            "VehicleTypes", typeof(List<VehicleType>), typeof(OfficeVehiclePage), new PropertyMetadata());

        public OfficeVehiclePage(MainWindow mainWindow)
        {
            VehicleTypes = new List<VehicleType>();
            Vehicles = new List<Vehicle>();
            foreach(int i in Enum.GetValues(typeof(VehicleType)))
            {
                VehicleTypes.Add((VehicleType)i);
            }
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

        private void Ok_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            int mWeigth = -1;
            int mVolume = -1;

            if (string.IsNullOrEmpty(TextBoxRegNr.Text))
            {
                TextBlockErrorMessage.Text = "Please specify a registration number.";
                TextBlockErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (ComboBoxVehicleType.SelectedItem == null)
            {
                TextBlockErrorMessage.Text = "Please select a vehicle type.";
                TextBlockErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            if (string.IsNullOrEmpty(TextBoxMaxWeight.Text))
            {
                TextBlockErrorMessage.Text = "Please specify max weight.";
                TextBlockErrorMessage.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                if (!Int32.TryParse(TextBoxMaxWeight.Text, out mWeigth))
                {
                    TextBlockErrorMessage.Text = "Please specify max weight in numbers.";
                    TextBlockErrorMessage.Visibility = Visibility.Visible;
                    return;
                }
            }

            if (string.IsNullOrEmpty(TextBoxMaxVolume.Text))
            {
                TextBlockErrorMessage.Text = "Please specify max volume.";
                TextBlockErrorMessage.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                if (!Int32.TryParse(TextBoxMaxVolume.Text, out mVolume))
                {
                    TextBlockErrorMessage.Text = "Please specify max volume in numbers.";
                    TextBlockErrorMessage.Visibility = Visibility.Visible;
                    return;
                }
            }

            new Vehicle(TextBoxRegNr.Text, (VehicleType)ComboBoxVehicleType.SelectedItem, mWeigth, mVolume, VehicleStatus.Parked, mainWindow.currentOffice);
            ClearAllFileds();
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }
        private void Cancel_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            ClearAllFileds();
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }

        private void VehiclesTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            VehiclesTab.Visibility = Visibility.Visible;
            AddVehicleTab.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }

        private void AddTab_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            AddVehicleTab.Visibility = Visibility.Visible;
            VehiclesTab.Visibility = Visibility.Hidden;
            mainWindow.Content = mainWindow.GetPage("manageVehicles");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lBox = (ListBox)sender;

            Vehicle v = (Vehicle)lBox.SelectedItem;
            VehicleInfoViewer.DataContext = v;
        }

        public void ClearAllFileds()
        {
            ComboBoxVehicleType.SelectedItem = null;
            ComboBoxVehicleType.Text = ComboBoxVehicleType.Tag.ToString();
            TextBoxMaxWeight.Text = "";
            TextBoxMaxVolume.Text = "";
            TextBoxRegNr.Text = "";
            TextBlockErrorMessage.Visibility = Visibility.Hidden;
        }

        public void LoadVehicles()
        {
            Vehicles.Clear();
            foreach (string regNr in DBConnectionManger.GetAllVehicles())
            {
                Vehicles.Add(new Vehicle(regNr));
            }
        }
        

        public void RefreshPage()
        {
            LoadVehicles();
            MyListBox.Items.Refresh();
        }
    }
}
