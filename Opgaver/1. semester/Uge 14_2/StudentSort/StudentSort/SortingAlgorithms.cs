using System;

public class SortingAlgorithms
{
    public List<Student> SelectionSort(List<Student> students)
    {
        int amountOfStudents = students.Count; //83

        for (int i = 0; i < amountOfStudents - 1; i++)
        {
            int min_idx = i; //0
            
            for (int j = i + 1; j < amountOfStudents; j++) //j er altid en takt foran i, derfor vi siger  j = i + 1
            {
                if (students[j].GroupNumber < students[min_idx].GroupNumber) 
                {

                }
                
            }
        }
        return students;
    }
}
/*
students = {Burak 2}, {Anja 3}, {Chanita 1}
students[1] = Anja 3
.GroupNumber = 3

*/
        //Pseudokode
        // Definér array/list og tildel variable til den list.Length
            //For int i = 0; i < list.Length - 1; i++
/*
idx    0 1 2 3 4 5
arr    6 3 2 5 1 4
modArr 1 3 2 5 6 4 // Vi har byttet 1 og 5 rundt de

n = arr.length = 6

for i = 0
    min_idx = i = 0
    for j = i + 1 = 0 + 1 = 1
        if arr[j] = arr[1] = 3 < arr[min_idx] = arr[0] = 6
            min_idx = j = 1
    for j = j++ = 1 + 1 = 2
        if arr[j] = arr[2] = 2 < arr[min_idx] = arr[1] = 3
            min_idx = j = 2
    for j = j++ = 2 + 1 = 3
        if arr[j] = arr[3] = 5 < arr[min_idx] = arr[2] = 2
            5 er ikke mindre end 2, derfor sætter vi ikke min_idx = j
    for j = j++ = 3 + 1 = 4
        if arr[j] = arr[4] = 1 < arr[min_idx] = arr[2] = 2
            min_idx = j = 4
    for j = j++ = 4 + 1 = 5 
        if arr[j] = arr[5] = 4 < arr[min_idx] = arr[4] = 1 
            4 er ikke mindre end 1, derfor sætter vi ikke min_idx = j
    j er ikke længere mindre end 6 når vi siger j++ = 5 + 1 = 6, derfor forlader vi j for loop
    int temp = arr[min_idx] = arr[4] = 1
    (arr[min_idx] = arr[4]) = (arr[i] = arr[0] = 6) - Kan oversættes til: arr[4] = 6
    (arr[i] = arr[0]) = (temp = 1) - Kan oversættes til: arr[0] = 1
for i = 1

*/