using _03_UWP_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_UWP_GUI.Handlers
{
    internal interface IUserManager
    {
        void CreateUser(User user);
        IEnumerable<User> GetUsers();
    }

    internal class UserManager : IUserManager
    {
        private List<User> users = new List<User>();

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }
    }
}
