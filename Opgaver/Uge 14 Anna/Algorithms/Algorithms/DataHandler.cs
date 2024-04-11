namespace Algorithms
{
    public class DataHandler
    {
        public string DataFileName { get; }

        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public void SaveStudents(List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter(DataFileName))
            {
                for (int i = 0; i < students.Count; i++)
                {
                    writer.WriteLine(students[i].FullName + " " + students[i].GroupNumber);
                }
            }
        }

        public List<Student> LoadStudents()
        {
            using (StreamReader reader = new StreamReader(DataFileName))
            {
                string line;
                List<Student> students = new List<Student>();
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> info = line.Split(",").ToList();
                    Student student = new Student(info[0], int.Parse(info[1]));
                    students.Add(student);
                }
                return students;
            }
        }
    }
}