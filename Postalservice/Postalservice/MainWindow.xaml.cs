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
using Postalservice.src;
using Postalservice.src.admin;
using Postalservice.src.customer;
using Postalservice.src.api;

namespace Postalservice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object content;
        private Page startPage;
        private Page adminLogin;
        private Page customerLogin;
        private Page createUser;
        private Page userHomePage;
        private Page userSendingParcel;
        private Page userRecievingParcel;
        

        public Customer currentCustomer
        {
            get { return (Customer)this.GetValue(currentCustomerProperty); }
            set { this.SetValue(currentCustomerProperty, value); }
        }
        /// <summary>
        /// Dependency register for the currentCustomer property.
        /// </summary>
        public static readonly DependencyProperty currentCustomerProperty = DependencyProperty.Register(
            "currentCustomer", typeof(Customer), typeof(Window), new PropertyMetadata());

        public MainWindow()
        {
            currentCustomer = new Customer("891031");
            startPage = new StartPage(this);
            adminLogin = new AdminLoginPage(this);
            customerLogin = new CustomerLoginPage(this);
            createUser = new NewUserPage(this);
            userHomePage = new UserHomePage(this);
            userSendingParcel = new UserSendingParcelPage(this);
            userRecievingParcel = new UserRecievingParcelPage(this);            

            InitializeComponent();

            content = Content;

            OpenStartPage();

            //DBTest.Start();
        }

        public void OpenStartPage()
        {
            //StartPage startpage = new StartPage(this);
            this.Content = startPage;
        }

        public Page GetPage(string page)
        {
            switch (page)
            {
                case "start":
                    return startPage;
                case "adminLogin":
                    return adminLogin;
                case "customerLogin":
                    return customerLogin;
                case "adminPage":
                    return startPage;
                case "createUser":
                    return createUser;
                case "userHomePage":
                    return userHomePage;
                case "userSendingParcel":
                    return userSendingParcel;
                case "userRecievingParcel":
                    return userRecievingParcel;
                default:
                    return startPage;
            }
        }
    }
}
