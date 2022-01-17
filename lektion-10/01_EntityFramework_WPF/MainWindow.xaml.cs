using _00_EntityFramework_ClassLibrary.Models;
using _00_EntityFramework_ClassLibrary.Services;
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

namespace _01_EntityFramework_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserService userService = new UserService(); 

        public MainWindow()
        {
            InitializeComponent();
            PopulateListView();
            ClearTextBoxes();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var user = new User(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbStreetName.Text, tbPostalCode.Text, tbCity.Text);
            
            userService.Create(user);
            PopulateListView();
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbStreetName.Text = "";
            tbPostalCode.Text = "";
            tbCity.Text = "";

            tbFirstName.Focus();
        }

        private void PopulateListView()
        {
            var users = userService.GetAll();
            if(users.Any())
            {
                lvUserList.Items.Clear();
                foreach(var user in users)
                    lvUserList.Items.Add(user);
            }
                
        }
    }
}
