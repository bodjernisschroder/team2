namespace Algorithms
{
    public static class SortingAlgorithms
    {
        public static void SelectionSortStudentsByGroupNumber(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[j].GroupNumber < students[minIndex].GroupNumber) minIndex = j;
                }
                Student tempStudent = students[minIndex];
                students[minIndex] = students[i];
                students[i] = tempStudent;
            }
        }

        public static void BubbleSortStudentsByFullName(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - i - 1; j++)
                {
                    if (students[j].FullName.CompareTo(students[j + 1].FullName) > 0)
                    {
                        Student tempStudent = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = tempStudent;
                    }
                }
            }
        }

        public static void QuickSortStudentsByFullName(List<Student> students, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(students, low, high);
                QuickSortStudentsByFullName(students, low, pivotIndex - 1);
                QuickSortStudentsByFullName(students, pivotIndex + 1, high);
            }
        }

        // Her står der i opgaven, at listen opdeles i to mindre lister
        // Jeg går ud fra, at det, der menes, er, at den
        // ved at returnere et pivotIndex inddeler listen i to, men at selve
        // opdelingen sker i QuickSortStudentsByFullName, da det efter mange mislykkede
        // forsøg ikke fungerede anderledes.
        public static int Partition(List<Student> students, int low, int high)
        {
            Student pivot = students[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (String.Compare(students[j].FullName, pivot.FullName) <= 0)
                {
                    i++;
                    Student temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                }
            }

            Student tempStudent = students[i + 1];
            students[i + 1] = students[high];
            students[high] = tempStudent;
            return i + 1;
        }
    }
}
