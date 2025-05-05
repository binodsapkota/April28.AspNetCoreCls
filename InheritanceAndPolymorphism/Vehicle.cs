using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Vehicle : IVehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        protected string Type { get; set; }

        public void Drive()
        {
            Console.WriteLine($"{Type} Engine is Driving....");
        }

        public void StartEngine()
        {
            Console.WriteLine($"{Type} Engine Started....");
        }

        public void StopEngine()
        {
            Console.WriteLine($"{Type} Engine Stoped....");
        }
    }

    public interface IVehicle
    {
        void StartEngine();
        void StopEngine();
        void Drive();

    }

}
