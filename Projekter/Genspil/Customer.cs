using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer()
        {
            Name = ConsoleManager.AddCustomerName();
            Email = ConsoleManager.AddCustomerEmail();
            PhoneNumber = ConsoleManager.AddCustomerPhoneNumber();
        }

        public Customer(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace Genspil
//{
//    public class Customer
//    {
//        public string Name { get; set; }
//        public string Email { get; set; }
//        public string PhoneNumber { get; set; }

//        public Customer(string name, string email, string phoneNumber)
//        {
//            Name = name;
//            Email = email;
//            PhoneNumber = phoneNumber;
//        }

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