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
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        /// <summary>
        /// Command for Header back button.
        /// </summary>
        public ICommand BackCommand
        {
            get { return (ICommand)this.GetValue(BackCommandProperty); }
            set { this.SetValue(BackCommandProperty, value); }
        }
        /// <summary>
        /// Dependency register for BackCommand property.
        /// </summary>
        public static readonly DependencyProperty BackCommandProperty = DependencyProperty.Register(
            "BackCommand", typeof(ICommand), typeof(Header), new PropertyMetadata());

        /// <summary>
        /// Command for Header home button.
        /// </summary>
        public ICommand HomeCommand
        {
            get { return (ICommand)this.GetValue(HomeCommandProperty); }
            set { this.SetValue(HomeCommandProperty, value); }
        }
        /// <summary>
        /// Dependency register for HomeCommand property.
        /// </summary>
        public static readonly DependencyProperty HomeCommandProperty = DependencyProperty.Register(
            "HomeCommand", typeof(ICommand), typeof(Header), new PropertyMetadata());

        /// <summary>
        /// Command for Header home button.
        /// </summary>
        public ICommand ExitCommand
        {
            get { return (ICommand)this.GetValue(ExitCommandProperty); }
            set { this.SetValue(ExitCommandProperty, value); }
        }
        /// <summary>
        /// Dependency register for HomeCommand property.
        /// </summary>
        public static readonly DependencyProperty ExitCommandProperty = DependencyProperty.Register(
            "ExitCommand", typeof(ICommand), typeof(Header), new PropertyMetadata());

        /// <summary>
        /// Visibility property of Header back button.
        /// </summary>
        public Visibility BackButtonVisibility
        {
            get { return (Visibility)this.GetValue(BackButtonVisibilityProperty); }
            set { this.SetValue(BackButtonVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for BackButtonVisibility property.
        /// </summary>
        public static readonly DependencyProperty BackButtonVisibilityProperty = DependencyProperty.Register(
            "BackButtonVisibility", typeof(Visibility), typeof(Header), new PropertyMetadata());

        /// <summary>
        /// Visibility property of Header home button.
        /// </summary>
        public Visibility HomeButtonVisibility
        {
            get { return (Visibility)this.GetValue(HomeButtonVisibilityProperty); }
            set { this.SetValue(HomeButtonVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for BackButtonVisibility property.
        /// </summary>
        public static readonly DependencyProperty HomeButtonVisibilityProperty = DependencyProperty.Register(
            "HomeButtonVisibility", typeof(Visibility), typeof(Header), new PropertyMetadata());

        /// <summary>
        /// Visibility property of Header exit button.
        /// </summary>
        public Visibility ExitButtonVisibility
        {
            get { return (Visibility)this.GetValue(ExitButtonVisibilityProperty); }
            set { this.SetValue(ExitButtonVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for BackButtonVisibility property.
        /// </summary>
        public static readonly DependencyProperty ExitButtonVisibilityProperty = DependencyProperty.Register(
            "ExitButtonVisibility", typeof(Visibility), typeof(Header), new PropertyMetadata());

        public Header()
        {
            InitializeComponent();
        }
    }
}
