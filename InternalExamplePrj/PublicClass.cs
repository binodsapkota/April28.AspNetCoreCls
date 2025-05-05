using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalExamplePrj
{
    public class PublicClass
    {
        public PublicClass() { }
        public int PublicValue { get; set; }
        internal int InternalValue { get; set; }

        public int GetInternalValue()
        {
            InternalClass internalClass = new InternalClass();
            return internalClass.SomeValue;
        }

        protected internal int ProtectedInternalValue { get; set; }
        private protected int PrivateProtectedValue { get; set; }
    }

    public class DerivedPublicClass : PublicClass
    {

        public DerivedPublicClass()
        {
            ProtectedInternalValue = 1;//it is accessible here
            PrivateProtectedValue = 2;//it is accessible here
        }
    }
}
