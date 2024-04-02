using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Customer
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string navn, string email, string phoneNumber)
        {
            Navn = navn;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Opret en liste til at gemme kundeobjekter
//        // List<Customer> customers = new List<Customer>();

//        // Prompt brugeren for at indtaste kundeoplysninger
//        Console.WriteLine("opret kunde:");
//        Console.Write("Navn: ");
//        string name = Console.ReadLine();

//        Console.Write("Email: ");
//        string email = Console.ReadLine();

//        Console.Write("Telefon Number: ");
//        string phoneNumber = Console.ReadLine();

//        Console.ReadLine();
//    }
//}