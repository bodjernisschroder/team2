namespace Algorithms
{
    class Program
    {
        public static void Main()
        {
            DataHandler originalFile = new DataHandler("students.txt");
            DataHandler sortedListFile = new DataHandler("studentsSorted.txt");
            List<Student> students = originalFile.LoadStudents();
            Student foundStudent = new Student("", 0);
            bool choiceMade = false;
            bool sort = false;
            bool search = false;

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FullName,-20}\t{student.GroupNumber}");
            }

            while (!choiceMade)
            {
                Console.WriteLine("\nChoose what you wish to do");
                Console.WriteLine("1. Sort");
                Console.WriteLine("2. Search");
                Console.Write("\nI wish to: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Sort
                            sort = true;
                            choiceMade = true;
                            break;
                        case 2:
                            // Search
                            search = true;
                            choiceMade = true;
                            break;
                        default:
                            break;
                    }
                }
                else Console.WriteLine("Invalid input. Try again");
            }

            choiceMade = false;

            if (sort)
            {
                while (!choiceMade)
                {
                    Console.WriteLine("\nChoose how you want to sort the students");
                    Console.WriteLine("1. Full Name");
                    Console.WriteLine("2. Group Number");
                    Console.Write("\nSort by: ");
                    if (int.TryParse(Console.ReadLine(), out int sortChoice))
                    {
                        switch (sortChoice)
                        {
                            case 1:
                                // Prompt for sort algorithm
                                bool sortAlgorithmChosen = false;
                                while (!sortAlgorithmChosen)
                                {
                                    Console.WriteLine("\nChoose what sort algorithm you would like to use");
                                    Console.WriteLine("A. Bubble Sort");
                                    Console.WriteLine("B. Quick Sort");
                                    Console.Write("\nSort by: ");
                                    if (char.TryParse(Console.ReadLine(), out char fullNameSortChoice))
                                    {
                                        switch (fullNameSortChoice)
                                        {
                                            case 'A':
                                                SortingAlgorithms.BubbleSortStudentsByFullName(students);
                                                sortAlgorithmChosen = true;
                                                choiceMade = true;
                                                break;
                                            case 'B':
                                                SortingAlgorithms.QuickSortStudentsByFullName(students, 0, students.Count - 1);
                                                sortAlgorithmChosen = true;
                                                choiceMade = true;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input. Try again");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Try again");
                                    }
                                }
                                break; // Exit the outer switch
                            case 2:
                                SortingAlgorithms.SelectionSortStudentsByGroupNumber(students);
                                choiceMade = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input. Try again");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again");
                    }
                }
                try
                {
                    sortedListFile.SaveStudents(students);
                    Console.WriteLine("The sorted list of students was saved successfully");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Could not save the sorted list of students");
                    Console.WriteLine(exception.Message);
                }
            }
            else if (search)
            {
                while (!choiceMade)
                {
                    Console.Write("\nWrite the full name you want to search for: ");
                    string fullName = Console.ReadLine();
                    Console.WriteLine("\nChoose what search algorithm you would like to use");
                    Console.WriteLine("1. Linear Search");
                    Console.WriteLine("2. Binary Search");
                    Console.WriteLine("3. Recursive Binary Search");
                    Console.Write("\nSearch using: ");
                    if (int.TryParse(Console.ReadLine(), out int searchChoice))
                    {
                        switch (searchChoice)
                        {
                            case 1:
                                foundStudent = SearchAlgorithms.LinearSearchFullName(students, fullName);
                                choiceMade = true;
                                break;
                            case 2:
                                SortingAlgorithms.BubbleSortStudentsByFullName(students);
                                foundStudent = SearchAlgorithms.BinarySearchFullName(students, fullName);
                                choiceMade = true;
                                break;
                            case 3:
                                SortingAlgorithms.BubbleSortStudentsByFullName(students);
                                foundStudent = SearchAlgorithms.RecursiveBinarySearch(students, fullName, 0, students.Count - 1);
                                choiceMade = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input. Try again");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again");
                    }
                }
                Console.WriteLine($"Student {foundStudent.FullName} has group number {foundStudent.GroupNumber}");
            }


            Console.ReadLine();
        }
    }
}