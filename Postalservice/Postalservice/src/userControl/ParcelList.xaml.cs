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

namespace Postalservice.src.userControl
{
   
    /// <summary>
    /// Interaction logic for ParcelList.xaml
    /// </summary>
    public partial class ParcelList : UserControl
    {
        /// <summary>
        /// Delegate handler for ParcelList item selected.
        /// </summary>
        public object SelectedItem
        {
            get { return (object)this.GetValue(SelectedItemProperty); }
            set { this.SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Dependency register for the SelectedItem property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(ParcelList), new PropertyMetadata());

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