using _03_SqlStorage_Shared.Handlers;
using _03_SqlStorage_Shared.Models;
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

namespace _03_SqlStorage_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerHandler customerHandler = new CustomerHandler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var customerId = customerHandler.Create(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbAddressLine.Text, tbPostalCode.Text, tbCity.Text);
            var customerId2 = customerHandler.Create(new Customer { 
                FirstName = tbFirstName.Text, 
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                AddressLine = tbAddressLine.Text,
                PostalCode = tbPostalCode.Text,
                City = tbCity.Text
            });


            if (customerId > 0)
                ClearFields();

        }

        private void ClearFields()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbAddressLine.Text = "";
            tbPostalCode.Text = "";
            tbCity.Text = "";
        }
    }
}
