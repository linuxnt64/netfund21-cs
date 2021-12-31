using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Interfaces
{
    public interface IFileManagement
    {
        void SaveToFile();
        void ReadFromFile();
        void AddToList(Customer customer);
        List<Customer> GetCustomers();

    }
}
