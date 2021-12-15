using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Interfaces.Interfaces
{
    internal interface IProfileManagement
    {
        void UpdateProfilePicture(string imageFile);
        void DeleteProfilePicture();
        void UpdateEmailAddress(string email);
    }
}
