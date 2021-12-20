using _03_UWP_GUI.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _03_UWP_GUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IUserManager userManager = new UserManager();

        public MainPage()
        {
            this.InitializeComponent();
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
