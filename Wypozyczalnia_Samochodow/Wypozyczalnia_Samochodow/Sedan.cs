using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia_Samochodow
{
    class Sedan : Car
    {
        public Sedan(int id, string brand, string model, double pricePerDay)
            : base(id, brand, model, pricePerDay)
        {
        }

        public override string GetTypeName()
        {
            return "Sedan";
        }
    }

}
