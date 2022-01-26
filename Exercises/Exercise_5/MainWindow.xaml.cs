using Exercise_5.Models;
using Exercise_5.Services;
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

namespace Exercise_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICaseService caseService;

        public MainWindow()
        {
            InitializeComponent();
            caseService = new CaseService();
            PopulateCustomers();
            PopulateListView();
        }


        private void ClearFields()
        {
            tbTitle.Text = String.Empty;
            tbDescription.Text = String.Empty;
            cbCustomers.SelectedIndex = 0;
        }

        private void PopulateCustomers()
        {
            var items = caseService.GetAllCustomers();
            if (items != null)
                foreach (var item in items)
                    cbCustomers.Items.Add(item.Id);
        }

        private void PopulateListView()
        {
            lvCases.Items.Clear();

            var items = caseService.GetAllCases();
            if (items != null)
                foreach (var item in items)
                    lvCases.Items.Add(item);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            caseService.CreateCase(new Case(int.Parse(cbCustomers.SelectedValue.ToString()), 1, tbTitle.Text, tbDescription.Text));
            ClearFields();
            PopulateListView();
        }
    }
}
