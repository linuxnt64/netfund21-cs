using _02_LocalSqlStorage.Entities;
using _02_LocalSqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Interfaces
{
    public interface IProductSqlCommands
    {
        void SaveProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
    }
}
