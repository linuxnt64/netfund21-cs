using _03_Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Handlers
{
    internal class UserManager : IUserManager
    {
        public void DeleteProfilePicture()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void SignOut(string id)
        {
            throw new NotImplementedException();
        }

        public void SignUp(string firstName, string lastName, string email, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmailAddress(string email)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfilePicture(string imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
