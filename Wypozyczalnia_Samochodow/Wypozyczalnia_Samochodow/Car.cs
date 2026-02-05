using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia_Samochodow
{
    class Car : Vehicle
    {
        public Car(int id, string brand, string model, double pricePerDay)
            : base(id, brand, model, pricePerDay)
        {
        }

        public override string GetTypeName()
        {
            return "Car";
        }
    }


}
