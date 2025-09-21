using System;

namespace EX01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part 1: Create and display predefined jagged array
            int[][] jaggedArray1 = new int[4][];
            jaggedArray1[0] = new int[] { 1, 1, 1, 1, 1 };
            jaggedArray1[1] = new int[] { 2, 2 };
            jaggedArray1[2] = new int[] { 3, 3, 3, 3 };
            jaggedArray1[3] = new int[] { 4, 4 };
            Console.WriteLine("Predefined Jagged Array:");
            PrintJaggedArray(jaggedArray1);

            // Part 2: Create jagged array with user input
            Console.Write("\nEnter number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray2 = new int[rows][];
            Random rand = new Random();

            // Initialize array with user-defined or random values
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Enter number of columns for row {i + 1}: ");
                int cols = int.Parse(Console.ReadLine());
                jaggedArray2[i] = new int[cols];
                Console.Write($"Enter {cols} values for row {i + 1} (or press Enter for random): ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    for (int j = 0; j < cols; j++)
                        jaggedArray2[i][j] = rand.Next(1, 51); // Random numbers 1-50
                }
                else
                {
                    string[] values = input.Split(' ');
                    for (int j = 0; j < cols; j++)
                        jaggedArray2[i][j] = int.Parse(values[j]);
                }
            }

            // Display the array
            Console.WriteLine("\nUser Jagged Array:");
            PrintJaggedArray(jaggedArray2);

            // Task 1: Print biggest number of each row and largest overall
            PrintMaxNumbers(jaggedArray2);

            // Task 2: Sort each row ascending
            SortRows(jaggedArray2);
            Console.WriteLine("\nJagged Array after sorting each row:");
            PrintJaggedArray(jaggedArray2);

            // Task 3: Print prime numbers
            Console.WriteLine("\nPrime numbers in the array:");
            PrintPrimes(jaggedArray2);

            // Task 4: Search for a number and print its positions
            Console.Write("\nEnter a number to search: ");
            int searchValue = int.Parse(Console.ReadLine());
            SearchNumber(jaggedArray2, searchValue);

            Console.ReadLine();
        }

        // Print jagged array
        static void PrintJaggedArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Row " + (i + 1) + ": " + string.Join(" ", array[i]));
            }
        }

        // Task 1: Find max in each row and overall
        static void PrintMaxNumbers(int[][] array)
        {
            int overallMax = array[0][0];
            Console.WriteLine("\nMax number in each row:");
            for (int i = 0; i < array.Length; i++)
            {
                int rowMax = array[i][0];
                for (int j = 1; j < array[i].Length; j++)
                    if (array[i][j] > rowMax)
                        rowMax = array[i][j];
                Console.WriteLine($"Row {i + 1}: {rowMax}");
                if (rowMax > overallMax)
                    overallMax = rowMax;
            }
            Console.WriteLine("Largest number in array: " + overallMax);
        }

        // Task 2: Sort each row ascending
        static void SortRows(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    for (int k = 0; k < array[i].Length - j - 1; k++)
                    {
                        if (array[i][k] > array[i][k + 1])
                        {
                            int temp = array[i][k];
                            array[i][k] = array[i][k + 1];
                            array[i][k + 1] = temp;
                        }
                    }
                }
            }
        }

        // Task 3: Print prime numbers
        static void PrintPrimes(int[][] array)
        {
            bool found = false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (IsPrime(array[i][j]))
                    {
                        Console.WriteLine($"Prime at Row {i + 1}, Column {j + 1}: {array[i][j]}");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("No prime numbers found.");
        }

        // Helper: Check if a number is prime
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= number / 2; i++)
                if (number % i == 0)
                    return false;
            return true;
        }

        // Task 4: Search and print positions of a number
        static void SearchNumber(int[][] array, int value)
        {
            bool found = false;
            Console.WriteLine($"\nPositions of {value}:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == value)
                    {
                        Console.WriteLine($"Row {i + 1}, Column {j + 1}");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("Number not found.");
        }
    }
}