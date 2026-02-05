using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia_Samochodow
{
    abstract class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double PricePerDay { get; set; }

        protected Vehicle(int id, string brand, string model, double pricePerDay)
        {
            Id = id;
            Brand = brand;
            Model = model;
            PricePerDay = pricePerDay;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Id}: {Brand} {Model} - {PricePerDay} zł/dzień");
        }

        public abstract string GetTypeName();
    }



}
