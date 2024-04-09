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
        private string _name;
        private string _email;
        private string _phoneNumber;
        public string Name
        { 
            get { return _name; }
            set
            {
                if (value == "") throw new Exception("Customer must have a name");
                _name = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value == "") _email = "N/A";
                else _email = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value == "") _phoneNumber = "N/A";
                else _phoneNumber = value;
            }
        }

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