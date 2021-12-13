using _01_AccessModifiers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AccessModifers
{
    internal class DemoInheritance : Examples
    {
        DemoInheritance ex = new DemoInheritance();

        public DemoInheritance()
        {
            /* funkar */
            ex.PublicMethod();        
            ex.ProtectedMethod();
            ex.ProtectedInternalMethod();


            /* funkar inte */
            ex.PrivateMethod();
            ex.InternalMethod();
            ex.PrivateProtectedMethod();

        }
    }
}
