using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistens
{
    public class DataHandler
    {
        public string DataFileName { get; }

        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public void SavePerson (Person person)
        {
            using (StreamWriter writer = new StreamWriter(DataFileName))
            {
                writer.WriteLine(person.MakeTitle());
            }
        }

        public Person LoadPerson ()
        {
            using (StreamReader reader = new StreamReader(DataFileName))
            {
                List<string> info = new List<string>();
                info = reader.ReadLine().Split(";").ToList();
                Person person = new Person(info[0], DateTime.Parse(info[1]), double.Parse(info[2]), bool.Parse(info[3]), int.Parse(info[4]));
                return person;
            }
        }

        public void SavePersons(Person[] persons)
        {
            using (StreamWriter writer = new StreamWriter(DataFileName))
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    writer.WriteLine(persons[i].MakeTitle());
                }
            }
        }

        public Person[] LoadPersons()
        {
            using (StreamReader reader = new StreamReader(DataFileName))
            {
                string line;
                List<Person> persons = new List<Person>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] info = line.Split(";");
                    Person person = new Person(info[0], DateTime.Parse(info[1]), double.Parse(info[2]), bool.Parse(info[3]), int.Parse(info[4]));
                    persons.Add(person);
                }
                return persons.ToArray();
            }
        }
    }
}