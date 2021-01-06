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
        private Page userRecievingParcel;

        public MainWindow()
        {
            startPage = new StartPage(this);
            adminLogin = new AdminLoginPage(this);
            customerLogin = new CustomerLoginPage(this);
            createUser = new NewUserPage(this);
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
                case "userPage":
                    return startPage;
                case "createUser":
                    return createUser;
                case "userRecievingParcel":
                    return userRecievingParcel;
                default:
                    return startPage;
            }
        }
    }
}
