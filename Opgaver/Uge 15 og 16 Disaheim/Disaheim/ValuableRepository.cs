using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class ValuableRepository : IPersistable
    {
        private List<IValuable> valuables = new List<IValuable>();

        
        public void AddValuable(IValuable valuable)
        {
            valuables.Add(valuable);
        }

        public IValuable GetValuable(string id)
        {  

            foreach (IValuable valuable in valuables)
            {
                if (valuable is Merchandise merchandise)
                {
                    if (merchandise.ItemId == id)
                        return valuable;
                }
                else if (valuable is Course course)
                {
                    if (course.Name == id)
                        return valuable;
                }
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0.0;
            foreach (IValuable valuable in valuables)
            {
                total += valuable.GetValue();
            }
            return total;
        }

        public int Count()
        {
            return valuables.Count;
        }

        //public void Save()
        //{
        //    string fileName = "ValuableRepository.txt";
        //    using (StreamWriter writer = new StreamWriter(fileName))
        //    {
        //        foreach (IValuable valuable in valuables)
        //        {
        //            if (valuable is Book book)
        //            {
        //                writer.WriteLine($"BOG;{book.ItemId};{book.Title};{book.Price}");
        //            }
        //            else if (valuable is Amulet amulet)
        //            {
        //                writer.WriteLine($"AMULET;{amulet.ItemId};{amulet.Quality};{amulet.Design}");
        //            }
        //            else if (valuable is Course course)
        //            {
        //                writer.WriteLine($"KURSUS;{course.Name};{course.DurationInMinutes};{course.GetValue()}");
        //            }
        //        }
        //    }
        //}

        public void Save(string fileName = "ValuableRepository.txt")
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (IValuable valuable in valuables)
                {
                    if (valuable is Book book)
                    {
                        writer.WriteLine($"BOG;{book.ItemId};{book.Title};{book.Price}");
                    }
                    else if (valuable is Amulet amulet)
                    {
                        writer.WriteLine($"AMULET;{amulet.ItemId};{amulet.Quality};{amulet.Design}");
                    }
                    else if (valuable is Course course)
                    {
                        writer.WriteLine($"KURSUS;{course.Name};{course.DurationInMinutes}");
                    }
                }
            }
        }

        //public void Load()
        //{
        //    string fileName = "ValuableRepository.txt";
        //    using (StreamReader reader = new StreamReader(fileName))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            string[] values = line.Split(";");
        //            if (values[0] == "BOG")
        //            {
        //                Book book = new Book(itemId: values[1], title: values[2], price: double.Parse(values[3]));
        //                AddValuable(book);
        //            }
        //            else if (values[0] == "AMULET")
        //            {
        //                Amulet amulet = new Amulet(itemId: values[1], quality: (Level)Enum.Parse(typeof(Level), values[2]), design: values[3]);
        //                AddValuable(amulet);
        //            }
        //            else if (values[0] == "KURSUS")
        //            {
        //                Course course = new Course(name: values[1], durationInMinutes: int.Parse(values[2]));
        //                AddValuable(course);
        //            }
        //        }
        //    }
        //}

        public void Load(string fileName = "ValuableRepository.txt")
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(";");
                    if (values[0] == "BOG")
                    {
                        Book book = new Book(itemId: values[1], title: values[2], price: double.Parse(values[3]));
                        AddValuable(book);
                    }
                    else if (values[0] == "AMULET")
                    {
                        Amulet amulet = new Amulet(itemId: values[1], quality: (Level)Enum.Parse(typeof(Level), values[2]), design: values[3]);
                        AddValuable(amulet);
                    }
                    else if (values[0] == "KURSUS")
                    {
                        Course course = new Course(name: values[1], durationInMinutes: int.Parse(values[2]));
                        AddValuable(course);
                    }
                    
                        
                }
            }
        }
    }
}