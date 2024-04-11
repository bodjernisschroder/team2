namespace Algorithms
{
    public class Student
    {
        private string _fullName;
        private int _groupNumber;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public int GroupNumber
        {
            get { return _groupNumber; }
            set { _groupNumber = value; }
        }

        public Student(string fullName, int groupNumber)
        {
            FullName = fullName;
            GroupNumber = groupNumber;
        }
    }
}
