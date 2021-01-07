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

        public List<Parcel> Parcels
        {
            get { return (List<Parcel>)this.GetValue(ParcelsProperty); }
            set { this.SetValue(ParcelsProperty, value); }

        }
        /// <summary>
        /// Dependency register for the Parcels property.
        /// </summary>
        public static readonly DependencyProperty ParcelsProperty = DependencyProperty.Register(
            "Parcels", typeof(List<Parcel>), typeof(UserSendingParcelPage), new PropertyMetadata());
        public UserSendingParcelPage(MainWindow mainWindow)
        {
            Parcels = new List<Parcel>();
            Parcels.Add(new Parcel()
            {
                ShipmentId = "42",
                AddressFrom = new Address() { Street = "Gatan", City = "Linköping", Country = "Swe", Name = "Test", ZipCode = "121212" },
                AddressTo = new Address() { Street = "Siffergatan", City = "Nummerköping", Country = "Tolvan", Name = "Tolvan Tolvansson", ZipCode = "212121" },
                TransferHistory = new List<Transport>() { new Transport() { Arrival = DateTime.Now, Departure = DateTime.Now,
                FromPO = new PostalOffice() { Name = "Ica", ZipCode= "121212" }, ToPO = new PostalOffice(){Name = "Coop", ZipCode = "212121" } } }
            });
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        public void ParcelClicked_eventHandler(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
