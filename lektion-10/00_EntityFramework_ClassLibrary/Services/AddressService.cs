using _00_EntityFramework_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFramework_ClassLibrary.Services
{
    public class AddressService
    {
        private SqlContext _context = new SqlContext();

        public Address Create(Address address)
        {
            var _address = _context.Addresses.Where(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode).FirstOrDefault();
            
            if(_address != null)
                return _address;
            

            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }
    }
}
