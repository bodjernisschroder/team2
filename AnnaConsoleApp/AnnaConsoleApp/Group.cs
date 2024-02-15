using System;
using System.Reflection.Metadata.Ecma335;

namespace AnnaConsoleApp
{
    public class Group
    {
        string ageGroup;
        public void AgeGroup(Person person)
        {
            int age = person.GetAge();

            if ( age > 67 )
                ageGroup = "en pensionist";
            else if ( age > 25)
                ageGroup = "i arbejde";
            else if ( age > 19 )
                ageGroup = "en studerende";
            else if ( age > 12)
                ageGroup = "en teenager";
            else
                ageGroup = "et barn";
        }

        public void PrintAgeGroup ()
        {
            Console.WriteLine(ageGroup);
        }
    }
}