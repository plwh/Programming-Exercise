using System;

public class Palindrome
{
    /// <summary>
    /// Determines whether the string is a palindrome.
    /// </summary>
    public static bool IsPalindrome(string value)
    {
        int min = 0;
        int max = value.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char a = value[min];
            char b = value[max];

            // Scan forward for a while invalid.
            while (!char.IsLetterOrDigit(a))
            {
                min++;
                if (min > max)
                {
                    return true;
                }
                a = value[min];
            }

            // Scan backward for b while invalid.
                    while (!char.IsLetterOrDigit(b))
            {
                max--;
                if (min > max)
                {
                    return true;
                }
                b = value[max];
            }

            if (char.ToLower(a) != char.ToLower(b))
            {
                return false;
            }
            min++;
            max--;
        }
    } 


    public static void Main(string[] args)
    {
        Console.WriteLine(IsPalindrome("A Toyota. Race fast, safe car. A Toyota.")?"Yes":"No");
    }
}                                                                                                                                    