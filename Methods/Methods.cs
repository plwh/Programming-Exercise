using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class StaticMethodsTests
    {
        public class Methods
        {
            public void PrintTheArray(int[] arr)
            {
                foreach (int i in arr)
                {
                    Console.WriteLine(i);
                }
            }

            public static void PrintArray(int[] arr)
            {
                foreach (int i in arr)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("arr[{0}]:", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Methods a = new Methods();
            a.PrintTheArray(array);
            Console.WriteLine();
            Methods.PrintArray(array);
            Array.Sort(array);
            Console.WriteLine();
            Methods.PrintArray(array);
        }
    }
}
