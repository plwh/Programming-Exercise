// Sneaky the snake solution

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       string input = Console.ReadLine();
       string [] gridSize = input.Split('x');
       int startRow = 0;
       int startCol = 0;
       int move = 0;
       int currLength = 3;
       string[,] den = new string[int.Parse(gridSize[0]),int.Parse(gridSize[1])];

       for (int i = 0; i < den.GetLength(0); i++)
       {
           string lineToAdd = Console.ReadLine();
           for (int j = 0; j < lineToAdd.Length; j++)
           {
               if (lineToAdd[j] == 'e')
               {
                   startRow = i;
                   startCol = j;
               }
               den[i, j] = lineToAdd[j].ToString();
           }
       }
       string [] moves = Console.ReadLine().Split(',');
       while (move < moves.Length)
       {
           if ((move+1) % 5 == 0 )
           {
               currLength--;
           }
           switch (moves[move])
           { 
               case "s":
                   startRow++;
                   if (startRow == den.GetLength(0))
                   {
                       continue;
                   }
                   break;
               case "w":
                   startRow--;
                   break;
               case "a":
                   if (startCol == 0)
                   {
                       startCol = den.GetLength(1) - 1;
                       move++;
                       continue;
                   }
                   startCol--;
                   break;
               case "d":                
                   if (startCol == den.GetLength(1) - 1)
                   {
                       startCol = 0;
                       move++;
                       continue;
                   }
                   startCol++;
                   break;
           }
           if (currLength <= 0)
           {
               Console.WriteLine("Sneaky is going to starve at [{0},{1}]", startRow, startCol);
           }
           else if (startRow > den.GetLength(0))
           {
               Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", currLength);
               break;
           }
           else if (den[startRow, startCol] == "@")
           {
               den[startRow, startCol] = "eaten";
               currLength++;
           }
           else if (den[startRow, startCol] == "%")
           {
               Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", startRow, startCol);
               break;
           }
           else if (den[startRow, startCol] == "e")
           {
               Console.WriteLine("Sneaky is going to get out with length {0}", currLength);
               break;
           }
           move++;
           if (move == moves.Length)
           {
               Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", startRow, startCol);
           }
       }
    }
}
