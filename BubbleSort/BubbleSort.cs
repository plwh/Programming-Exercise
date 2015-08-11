using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrayAlgorithm
{
    class BubbleSort
    {
        public static int[] BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[4] { 4, 3, 1, 8 };
            int[] sorted = BubbleSort(arr);
            foreach (int i in sorted)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
