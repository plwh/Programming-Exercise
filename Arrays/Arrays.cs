using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Arrays
    {
        public static int[] Merge(int[] a, int[] b)
        {
            int i = 0, j = 0, k = 0;
            int[] answer = new int[a.Length + b.Length];
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    answer[k] = a[i];
                    i++;
                }
                else
                {
                    answer[k] = b[j];
                    j++;
                }
                k++;
            }
            while (i < a.Length)
            {
                answer[k] = a[i];
                i++;
                k++;
            }
            while (j < b.Length)
            {
                answer[k] = b[j];
                j++;
                k++;
            }
            return answer;
        }
        
        static void Main(string[] args)
        {
            int[] firstArray = new int[4]{ 2, 6, 10, 17 };
            int[] secondArray = new int[4] { 4, 8, 12, 18};
            int[] thirdArray = Merge(firstArray,secondArray);
            foreach (int i in thirdArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

    }
}
