using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class PetrolCar : Vehicle
    {
        public PetrolCar() { Type = "Petrol"; }


    }

    public class PetrolFWD : PetrolCar
    {
        public PetrolFWD()
        {
            Type = "Petrol 4 WD";
        }
    }
}
