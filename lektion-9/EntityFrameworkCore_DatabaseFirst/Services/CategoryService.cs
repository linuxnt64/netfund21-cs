using EntityFrameworkCore_DatabaseFirst.Data;
using EntityFrameworkCore_DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_DatabaseFirst.Services
{
    internal interface ICategoryService
    {
        void Create(string name);
        Category Get(int id);
        Category GetByName(string name);
        IEnumerable<Category> GetAll();
    }

    internal class CategoryService : ICategoryService
    {
        private readonly SqlContext _context = new SqlContext();

        public void Create(string name)
        {
            var _category = _context.Categories.Where(x => x.Name == name).FirstOrDefault();

            if(_category == null)
            {
                _context.Categories.Add(new Category { Name = name });
                _context.SaveChanges();
            }
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetByName(string name)
        {
            return _context.Categories.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
