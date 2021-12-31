using _02_LocalSqlStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Interfaces
{
    public interface ICustomerSqlCommands
    {
        void SaveCustomer(Customer customer, string password);
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();
    }
}
