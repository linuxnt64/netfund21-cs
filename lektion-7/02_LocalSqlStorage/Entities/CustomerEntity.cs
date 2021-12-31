using _02_LocalSqlStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LocalSqlStorage.Models
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
