using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalPrice { get; set; } 

        public Customer Customer { get; set; } = new Customer();
        public ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
    }
}
