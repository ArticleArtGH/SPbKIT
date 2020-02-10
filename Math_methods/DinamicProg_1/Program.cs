using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Console;

namespace DinamicProg_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = {{0,8,6,9,9},
                        {1,5,7,8,9},
                        {2,3,2,5,9},
                        {3,5,7,9,8},
                        {4,4,6,7,8},
                        {1,4,6,9,1}},
 
            B = {{1,8,9,8,7,8},
                {3,5,6,7,6,6},
                {2,2,4,5,4,3},
                {2,3,4,5,2,1},
                {2,4,3,2,9,9}};

            int i = 0, j = 0;
            Console.WriteLine("Массив A = \n");
            for (i = A.GetLength(0)-1;i>-1;i--)
            {
                for (j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write(" "+A[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Массив B = \n");
            for (i = B.GetLength(0) - 1; i > -1; i--)
            {
                for (j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(" " + B[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //Определени max i и j
            int getLength_i = A.GetLength(0) > B.GetLength(0) ? A.GetLength(0) : B.GetLength(0);
            int getLength_j = A.GetLength(1) > B.GetLength(1) ? A.GetLength(1) : B.GetLength(1);
            Console.WriteLine("Массив A и B = \n");
            for (i = getLength_i - 1; i > -1; i--)
            {
                for (j = 0; j < getLength_j; j++)
                {
                    if(A.GetLength(0)> i && A.GetLength(1) > j)
                    {
                        Console.Write("  " + A[i, j]);
                    }
                }
                Console.WriteLine();
                for (j = 0; j < getLength_j; j++)
                {
                    if (B.GetLength(0) > i && B.GetLength(1) > j)
                    {
                        Console.Write(" " + B[i, j]);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }
    }
}
