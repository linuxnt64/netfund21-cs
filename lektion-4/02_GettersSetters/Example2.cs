using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GettersSetters
{
    internal class Example2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; private set; }
    }
}
