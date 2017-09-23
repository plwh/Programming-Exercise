using System;

class Algorithms
{
    // Sorting a one dimensional array
    public static int[] SortArray(int[] array)
    {
        for(int i=array.Length-1; i>=0; i--)
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
    // Check if array is symmetrical
    public static bool IsArrSymmetrical(int[] arr)
    {
        for (int i = 0; i < arr.Length / 2; i++)
        { 
            if(arr[i] != arr[arr.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
    // Merging two sorted arrays into third sorted
    public static int[] MergeSort(int[] a, int[] b)
    {
        int i = 0, j = 0, k = 0;
        int[] result = new int[a.Length + b.Length];
        while (i < a.Length && j < b.Length)
        {
            if (a[i] < b[j])
            {
                result[k] = a[i];
                i++;
            }
            else
            {
                result[k] = b[j];
                j++;
            }
            k++;
        }
        while (i < a.Length)
        {
            result[k] = a[i];
            i++;
            k++;
        }
        while(j < b.Length)
        {
            result[k] = b[j];
            j++;
            k++;
        }
        return result;
    }
    // Check whether a string is a palindrome
    public static bool IsPalindrome(string text)
    {
        int min = 0, max = text.Length - 1;
        while (true)
        {
            if (min > max)
                return true;

            char a = text[min];
            char b = text[max];
            while (!char.IsLetterOrDigit(a))
            {
                min++;
                if(min > max)
                    return true;

                a = text[min];
            }

            while (!char.IsLetterOrDigit(b))
            {
                max--;
                if (min > max)
                    return true;

                b = text[max];
            }

            if (char.ToLower(a) != char.ToLower(b))
                return false;

            min++;
            max--;
        }
    }
    // NFactiorial iterative
    public static decimal CalcFactorialIterative(int number)
    {
        decimal factorial = 1;
        if(number == 0)
        {
            return 1;
        }
        else if(number < 0)
        {
            return -1;
        }
        else
        { 
            for(int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
        }
        return factorial;
    }
    // NFactorial recursive
    public static decimal CalcFactorialRecursive(int number)
    {
        if (number <= 1)
        {
            return 1;
        }
        return number * CalcFactorialRecursive(number - 1);
    }

    public static string PrintArray(int[] array)
    {
        string result = "";
        foreach (int i in array)
        {
            result += i.ToString() + " ";
        }
        return result;
    }
    public static void Main()
    {
        int[] arrayOne = { 3, 1, 4, 2, 70, 32, 40 };
        int[] arrayTwo = { 3, 5, 7, 9, 12 };
        Console.WriteLine("We have array with elements: {0}", PrintArray(arrayOne));
        arrayOne = SortArray(arrayOne);
        Console.WriteLine("Array elements sorted: {0}", PrintArray(arrayOne));
        Console.WriteLine("Is sorted array symmetrical: {0}", IsArrSymmetrical(arrayOne));
        Console.WriteLine("We have second array with elements: {0}", PrintArray(arrayTwo));
        Console.WriteLine("First and second array merged into third sorted: {0}", PrintArray(MergeSort(arrayOne, arrayTwo)));
        string str = "A toyota. Race fast, safe car. A toyota.";
        Console.WriteLine("We have string: {0}", str);
        Console.WriteLine("Is string a palindrome: {0}", IsPalindrome(str) ? "Yes" : "No");
        Console.Write("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("N Factorial - recursive: {0} iterative: {1}", CalcFactorialRecursive(number), CalcFactorialIterative(number));
    }    
}