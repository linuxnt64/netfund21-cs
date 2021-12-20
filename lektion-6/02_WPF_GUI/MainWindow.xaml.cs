using _02_WPF_GUI.Handlers;
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

namespace _02_WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserManager userManager = new UserManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            userManager.CreateUser(new Models.User
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                Password = pbPassword.Password,
                AddressLine = tbAddressLine.Text,
                PostalCode = tbPostalCode.Text,
                City = tbCity.Text
            });

            ClearFormInputs();
            AddUsersToListView();

        }

        private void ClearFormInputs()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            pbPassword.Password = "";
            tbAddressLine.Text = "";
            tbPostalCode.Text = "";
            tbCity.Text = "";
        }

        private void AddUsersToListView()
        {
            var users = userManager.GetUsers();

            lvUsers.Items.Clear();

            foreach (var user in users)
                lvUsers.Items.Add(user);  
        }
    }
}
