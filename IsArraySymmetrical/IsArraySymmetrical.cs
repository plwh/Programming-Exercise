using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsArraySymmetrical
{
    class Test
    {
        public static bool IsArraySymmetrical(int[] array)
        {
            for (int i = 0; i < array.Length / 2;i++)
            {
                if(array[i] != array[array.Length-i-1])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 5, 6, 7, 6, 5, 2, 1 };
            Console.WriteLine("We are given array:");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Is array symmetrical? {0}", IsArraySymmetrical(array) ? "Yes" : "No");
        }
    }
}
