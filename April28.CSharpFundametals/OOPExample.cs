using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April28.CSharpFundametals
{
    public class OOPExample
    {

        /// <summary>
        /// field
        /// </summary>
        public int Age;//pascal case for public property
        private int _dob;//start with _ for private
        /// <summary>
        /// property
        /// </summary>
        public int Dob { get { return _dob; } set { _dob = value; } }
        /// <summary>
        /// property default
        /// </summary>
        public string Fullname { get; set; }

        protected int Id;

    }


    //syntax of inheritance is
    //public class ClassName:BaseClass
    public class MyOOPExample: OOPExample
    {
       public int GetId()
        {
            
            return Id;
        }
    }
}
