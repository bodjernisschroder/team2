using System;
using System.Reflection.Metadata.Ecma335;

namespace AnnaConsoleApp
{
    public class Person
    {
        private string name;
        private int age;

        public void GetInformation()
        {
            RequestName();
            RequestAge();
        }

        public void PrintInformation()
        {
            Console.Write(name + " er " + age + " år gammel");
        }

        private void RequestName()
        {
            Console.Write("Indtast navn: "); //Write udskriver en tekst til konsollen uden at hoppe ned på den efterfølgende linje
            name = Console.ReadLine();
            Console.WriteLine("Navn: " + name); //WriteLine udskriver en tekst og hopper ned på efterfølgende linje
        }

        private void RequestAge()
        {
            Console.Write("Indtast alder: ");
            
            //Tjekker om alderen er en integer. Hvis ikke, meddeles en fejl
            if (int.TryParse(Console.ReadLine(), out int inputAge))
            {
                age = inputAge;
                Console.WriteLine("Alder: " + age);
            }
            else
                Console.WriteLine("Ugyldig alder. Indtast et gyldigt heltal.");
        }

        public void SubtractFromAge(int toSubtract)
        {
            age -= toSubtract;
        }

        public int GetAge()
        {
            return age;
        }
    }
}