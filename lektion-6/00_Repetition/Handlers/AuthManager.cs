using _00_Repetition.Models;
using _00_Repetition.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Repetition.Handlers
{
    internal interface IAuthManager
    {
        void SignUp(SignUpForm formInputs);
        string SignIn(SignInForm formInputs);
        void SignOut(string id);
    }

    internal class AuthManager : IAuthManager
    {
        IUserManager _userManager = new UserManager();



        public string SignIn(SignInForm formInputs)
        {
            throw new NotImplementedException();
        }

        public void SignOut(string id)
        {
            throw new NotImplementedException();
        }

        public void SignUp(SignUpForm formInputs)
        {
            var user = new User()
            {
                FirstName = formInputs.FirstName,
                LastName = formInputs.LastName,
                Email = formInputs.Email,
                AddressLine = formInputs.AddressLine,
                PostalCode = formInputs.PostalCode,
                City = formInputs.City
            };

            var _user = _userManager.CreateUser(user, formInputs.Password);

            if (_user != null)
                Console.WriteLine($"Användaren {_user.DisplayName} skapades.");
            else
                Console.WriteLine("Något gick fel när användaren skulle skapas.");
        }
    }
}
