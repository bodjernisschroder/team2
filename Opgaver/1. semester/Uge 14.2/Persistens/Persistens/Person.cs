using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistens
{
    public class Person
    {
        //private string _name;
        //private DateTime _birthDate;
        //private double _height;
        //private bool _isMarried;
        //private int _noOfChildren;

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public bool IsMarried { get; set; }
        public int NoOfChildren { get; set; }

        public Person(string name, DateTime birthDate, double height, bool isMarried, int noOfChildren)
        {
            Name = name;
            BirthDate = birthDate;
            Height = height;
            IsMarried = isMarried;
            NoOfChildren = noOfChildren;
        }

        //Skriv metoden herunder Anja :)
        // ”Anders And;01-05-1962 00:00:00;175,5;True;2”
        public string MakeTitle()
        {
            return $"{Name};{BirthDate.ToString("dd-MM-yyyy HH':'mm':'ss")};{Height};{IsMarried};{NoOfChildren}";
        }
    }
}