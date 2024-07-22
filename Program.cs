using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            int[] arr2 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            int[] arr3 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            int[] arrSorted1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrSorted2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrSorted3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            InsertionSort(arrSorted1);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Insertion Sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            BubbleSort(arrSorted2);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Bubble Sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            SelectionSort(arrSorted3);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Selection Sort: {stopwatch.ElapsedTicks}");

            Console.WriteLine("Please select a sorting algorithm");
            Console.WriteLine("1: Bubble Sort");
            Console.WriteLine("2: Selection Sort");
            Console.WriteLine("3: Insertion Sort");

            string? userSelection = Console.ReadLine();

            Student student1 = new Student("Bob", 4.0);
            Student student2 = new Student("Bob2", 3.2);
            Student student3 = new Student("Bob3", 2.9);
            Student student4 = new Student("Bob4", 3.9);
            Student student5 = new Student("Bob5", 3.5);

            Student[] students = { student1, student2, student3, student4, student5 };

            switch (userSelection)
            {
                case "1":
                    BubbleSort(students);
                    break;
                case "2":
                    SelectionSort(students);
                    break;
                case "3":
                    InsertionSort(students);
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

            PrintArray(students);

            int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
            MergeSort(mergeArray);
            PrintArray(mergeArray);
        }

        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                leftSubArray[i] = arr[i];
            }

            for (int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i - mid] = arr[i];
            }

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);

            Merge(arr, leftSubArray, rightSubArray);
        }

        public static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k++] = left[i++];
                }
                else
                {
                    arr[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                arr[k++] = left[i++];
            }

            while (j < right.Length)
            {
                arr[k++] = right[j++];
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void PrintArray(Student[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item.name}: {item.gpa} ");
            }
            Console.WriteLine();
        }

        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int priorIndex = i - 1;

                while (priorIndex >= 0 && arr[priorIndex] > temp)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                arr[priorIndex + 1] = temp;
            }
        }

        public static void InsertionSort(Student[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                Student temp = arr[i];
                int priorIndex = i - 1;

                while (priorIndex >= 0 && arr[priorIndex].gpa < temp.gpa)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                arr[priorIndex + 1] = temp;
            }
        }

        public static void BubbleSort(int[] arrToSort)
        {
            int temp;
            for (int i = 0; i < arrToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)
                {
                    if (arrToSort[j] > arrToSort[j + 1])
                    {
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
            }
        }

        public static void BubbleSort(Student[] arrToSort)
        {
            Student temp;
            for (int i = 0; i < arrToSort.Length - 1; i++)
            {
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)
                {
                    if (arrToSort[j].gpa < arrToSort[j + 1].gpa)
                    {
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] arrToSort)
        {
            int minIndex, temp;

            for (int i = 0; i < arrToSort.Length; i++)
            {
                minIndex = i;
                for (int j = i; j < arrToSort.Length; j++)
                {
                    if (arrToSort[j] < arrToSort[minIndex])
                    {
                        minIndex = j;
                    }
                }

                temp = arrToSort[i];
                arrToSort[i] = arrToSort[minIndex];
                arrToSort[minIndex] = temp;
            }
        }

        public static void SelectionSort(Student[] arrToSort)
        {
            int minIndex;
            Student temp;

            for (int i = 0; i < arrToSort.Length; i++)
            {
                minIndex = i;
                for (int j = i; j < arrToSort.Length; j++)
                {
                    if (arrToSort[j].gpa > arrToSort[minIndex].gpa)
                    {
                        minIndex = j;
                    }
                }

                temp = arrToSort[i];
                arrToSort[i] = arrToSort[minIndex];
                arrToSort[minIndex] = temp;
            }
        }
    }

    public class Student
    {
        public string name;
        public double gpa;

        public Student(string name, double gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }
    }
}
