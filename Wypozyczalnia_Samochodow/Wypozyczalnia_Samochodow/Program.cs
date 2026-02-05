using System;
using Wypozyczalnia_Samochodow;

class Program
{
    static void Main()
    {
        RentalService service = new RentalService();

        while (true)
        {
            Console.WriteLine("\n----- WYPOŻYCZALNIA AUT -----");
            Console.WriteLine("1. Lista samochodów");
            Console.WriteLine("2. Dodaj samochód");
            Console.WriteLine("3. Usuń samochód");
            Console.WriteLine("4. Edytuj samochód");
            Console.WriteLine("5. Rezerwuj samochód");
            Console.WriteLine("6. Lista klientów");
            Console.WriteLine("7. Dodaj klienta");
            Console.WriteLine("8. Lista rezerwacji");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybór: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    service.ShowVehicles();
                    break;

                case "2":
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Typ (Sedan/SUV/Van): ");
                    string type = Console.ReadLine();

                    Console.Write("Marka: ");
                    string brand = Console.ReadLine();

                    Console.Write("Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Cena za dzień: ");
                    double price = double.Parse(Console.ReadLine());

                    Vehicle car = type switch
                    {
                        "Sedan" => new Sedan(id, brand, model, price),
                        "SUV" => new SUV(id, brand, model, price),
                        "Van" => new Van(id, brand, model, price),
                        _ => new Car(id, brand, model, price)
                    };

                    service.AddVehicle(car);
                    Console.WriteLine("Dodano samochód!");
                    break;

                case "3":
                    Console.Write("Podaj ID auta do usunięcia: ");
                    int delId = int.Parse(Console.ReadLine());

                    Vehicle delVehicle = service.GetVehicle(delId);
                    if (delVehicle == null)
                    {
                        Console.WriteLine("Nie ma samochodu o takim id");
                        break;
                    }

                    service.RemoveVehicle(delId);
                    Console.WriteLine("Usunięto samochód!");
                    break;


                case "4":
                    Console.Write("ID auta do edycji: ");
                    int editId = int.Parse(Console.ReadLine());

                    Vehicle editVehicle = service.GetVehicle(editId);
                    if (editVehicle == null)
                    {
                        Console.WriteLine("Nie ma samochodu o takim id");
                        break;
                    }

                    Console.Write("Nowy typ (Sedan/SUV/Van): ");
                    string newType = Console.ReadLine();

                    Console.Write("Nowa marka: ");
                    string newBrand = Console.ReadLine();

                    Console.Write("Nowy model: ");
                    string newModel = Console.ReadLine();

                    Console.Write("Nowa cena: ");
                    double newPrice = double.Parse(Console.ReadLine());

                    service.EditVehicle(editId, newType, newBrand, newModel, newPrice);
                    break;


                case "5":
                    service.ShowCustomers();
                    Console.Write("ID klienta: ");
                    int customerId = int.Parse(Console.ReadLine());

                    Customer cust = service.GetCustomer(customerId);

                    if (cust == null)
                    {
                        Console.WriteLine("Nie ma takiego klienta!");
                        break;
                    }

                    service.ShowVehicles();
                    Console.Write("ID auta: ");
                    int carId = int.Parse(Console.ReadLine());

                    Vehicle selected = service.GetVehicle(carId);

                    if (selected == null)
                    {
                        Console.WriteLine("Nie ma samochodu o takim id");
                        break; 
                    }

                    Console.Write("Na ile dni?: ");
                    int days = int.Parse(Console.ReadLine());

                    Reservation res = new Reservation(cust, selected, days);
                    res.PrintInvoice();
                    service.SaveReservation(res);
                    Console.WriteLine("Rezerwacja została zapisana do bazy.");
                    break;


                case "6":
                    service.ShowCustomers();
                    break;
                case "7":
                    Console.Write("ID klienta: ");
                    int custId = int.Parse(Console.ReadLine());

                    Console.Write("Imię i nazwisko: ");
                    string custName = Console.ReadLine();

                    service.AddCustomer(new Customer(custId, custName));
                    Console.WriteLine("Dodano klienta!");
                    break;
                case "8":
                    service.ShowReservations();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Błędny wybór.");
                    break;
            }
        }
    }
}
