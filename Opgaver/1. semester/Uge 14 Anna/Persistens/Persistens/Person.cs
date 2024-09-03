using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistens
{
    public class Person
    {
        private string _name;
        private DateTime _birthDate;
        private double _height;
        private bool _isMarried;
        private int _noOfChildren;
        public string Name
        { 
            get { return _name; }
            set
            {
                if (value.Length == 0) throw new Exception("The person must be given a name");
                _name = value;
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value < new DateTime(1900, 1, 1)) throw new Exception("The person must be born after January 1st 1900");
                _birthDate = value;
            }
        }
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0) throw new Exception("The person must have a height > 0");
                _height = value;
            }
        }
        public bool IsMarried
        {
            get { return _isMarried; }
            set { _isMarried = value; }
        }
        public int NoOfChildren
        {
            get { return _noOfChildren; }
            set
            {
                if (value < 0) throw new Exception("The person cannot have < 0 children");
                _noOfChildren = value;
            }
        }
        public Person (string name, DateTime birthDate, double height, bool isMarried, int noOfChildren)
        {
            Name = name;
            BirthDate = birthDate;
            Height = height;
            IsMarried = isMarried;
            NoOfChildren = noOfChildren;
        }
        public Person(string name, DateTime birthDate, double height, bool isMarried) : this(name, birthDate, height, isMarried, 0)
        {
        }

        public string MakeTitle()
        {
            return $"{Name};{BirthDate.ToString("dd-MM-yyyy HH':'mm':'ss")};{Height};{IsMarried};{NoOfChildren}";
        }
    }
}
