using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia_Samochodow
{
    class RentalService
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private string filePath = "cars.txt";
        private List<Customer> customers = new List<Customer>();
        private string customerFilePath = "customers.txt";
        private string reservationFilePath = "reservations.txt";


        public RentalService()
        {
            LoadFromFile();
            LoadCustomersFromFile();
        }


        public void ShowVehicles()
        {
            Console.WriteLine("\n--- Lista samochodów ---");
            foreach (var v in vehicles)
                v.Display();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            SaveToFile();
        }

        public void RemoveVehicle(int id)
        {
            vehicles.RemoveAll(v => v.Id == id);
            SaveToFile();
        }

        public void EditVehicle(int id, string newType, string brand, string model, double price)
        {
            var oldVehicle = vehicles.Find(v => v.Id == id);

            if (oldVehicle == null)
            {
                Console.WriteLine("Nie znaleziono auta!");
                return;
            }

            Vehicle newVehicle = newType switch
            {
                "Sedan" => new Sedan(id, brand, model, price),
                "SUV" => new SUV(id, brand, model, price),
                "Van" => new Van(id, brand, model, price),
                _ => new Car(id, brand, model, price)
            };

            vehicles.Remove(oldVehicle);
            vehicles.Add(newVehicle);

            SaveToFile();
            Console.WriteLine("Zaktualizowano samochód.");
        }

        public Vehicle GetVehicle(int id)
        {
            return vehicles.Find(v => v.Id == id);
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(';');
                int id = int.Parse(parts[0]);
                string type = parts[1];
                string brand = parts[2];
                string model = parts[3];
                double price = double.Parse(parts[4]);

                Vehicle v = type switch
                {
                    "Sedan" => new Sedan(id, brand, model, price),
                    "SUV" => new SUV(id, brand, model, price),
                    "Van" => new Van(id, brand, model, price),
                    _ => new Car(id, brand, model, price)
                };

                vehicles.Add(v);
            }
        }

        private void SaveToFile()
        {
            List<string> lines = new List<string>();

            foreach (var v in vehicles)
            {
                lines.Add($"{v.Id};{v.GetTypeName()};{v.Brand};{v.Model};{v.PricePerDay}");
            }

            File.WriteAllLines(filePath, lines);
        }
        public void ShowCustomers()
        {
            Console.WriteLine("\n--- Lista klientów ---");
            foreach (var c in customers)
                c.Display();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
            SaveCustomersToFile();
        }

        public Customer GetCustomer(int id)
        {
            return customers.Find(c => c.Id == id);
        }

        private void LoadCustomersFromFile()
        {
            if (!File.Exists(customerFilePath)) return;

            foreach (var line in File.ReadAllLines(customerFilePath))
            {
                string[] parts = line.Split(';');
                int id = int.Parse(parts[0]);
                string name = parts[1];

                customers.Add(new Customer(id, name));
            }
        }

        private void SaveCustomersToFile()
        {
            List<string> lines = new List<string>();

            foreach (var c in customers)
                lines.Add($"{c.Id};{c.Name}");

            File.WriteAllLines(customerFilePath, lines);
        }
        public void SaveReservation(Reservation reservation)
        {
            string line = $"{reservation.Customer.Id};" +
                          $"{reservation.Vehicle.Id};" +
                          $"{reservation.Days};" +
                          $"{reservation.CalculateCost()}";

            File.AppendAllText(reservationFilePath, line + Environment.NewLine);
        }
        public void ShowReservations()
        {
            if (!File.Exists(reservationFilePath))
            {
                Console.WriteLine("Brak zapisanych rezerwacji.");
                return;
            }

            Console.WriteLine("\n--- Rezerwacje ---");
            foreach (var line in File.ReadAllLines(reservationFilePath))
            {
                string[] parts = line.Split(';');
                Console.WriteLine(
                    $"Klient ID: {parts[0]}, Auto ID: {parts[1]}, Dni: {parts[2]}, Koszt: {parts[3]} zł"
                );
            }
        }



    }

}
