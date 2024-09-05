using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Persistens
{
    public class DataHandler
    {
        //private string _dataFileName;
        public string DataFileName { get; }

        //public string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public void SavePerson(Person person)
        {
            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, DataFileName)))
            using (StreamWriter outputFile = new StreamWriter(DataFileName))
            {
                outputFile.WriteLine(person.MakeTitle() + "\n");
            }
        }

        public Person LoadPerson(string input)
        {
            //using (StreamReader inputFile = new StreamReader(Path.Combine(docPath, DataFileName)))
            //{
            //    // Vi læser første linje af filen
            //    string input = inputFile.ReadLine();

            // ”Anders And;01-05-1962 00:00:00;175,5;True;2”
            string[] inputArray = new string[5];
                // Vi splitter linjen, vi har læst, op, hver gang, der er et semikolon, og gemmer resultatet i et array         
            inputArray = input.Split(";", StringSplitOptions.TrimEntries);


                // Array: [Anders And, 01-05-1962 00:00:00, 175,5, True, 2”]

                // Vi opretter en person, som gives indholdet af array
            Person loadedPerson = new Person(inputArray[0], DateTime.Parse(inputArray[1]), double.Parse(inputArray[2]), bool.Parse(inputArray[3]), int.Parse(inputArray[4]));
                
                // Vi returnerer personen
            return loadedPerson;
        }
        
        public void SavePersons(Person[] persons)
        {
            // Gemmer samling af personer persons i tekstfilen
            for (int i = 0; i < persons.Length; i++)
            {
                SavePerson(persons[i]);
            }
        }

        public Person[] LoadPersons()
        {
            // Returnerer personer persons fra tekstfilen
            using (StreamReader inputFile = new StreamReader(DataFileName))
            {
                string[] file = inputFile.ReadToEnd().Split("\n", StringSplitOptions.TrimEntries);
                Person[] persons = new Person[file.Length];

                for (int i = 0; i < file.Length; i++)
                {
                    persons[i] = LoadPerson(file[i]);
                }
                return persons;
            }
        }
    }
}