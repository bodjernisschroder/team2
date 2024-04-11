using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Course
    {
        //Properties nedenfor
        public string Name { get; set; }  
        public int DurationInMinutes { get; set; }

        //Contructors nedenfor

        public Course (string name) 
        {
            Name = name;
        }

        public Course(string name, int durationInMinutes) : this(name)
        {
            DurationInMinutes = durationInMinutes;
        }


        public override string ToString()
        {
            //return base.ToString();
            return $"Name: {Name}, Duration in Minutes: {DurationInMinutes}";
        }
    }
}
