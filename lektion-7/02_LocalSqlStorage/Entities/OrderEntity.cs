using _02_LocalSqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);
        public decimal VAT { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;

        public CustomerEntity Customer { get; set; }
        public ICollection<OrderRowEntity> OrderRows { get; set; }
    }
}
