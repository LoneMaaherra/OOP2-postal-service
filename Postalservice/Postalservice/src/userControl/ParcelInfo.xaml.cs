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

namespace Postalservice.src.userControl
{
    /// <summary>
    /// Interaction logic for ParcelInfo.xaml
    /// </summary>
    public partial class ParcelInfo : UserControl
    {
        /// <summary>
        /// Delegate handler for ParcelList item selected.
        /// </summary>
        public Parcel Parcel
        {
            get { return (Parcel)this.GetValue(ParcelProperty); }
            set { this.SetValue(ParcelProperty, value); }
        }

        /// <summary>
        /// Dependency register for the Parcel property.
        /// </summary>
        public static readonly DependencyProperty ParcelProperty = DependencyProperty.Register(
            "Parcel", 
            typeof(Parcel), 
            typeof(ParcelList), 
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public ParcelInfo()
        {
            InitializeComponent();
        }
    }
}
