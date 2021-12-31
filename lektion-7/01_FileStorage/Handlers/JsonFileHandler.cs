using _01_FileStorage.Interfaces;
using _01_FileStorage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage.Handlers
{
    public interface IJsonFileHandler : IFileManagement
    {

    }

    public class JsonFileHandler : IJsonFileHandler
    {
        private List<Customer> Customers { get; set; } = new List<Customer>();

        public void AddToList(Customer customer)
        {
            Customers.Add(customer);
        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }

        public void ReadFromFile()
        {
            using (var sr = new StreamReader(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.json"))
            {
                Customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
            }
        }

        public void SaveToFile()
        {
            using (var sw = new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\customer-list.json"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Customers));
            }
        }
    }
}
