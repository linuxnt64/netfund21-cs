using _01_AccessModifiers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AccessModifers
{
    internal class Demo
    {
        Examples ex = new Examples();

        public Demo()
        {
            /* funkar */
            ex.PublicMethod();


            /* funkar inte */
            ex.PrivateMethod();
            ex.InternalMethod();
            ex.ProtectedMethod();

            ex.ProtectedInternalMethod();
            ex.PrivateProtectedMethod();

        }

    }
}
