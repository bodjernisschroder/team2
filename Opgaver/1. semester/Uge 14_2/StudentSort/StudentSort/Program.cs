using StudentSort;
using System;

class Program
{
    static void Main(string[] args)
    {
        DataHandler handler = new DataHandler("students.txt");
        List<Student> students = handler.LoadStudents();
        //SelectionSort(students);

        foreach (Student student in students)
        {
            Console.WriteLine(student.GroupNumber + "\t" + student.FullName);
        }

        Console.ReadLine();
    }
}