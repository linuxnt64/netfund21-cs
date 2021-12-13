using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AccessModifiers.Repository
{
    public class Examples
    {
        public Examples()
        {
            PublicMethod();
            PrivateMethod();
            InternalMethod();
            ProtectedMethod();

            ProtectedInternalMethod();
            PrivateProtectedMethod();
        }

        public void PublicMethod() { }
        private void PrivateMethod() { }
        internal void InternalMethod() { }
        protected void ProtectedMethod() { }

        protected internal void ProtectedInternalMethod() { }
        private protected void PrivateProtectedMethod() { }
    }
}
