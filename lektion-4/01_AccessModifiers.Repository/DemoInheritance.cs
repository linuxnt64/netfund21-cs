using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AccessModifiers.Repository
{
    internal class DemoInheritance : Examples
    {
        DemoInheritance ex = new DemoInheritance();

        public DemoInheritance()
        {
            /* funkar */
            ex.PublicMethod();
            ex.InternalMethod();
            ex.ProtectedMethod();
            ex.ProtectedInternalMethod();
            ex.PrivateProtectedMethod();

            /* funkar inte */
            ex.PrivateMethod();
            
        }
    }
}
