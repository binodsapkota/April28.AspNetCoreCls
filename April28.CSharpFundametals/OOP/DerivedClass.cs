using InternalExamplePrj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals.OOP
{
    internal class DerivedClass: PublicClass
    {
        public DerivedClass()
        {
            ProtectedInternalValue = 1;//it is accessible here
           // PrivateProtectedValue = 2;//it is accessible here
        }
    }
}
