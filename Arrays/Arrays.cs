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
            while (j < b.Length)
            {
                result[k] = b[j];
                j++;
                k++;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[] firstArray = new int[4]{ 1, 3, 5, 7};
            int[] secondArray = new int[4] { 2, 4, 6, 8};
            int[] thirdArray = Merge(firstArray,secondArray);
            foreach (int i in thirdArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

    }
}
