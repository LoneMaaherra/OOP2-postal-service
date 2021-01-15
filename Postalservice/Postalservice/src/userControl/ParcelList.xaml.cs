using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Postalservice.src.userControl
{
   
    /// <summary>
    /// Interaction logic for ParcelList.xaml
    /// </summary>
    public partial class ParcelList : UserControl
    {
        public ItemCollection Items
        {
            get { return MyListBox.Items; }
        }

        public object SelectedItem
        {
            get { return MyListBox.SelectedItem; }
            set { MyListBox.SelectedItem = value; }
        }

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
            "Parcels", typeof(List<Parcel>), typeof(ParcelList), new PropertyMetadata());

        public delegate void PropertyChanged_Delegate(object sender);

        /// <summary>
        /// Delegate handler for ParcelList item selected.
        /// </summary>
        public PropertyChanged_Delegate PropertyChanged
        {
            get { return (PropertyChanged_Delegate)this.GetValue(PropertyChangedProperty); }
            set { this.SetValue(PropertyChangedProperty, value); }
        }

        /// <summary>
        /// Dependency register for the PropertyChanged property.
        /// </summary>
        public static readonly DependencyProperty PropertyChangedProperty = DependencyProperty.Register(
            "PropertyChanged", typeof(PropertyChanged_Delegate), typeof(ParcelList), new PropertyMetadata());

        public ParcelList()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender);
        }
    }
}