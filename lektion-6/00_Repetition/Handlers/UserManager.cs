using _00_Repetition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Handlers
{
    internal interface IUserManager
    {
        User CreateUser(User user, string password);
        User GetUser(string id);
        IEnumerable<User> GetUsers();
    }

    internal class UserManager : IUserManager
    {
        public User CreateUser(User user, string password)
        {
            user.CreatePassword(password);
            user.Id = Guid.NewGuid().ToString();

            return user;
        }



        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
