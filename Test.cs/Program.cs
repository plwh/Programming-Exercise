using System;
using System.Linq;
using System.Collections.Generic;

public class Test
{
    public static int[] BubbleSort(int[] array)
    {
        for(int i=array.Length-1; i >= 0; i--)
        {
            for (int j = 1; j < array.Length; j++)
            {
                if (array[j] < array[j - 1])
                {
                    var temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }
        }
        return array;
    }

    public static void PrintArray(int[] array)
    {
        foreach (int i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public static void PrintArray(IEnumerable<int> collection)
    {
        foreach (int i in collection)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public static bool IsArraySymmetrical(int[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        { 
            if(array[i] != array[array.Length-i-1])
            {
                return false;
            }
        }
        return true; 
    }

    static void Main()
    {
        int[] testArray = { 3, 10, 4, 20, 5, 8, 134, 56, 8, 79, 9 };
        Console.Write("Array elements unsorted: ");
        PrintArray(testArray);
        BubbleSort(testArray);
        Console.Write("Array elements sorted using BubbleSort algorithm: ");
        PrintArray(testArray);
        Console.WriteLine("Is the sorted array symmetrical? {0}", IsArraySymmetrical(testArray) ? "Yes" : "No");
        Console.WriteLine("All numbers in sorted array divisible by two without remainder(using lambda expression):");
        var arrayLambda = Array.FindAll(testArray, x => x % 2 == 0);
        PrintArray(arrayLambda);
        Console.WriteLine("All numbers in sorted array divisible by two without remainder(using LINQ):");
        var arrayLINQ = from result in testArray
                        where result % 2 == 0 
                        select result;
        PrintArray(arrayLINQ);
    }
}