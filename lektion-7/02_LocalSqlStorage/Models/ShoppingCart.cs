using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Models
{
    public class ShoppingCart
    {
        public int CustomerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

    }
}
