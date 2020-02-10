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

            for(int i = A.GetLength(0);i>0;i--)
            {
                for (int j = A.GetLength(1); j > 0; j--)
                {
                    Console.WriteLine("Массив A = " + A[i, j]);

                }
                Console.WriteLine("/t");
            }

            Console.ReadKey(true);
        }
    }
}
