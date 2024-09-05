using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Course : IValuable
    {
        private static double _courseHourValue = 875.0;

        public static double CourseHourValue
        {
            get { return _courseHourValue; }
            set { _courseHourValue = value; }
        }

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

        public double GetValue()
        {
            return (Math.Ceiling(DurationInMinutes / 60.0)) * CourseHourValue;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"Name: {Name}, Duration in Minutes: {DurationInMinutes}, Value: {GetValue()}";
        }
    }
}
