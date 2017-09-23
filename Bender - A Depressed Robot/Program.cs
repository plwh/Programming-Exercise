using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());
        int[] budgets = new int[N];
        List<int> results = new List<int>();
        int maxBudget = 0;
        int numberToAdd = 0;
        for (int i = 0; i < N; i++)
        {
            int B = int.Parse(Console.ReadLine());
            budgets[i] = B;
            maxBudget += B;
        }
        Array.Sort(budgets);
        if (maxBudget < C)
        {
            Console.WriteLine("IMPOSSIBLE");
        }
        else
        {
            for (int j = 0; j < budgets.Length; j++)
            {
                for (int k = 0; k < budgets[j]; k++)
                {
                    numberToAdd++;
                    maxBudget--;
                }
                results.Add(numberToAdd);
                numberToAdd = 0;
            }
        }
        foreach (int i in results)
        {
            Console.WriteLine(i);
        }
    }
}