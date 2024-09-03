using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace StudentSort
{
    public class DataHandler
    {
        // Property til at indlæse Datafilen. Der er ikke angivet nogen set her, da vi ikke skal ændre. 
        public string DataFileName { get; }

        public string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public void SaveStudent(Student student)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, DataFileName)))
            {
                outputFile.WriteLine(student.FullName + "," + student.GroupNumber + "\n"); ;
            }
        }

        public List<string> LoadStudent(string line)
        {
            //using (StreamReader inputFile = new StreamReader(Path.Combine(docPath, DataFileName)))
            //{
            // Vi læser første linje af filen
            //string input = inputFile.ReadLine();

            // Vi splitter linjen, vi har læst, op, hver gang, der er et semikolon, og gemmer resultatet i et array
            List<string> studentDetails = line.Split(",").ToList();

            // Vi opretter en Student, som gives indholdet af array
            //Student loadedStudent = new Student(studentDetails[0], int.Parse(studentDetails[1]));

            // Vi returnerer Studenten
            return studentDetails;
            //}
        }

        public void SaveStudents(List<Student> Students)
        {
            // Gemmer samling af Studenter Students i tekstfilen
            for (int i = 0; i < Students.Count; i++)
            {
                SaveStudent(Students[i]);
            }
        }

        public List<Student> LoadStudents()
        {
            string line;
            List<Student> students = new List<Student>();
            List<string> studentDetails = new List<string>();

            using (StreamReader inputFile = new StreamReader(Path.Combine(docPath, DataFileName)))
            {
                // Returnerer Studenter Students fra tekstfilen
                while ((line = inputFile.ReadLine()) != null)
                {
                    studentDetails = LoadStudent(line);
                    Student student = new Student(studentDetails[0], int.Parse(studentDetails[1]));
                    students.Add(student);
                }
            }
            return students;
        }
    }
}