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
        public Delegate ItemClickedCommand
        {
            get { return (Delegate)this.GetValue(ItemClickedCommandProperty); }
            set { this.SetValue(ItemClickedCommandProperty, value); }
        }
        /// <summary>
        /// Dependency register for the ItemClickedCommand property.
        /// </summary>
        public static readonly DependencyProperty ItemClickedCommandProperty = DependencyProperty.Register(
            "ItemClickedCommand", typeof(Delegate), typeof(LogIn), new PropertyMetadata());

        public ParcelList()
        {
            InitializeComponent();
        }
    }
}
