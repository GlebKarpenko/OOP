using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Program main = new Program();
        main.menu();
    }

    void menu()
    {
        menuHead();
        int choice = 0;
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 0: break;

            case 1:
                int[] array1 = readArray();
                double result = geometricMean(array1);
                Console.WriteLine("Середнє геометричне: " + result);
                menu();
                break;

            case 2:
                double[] vector1 = multiplyVector();
                Console.Write("\nКоординати вектора: ");
                foreach (double element in vector1)
                {
                    Console.Write(element + "  ");
                }
                Console.WriteLine();
                menu();
                break;

            case 3:
                int[] array2 = readArray();
                int[] array2Sorted = sortArrayInReverse(array2);
                Console.WriteLine("відсортований масив: ");
                printArray(array2Sorted);
                menu();
                break;

            case 4:
                int[,] matrix1 = readMatrix();
                matrix1 = sortOddRows(matrix1);
                printMatrix(matrix1);
                menu();
                break;

            case 5 :
                int[,] matrix2 = readMatrix();
                int n = matrix2.GetLength(0);
                int m = matrix2.GetLength(1);
                int[] column = new int[n];
                int NofNonZeroColumns = 0;

                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        column[i] = matrix2[i, j];
                    }
                    if (searchElement(column, 0) == -1)
                        NofNonZeroColumns++;
                }
                Console.WriteLine("Кількість колонок, які не містять нуль: " + NofNonZeroColumns);
                menu();
                break;

            case 6 :
                int[,] matrix3 = readMatrix();
                matrix3 = sortMatrixRows(matrix3);
                Console.WriteLine("Матриця з відсортованими рядками: ");
                printMatrix(matrix3);
                menu();
                break;
        }
    }

    void menuHead()
    {
        Console.WriteLine("\n----------------------------------" +
     "\n|             МЕНЮ               |" +
     "\n----------------------------------" +
     "\n1.(1.1) Дано n дійсних чисел: x1, x2,..., xn. Знайти середнє геометричне значення цих чисел." +
     "\n2.(1.2) Дано вектор x і число a. Знайти добуток вектора на число." +
     "\n3.(1.3) Впорядкувати елементи масиву за спаданням" +
     "\n4.(2.1) Розмістити елементи непарних рядків у порядку зростання" +
     "\n5.(2.2) Дана цілочислова прямокутна матриця. Визначити кількість стовпців, " +
     "які не містять жодного нульового елемента" +
     "\n6.(2.3) Дана цілочислова прямокутна матриця. Переставляючи рядки даної матриці, " +
     "розташувати їх у відповідності з ростом характеристик. " +
     "Характеристикою рядка цілочислової матриці назвемо суму її додатних парних елементів." +
     "\n0. (0.0) Завершити роботу.)");
    }

    int[] readArray()
    {
        Console.WriteLine("Введіть розмірність масиву: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[size];
        Console.WriteLine("Введіть елементи масиву: ");

        for (int i = 0; i < size; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        return array;
    }

    void printArray(int[] array)
    {
        foreach (double element in array)
        {
            Console.Write(element + "  ");
        }
    }

    double geometricMean(int[] array)
    {
        double GM = 1;
        for (int i = 0; i < array.Length; i++)
        {
            GM *= array[i];
        }
        return Math.Pow(GM, 1.0 / array.Length);
    }

    double[] multiplyVector()
    {
        Console.WriteLine("Введіть вимірність вектора: ");
        int dimension = Convert.ToInt32(Console.ReadLine());
        double[] resultVector = new double[dimension];

        Console.WriteLine("Введіть мультиплікатор вектора: ");
        double multiplicator = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть координати вектора");
        for (int i = 0; i < dimension; i++)
        {
            resultVector[i] = Convert.ToDouble(Console.ReadLine()) * multiplicator;
        }
        return resultVector;
    }

    int[] sortArrayInReverse(int[] array)
    {
        array = sortArray(array);
        int j = array.Length - 1;
        int[] reversedArray = new int[j + 1];

        for (int i = 0; i < array.Length; i++)
        {
            reversedArray[i] = array[j];
            j--;
        }
        return reversedArray;
    }

    int[] sortArray(int[] array)
    {
        Array.Sort(array);
        return array;
    }

    int[,] readMatrix()
    {
        Console.WriteLine("Введіть кількість рядків матриці: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введіть кількість стовпців матриці: ");
        int m = Convert.ToInt32(Console.ReadLine());
        int[,] matrix = new int[n, m];

        Console.WriteLine("Введіть елементи матриці: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        return matrix;
    }

    void printMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }

    int[,] sortOddRows(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] row = new int[m];

        for (int i = 0; i < n; i += 2)
        {
            for (int j = 0; j < m; j++)
            {
                row[j] = matrix[i, j];
            }
            row = sortArray(row);
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = row[j];
            }
        }
        return matrix;
    }

    int searchElement(int[] array, int element)
    {
        int index = Array.IndexOf(array, element) ;
        return index;
    }

    int[,] sortMatrixRows(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[,] sortedMatrix = new int[n,m];
        Dictionary<int, int> characteristics = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 0; j < m; j++)
            {
                sortedMatrix[i, j] = matrix[i, j];
                if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                {
                    sum += matrix[i, j];
                }
            }
            characteristics.Add(i, sum);
        }

        int rowIndex = 0;
        foreach (KeyValuePair<int, int> rowSum in characteristics.OrderBy(key => key.Value))
        {
            if (rowIndex >= n)
            {
                break;
            }
            for (int j = 0; j < m; j++)
            {
                sortedMatrix[rowIndex, j] = matrix[rowSum.Key, j];
            }
            rowIndex++;
        }
        return sortedMatrix;
    }
}