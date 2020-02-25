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
        static void Output(int[,] A, int[,] B, int[,] C)
        {
            int i = 0, j = 0;
            int iA = A.GetLength(0) - 1, jA = 0, kA = iA - 1, iB = B.GetLength(0) - 1, jB = 0, kB = iB - 1;

            for (int iC = C.GetLength(0) - 1; iC > -1; iC--)
            {
                for (int jC = 0; jC < C.GetLength(1); jC++)
                {
                    if (iC == 0 && jC != 5)
                    {
                        Console.Write(C[iC, jC] + "--");
                    }
                    if (jC == 5)
                    {
                        Console.Write(C[iC, jC]);
                    }
                    if (iC != 0 && jC != 5)
                    {
                        Console.Write(C[iC, jC] + "--");
                    }
                }
                Console.WriteLine();

                for (iA = iA; iA > kA; iA--)
                {
                    for (jA = 0; jA < A.GetLength(1); jA++)
                    {
                        if (iA == 0)
                        {
                            Console.Write("  " + A[iA, jA]);
                        }
                        else
                        {
                            if (jA == 0)
                            {
                                Console.Write("| " + A[iA, jA] + "|");
                            }
                            else
                            {
                                Console.Write(" " + A[iA, jA] + "|");
                            }
                        }
                    }
                }
                kA = --kA;
                Console.WriteLine();

                if (iB < 0)
                {
                    break;
                }
                for (iB = iB; iB > kB; iB--)
                {
                    for (jB = 0; jB < B.GetLength(1); jB++)
                    {
                        if (jB == 0)
                        {
                            Console.Write("|");
                        }
                        if (jB == B.GetLength(1) - 1)
                        {
                            Console.Write(B[iB, jB]);
                        }
                        else
                        {
                            Console.Write(B[iB, jB] + " |");
                        }
                    }
                }
                kB = --kB;
                Console.WriteLine();
            }
        }
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
                {2,4,3,2,9,9}},

            C = new int[6,6];

            Console.WriteLine("Изначально");
            Output(A,B,C);
            
            for(int i = 0; i < C.GetLength(0); i++)
                for(int j = C.GetLength(1); j>-1; j--)
                {
                    if (i == 0 && j == 5)
                    {
                        C[i, j] = 0;
                    }
                    if (i == 0 && j == 4)
                    {
                        C[i, j] = A[0, 4];
                    }
                    if (i == 1 && j == 5)
                    {
                        C[i, j] = B[0, 5];
                    }
                }
            Console.WriteLine("\nС найденым С");
            Output(A, B, C);

            ////Определени max i и j
            //int getLength_i = A.GetLength(0) > B.GetLength(0) ? A.GetLength(0) : B.GetLength(0);
            //int getLength_j = A.GetLength(1) > B.GetLength(1) ? A.GetLength(1) : B.GetLength(1);
            //Console.WriteLine("Массив A и B = \n");
            //int i = 0, j = 0;
            //for (i = getLength_i - 1; i > -1; i--)
            //{
            //    for (j = 0; j < getLength_j; j++)
            //    {
            //        if (A.GetLength(0) > i && A.GetLength(1) > j)
            //        {
            //            Console.Write("  " + A[i, j]);
            //        }
            //    }
            //    Console.WriteLine();
            //    for (j = 0; j < getLength_j; j++)
            //    {
            //        if (B.GetLength(0) > i && B.GetLength(1) > j)
            //        {
            //            Console.Write(" " + B[i, j]);
            //        }
            //    }
            //    Console.WriteLine();

            //    for (i = 5; i > -1; i--)
            //    {
            //        for (j = 5; j > -1; i--)
            //        {
            //            C[i, j] = (i == 5 && j == 5) ? 0 :  ;//!!! C[i,j]=C[i,j]+C[i,j-1]
            //        }
            //    }
            //}

            //Console.WriteLine("Массив A = \n");
            //for (i = A.GetLength(0)-1;i>-1;i--)
            //{
            //    for (j = 0; j < A.GetLength(1); j++)
            //    {
            //        Console.Write(" "+A[i,j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine("Массив B = \n");
            //for (i = B.GetLength(0) - 1; i > -1; i--)
            //{
            //    for (j = 0; j < B.GetLength(1); j++)
            //    {
            //        Console.Write(" " + B[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            Console.ReadKey(true);
        }
    }
}
