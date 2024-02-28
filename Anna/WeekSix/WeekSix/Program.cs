using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace WeekSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            int program = manager.StartProgram();

            while (true)
            {
                Console.Clear();
                if (program == 1)
                {
                    Person person = new Person();
                    Group group = new Group();

                    person.GetInformation();
                    // person.SubtractFromAge(10);
                    group.AgeGroup(person);

                    person.PrintInformation();
                    Console.Write(" og er ");
                    group.PrintAgeGroup();
                }
                else if (program == 2)
                {
                    Menu menu = new Menu();

                    menu.Create();
                }
                else if (program == 3)
                    break;
                Console.WriteLine("");
                program = manager.Continue();
            }
        }
    }
}