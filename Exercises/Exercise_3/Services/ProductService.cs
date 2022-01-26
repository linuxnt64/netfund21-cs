using Exercise_3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3.Services
{
    internal interface IProductService
    {
        void Create(Product product);
        IEnumerable<Product> List();
        Product Details(string id);
        void Remove(string id);
        void SaveToFile(string fileName);
        void ReadFromFile(string fileName);
    }


    internal class ProductService : IProductService
    {
        private List<Product> Products = new List<Product>();

        public void Create(Product product)
        {
            Products.Add(product);
        }

        public Product Details(string id)
        {
            return Products.FirstOrDefault(x => x.Id == Guid.Parse(id));
        }

        public IEnumerable<Product> List()
        {
            return Products;
        }

        public void Remove(string id)
        {
            Products = Products.Where(x => x.Id != Guid.Parse(id)).ToList();
        }

        public void SaveToFile(string fileName)
        {
            using (var sw = new StreamWriter(fileName))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Products));
            }
        }

        public void ReadFromFile(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    var json = sr.ReadToEnd();
                    Products = JsonConvert.DeserializeObject<List<Product>>(json);
                }
            }
            catch { }
        }
    }
}
