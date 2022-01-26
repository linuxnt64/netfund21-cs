using Exercise_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3.Services
{
    internal interface IMenuService
    {
        void Create();
        void List();
        void Details();
        void Remove();
        void SaveToFile(string fileName);
        void ReadFromFile(string fileName);
    }

    internal class MenuService : IMenuService
    {
        private readonly IProductService _productService = new ProductService();


        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Create Product");
            Console.WriteLine("----------------------------");

            var product = new Product();
            Console.Write("Product Name: ");
            product.Name = Console.ReadLine();
            Console.Write("Product Description: ");
            product.Description = Console.ReadLine();
            Console.Write("Product Category: ");
            product.Category = Console.ReadLine();
            Console.Write("Product Price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Quantity: ");
            product.Quantity = int.Parse(Console.ReadLine());

            _productService.Create(product);
        }

        public void Details()
        {
            Console.Clear();
            Console.Write("Specify Product Id: ");
            var id = Console.ReadLine();

            var product = _productService.Details(id);

            Console.Clear();
            Console.WriteLine($"Details for Product {product.Id}");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Product Name: {product.Name}");
            Console.WriteLine($"Category: {product.Category}");
            Console.WriteLine($"Price: {product.Price}:-");
            Console.WriteLine($"Items in Stock: {product.Quantity}");
            Console.WriteLine($"Product Description: {product.Description}");

            Console.ReadKey();
        }

        public void List()
        {
            Console.Clear();
            Console.WriteLine("Product Catalog");
            Console.WriteLine("----------------------------");
            foreach (var product in _productService.List())
            {
                if(product.Description.Length > 20)
                    Console.WriteLine($"{product.Id} \t {product.Name} \t {product.Description.Substring(0, 20)}...");
                else
                    Console.WriteLine($"{product.Id} \t {product.Name} \t {product.Description}");
            }
                

            Console.ReadKey();
        }

        public void ReadFromFile(string fileName)
        {
            _productService.ReadFromFile(fileName);
        }

        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("Remove Product");
            Console.WriteLine("----------------------------");
            Console.Write("Specify Product Id: ");
            var id = Console.ReadLine();

            _productService.Remove(id);

        }

        public void SaveToFile(string fileName)
        {
            Console.Clear();
            Console.WriteLine("Save to File");
            Console.WriteLine("----------------------------");

            _productService.SaveToFile(fileName);
        }
    }
}
