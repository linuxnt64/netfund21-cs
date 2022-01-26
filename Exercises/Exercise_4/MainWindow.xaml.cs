using Exercise_4.Models;
using Exercise_4.Services;
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

namespace Exercise_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IProductService productService;
        private string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\products.json";

        public MainWindow()
        {
            InitializeComponent();
            productService = new ProductService();
            GetItems();
           
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productService.Create(new Product(tbProductName.Text, tbProductDescription.Text, cbCategory.SelectedItem.ToString(), decimal.Parse(tbPrice.Text), int.Parse(tbQuantity.Text)));
                productService.SaveToFile(filePath);
                ClearFields();
                GetItems();
            }
            catch { }        
        }

        private void GetItems()
        {
            lvProducts.Items.Clear();   
            productService.ReadFromFile(filePath);

            var items = productService.List();
            if (items != null)
                foreach (var item in items)
                {
                    lvProducts.Items.Add(item);
                }
                    
        }

        private void ClearFields()
        {
            tbProductName.Text = string.Empty;
            tbProductDescription.Text = string.Empty;
            cbCategory.SelectedIndex = 0;
            tbPrice.Text = string.Empty;
            tbQuantity.Text = string.Empty;
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = ((ListView)sender).SelectedItem;
            var item = (Product)obj;

            tbProductName.Text = item.Name;
            tbProductDescription.Text = item.Description;
            cbCategory.SelectedItem = item.Category;
            tbPrice.Text = item.Price.ToString();
            tbQuantity.Text = item.Quantity.ToString();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (Product)obj.DataContext;

            productService.Remove(item.Id.ToString());
            productService.SaveToFile(filePath);
            GetItems();
        }
    }
}
