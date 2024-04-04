using System;

public class Student
{

    public string FullName {  get; set; }
    public int GroupNumber { get; set; }

    public Student(string fullName, int groupNumber)
    {
        FullName = fullName;
        GroupNumber = groupNumber;
    }

}