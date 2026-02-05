using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia_Samochodow
{
    class Van : Car
    {
        public Van(int id, string brand, string model, double pricePerDay)
            : base(id, brand, model, pricePerDay)
        {
        }

        public override string GetTypeName()
        {
            return "Van";
        }
    }

}
