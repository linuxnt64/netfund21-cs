using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AccessModifiers.Repository
{
    internal class Demo
    {
        Examples ex = new Examples();

        public Demo()
        {
            /* funkar */
            ex.PublicMethod();
            ex.InternalMethod();
            ex.ProtectedInternalMethod();

            /* funkar inte */
            ex.PrivateMethod();
            ex.ProtectedMethod();
            ex.PrivateProtectedMethod();

        }
    }
}
