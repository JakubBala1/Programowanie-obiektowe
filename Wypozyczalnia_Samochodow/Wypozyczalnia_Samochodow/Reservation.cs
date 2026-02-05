using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia_Samochodow
{
    class Reservation
    {
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Days { get; set; }

        public Reservation(Customer customer, Vehicle vehicle, int days)
        {
            Customer = customer;
            Vehicle = vehicle;
            Days = days;
        }

        public double CalculateCost()
        {
            return Vehicle.PricePerDay * Days;
        }

        public void PrintInvoice()
        {
            Console.WriteLine("\n---------- FAKTURA ----------");
            Console.WriteLine($"Klient: {Customer.Name}");
            Console.WriteLine($"Auto: {Vehicle.Brand} {Vehicle.Model} ({Vehicle.GetTypeName()})");
            Console.WriteLine($"Dni wypożyczenia: {Days}");
            Console.WriteLine($"Cena za dzień: {Vehicle.PricePerDay} zł");
            Console.WriteLine($"Łączny koszt: {CalculateCost()} zł");
            Console.WriteLine("------------------------------\n");
        }
    }


}
