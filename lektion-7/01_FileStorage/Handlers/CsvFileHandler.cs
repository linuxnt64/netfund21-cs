using _01_FileStorage.Interfaces;
using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{

    public interface ICsvFileHandler : IFileManagement
    {

    }


    public class CsvFileHandler : ICsvFileHandler
    {
        private List<Customer> Customers { get; set; } = new List<Customer>();

        public void AddToList(Customer customer)
        {
            Customers.Add(customer);
        }

        public List<Customer> GetCustomers()
        {
            return Customers.OrderByDescending(x => x.Id).ToList();
        }

        public void ReadFromFile()
        {
            using (var sr = new StreamReader(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.csv"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(";");
                    Customers.Add(new Customer
                    {
                        Id = int.Parse(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        Email = values[3]
                    });
                }
            }
        }

        public void SaveToFile()
        {
            using (var sw = new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.csv"))
            {
                foreach (var customer in Customers)
                    sw.WriteLine($"{customer.Id};{customer.FirstName};{customer.LastName};{customer.Email}");
            }
        }
    }
}
