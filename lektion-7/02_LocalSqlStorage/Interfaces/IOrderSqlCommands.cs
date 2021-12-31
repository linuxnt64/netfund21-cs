using _02_LocalSqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Interfaces
{
    public interface IOrderSqlCommands
    {
        void SaveOrder(ShoppingCart shoppingCart);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
    }
}
