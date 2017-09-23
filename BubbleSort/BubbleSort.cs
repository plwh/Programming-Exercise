using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrayAlgorithm
{
    class BubbleSort
    {
        public static int[] BubbleSortAlgorithm(int[] array)
        { 
            for(int j=array.Length-1;j>=0;j--)
            {
                for (int i = 1; i < array.Length;i++)
                {
                    if(array[i-1] > array[i])
                    {
                        int temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[4] { 4, 3, 1, 8 };
            int[] sorted = BubbleSortAlgorithm(arr);
            foreach (int i in sorted)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
