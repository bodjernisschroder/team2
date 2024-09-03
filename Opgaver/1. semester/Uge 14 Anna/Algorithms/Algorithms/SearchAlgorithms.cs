namespace Algorithms
{
    public static class SearchAlgorithms
    {
        public static Student LinearSearchFullName(List<Student> students, string fullName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].FullName == fullName) return students[i];
            }
            return null;
        }

        public static Student BinarySearchFullName(List<Student> students, string fullName)
        {
            int left = 0;
            int right = students.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (students[mid].FullName == fullName) return students[mid];
                if (fullName.CompareTo(students[mid].FullName) < 0) right = mid - 1;
                else left = mid + 1;
            }
            return null;
        }

        public static Student RecursiveBinarySearch(List<Student> students, string fullName, int left, int right)
        {
            if (left > right) return null;
            int mid = (left + right) / 2;
            if (students[mid].FullName == fullName) return students[mid];
            if (fullName.CompareTo(students[mid].FullName) < 0) right = mid - 1;
            else left = mid + 1;
            return RecursiveBinarySearch(students, fullName, left, right);
        }
    }
}
