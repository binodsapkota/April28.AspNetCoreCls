using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InheritanceAndPolymorphism
{
    /// <summary>
    /// An interface is a contract that defines methods and properties without implementation.
    ///✔ Classes that implement an interface must provide an implementation for its members.
    ///✔ Multiple interfaces can be implemented in a class (Unlike multiple inheritance).

    /// </summary>
    internal interface IVehicle
    {
        void StartEngine();
        void StopEngine();
        void Drive();
    }
}
