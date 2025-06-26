using System;
using System.Reflection.Metadata;
using System.Globalization;
using Interfaces.Entities;
using Interfaces.Services;
namespace Course;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter rental data");

        Console.Write("Car model: ");
        string model = Console.ReadLine();

        Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        Console.Write("Return (dd/MM/yyyy hh:mm): ");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        Console.Write("Enter price per hour: ");
        double hour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

        Console.Write("Enter price per days: ");
        double day = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

        CarRental carRental = new CarRental(start, finish, new Vehicle(model));

        RentalServices rentalServices = new RentalServices(hour, day, new BrazilTaxService());

        rentalServices.ProcessInvoice(carRental);

        Console.WriteLine("Invoice: ");
        Console.WriteLine(carRental.Invoice);


    }
}