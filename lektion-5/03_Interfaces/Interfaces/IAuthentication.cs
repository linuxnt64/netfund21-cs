using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Interfaces
{
    internal interface IAuthentication
    {
        void SignUp(string firstName, string lastName, string email, string password);
        string SignIn(string email, string password);
        void SignOut(string id);
    }
}
