using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3.Models
{
    internal class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        public Product(string name, string description, string category, decimal price, int quantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ShortDescription => (Description.Length > 20) ? Description.Substring(0, 20) : Description;
        
    }
}
