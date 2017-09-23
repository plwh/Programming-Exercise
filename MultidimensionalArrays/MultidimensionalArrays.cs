using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionalArrays
{
    class MultidimensionalArrays
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[2, 2];
            for (int rows = 0; rows < matrix.GetLength(0); rows++ )
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write("matrix[{0},{1}]:", rows, cols);
                    matrix[rows, cols] = int.Parse(Console.ReadLine());
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.WriteLine("Matrix element [{0},{1}] has value = {2}", rows, cols, matrix[rows, cols]);
                }
            }
        }
    }
}
