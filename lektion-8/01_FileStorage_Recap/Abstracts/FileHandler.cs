using _01_FileStorage_Recap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage_Recap.Abstracts
{
    public abstract class FileHandler
    {
        protected List<Customer> _customers = new List<Customer>();
        protected string _filePath;

        public virtual void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public virtual IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public abstract void ReadFromFile();
        public abstract void WriteToFile();
    }
}
