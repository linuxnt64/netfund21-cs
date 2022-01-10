using EntityFrameworkCore_DatabaseFirst.Data;
using EntityFrameworkCore_DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_DatabaseFirst.Services
{
    internal interface IProductService
    {
        void Create(string name, string description, decimal price, int categoryId);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }

    internal class ProductService : IProductService
    {
        private readonly SqlContext _context = new SqlContext();


        public void Create(string name, string description, decimal price, int categoryId)
        {
            var _product = _context.Products.Where(x => x.Name == name).FirstOrDefault();

            if (_product == null)
            {
                _context.Products.Add(new Product
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    CategoryId = categoryId
                });
                _context.SaveChanges();
            }
        }

        public Product Get(int id)
        {
            return _context.Products.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(x => x.Category);
        }
    }
}
