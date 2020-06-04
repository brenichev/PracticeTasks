﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace Task5
{
    public class Program
    {
        public static void res(double[,] matrix, ref int[,] matrix2)
        {
            for (int t = 0; t < 9; t++)
            {
                for (int f = 0; f < 9; f++)
                {
                    if (matrix[t, f] > matrix[t, t])
                        matrix2[t, f] = 1;
                    else
                        matrix2[t, f] = 0;
                }
            }
        }

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            int i = 0;
            double[,] matrix = new double[9, 9];
            int[,] matrix2 = new int[9, 9];
            bool check = true;
            do
            {
                Console.WriteLine("Введите строку матрицы с номером " + (i + 1));
                string[] row = Console.ReadLine().Split(' ');
                check = true;
                int j = 0;
                if (row.Length != 9)
                    Console.WriteLine("Элементов в строке должно быть 9, введено = " + row.Length);
                else
                {
                    while (check && j < 9)
                    {
                        check = double.TryParse(row[j], out matrix[i, j]);
                        j++;
                    }
                    if (check)
                        i++;
                }
                if (!check)
                    Console.WriteLine("У элемента с номером " + j + " неверный тип данных");
            } while (i < 9);

            Console.WriteLine();
            Console.WriteLine("=== Введенная матрица: ===");
            for (int t = 0; t < 9; t++)
            {
                for (int f = 0; f < 9; f++)
                    Console.Write(matrix[t, f] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            StreamWriter sw = new StreamWriter("OUTPUT.TXT");
            Console.WriteLine("=== Результат: ===");

            res(matrix, ref matrix2);
            for (int t = 0; t < 9; t++)
            {
                for (int f = 0; f < 9; f++)
                    Console.Write(matrix2[t, f] + " ");
                Console.WriteLine();
            }
            /*for (int t = 0; t < 9; t++)
            {
                sw.Write("{ ");
                for (int f = 0; f < 9; f++)
                {
                    sw.Write(matrix[t, f] + ", ");
                }
                //Console.WriteLine();
                sw.Write(" }, ");
            }
            sw.WriteLine();
            for (int t = 0; t < 9; t++)
            {
                sw.Write("{ ");
                for (int f = 0; f < 9; f++)
                {
                    if (matrix[t, f] > matrix[t, t])
                        matrix2[t, f] = 1;
                    else
                        matrix2[t, f] = 0;
                   // Console.Write(matrix2[t, f] + " ");
                    sw.Write(matrix2[t, f] + ", ");
                }
                //Console.WriteLine();
                sw.Write(" }, ");
            }
            sw.Close();*/

        }
    }
}