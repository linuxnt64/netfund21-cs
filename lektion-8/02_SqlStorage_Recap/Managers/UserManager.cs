using _02_SqlStorage_Recap.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SqlStorage_Recap.Managers
{
    public class UserManager
    {
        private static string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\NETFUND21\netfund21-cs\lektion-8\02_SqlStorage_Recap\Data\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        AddressHandler addressHandler = new AddressHandler(connectionstring);
        CustomerHandler customerHandler = new CustomerHandler(connectionstring);

        public void CreateUser(string firstname, string lastname, string email, string addressline, string postalcode, string city)
        {
            var addressId = addressHandler.Create(addressline, postalcode, city);
            var customerId = customerHandler.Create(firstname, lastname, email, addressId);
            Console.WriteLine(customerId);
        }
    }
}
}
