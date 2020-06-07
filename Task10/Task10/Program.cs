using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        public static void ReadMatrix(ref int size, ref int[] values, ref byte[,] matrix)
        {
            bool check = true;
            do
            {
                check = int.TryParse(Console.ReadLine(), out size);
            } while (!check);

            int[] Nums = new int[size];
            int i = 0;
            do
            {
                Console.WriteLine("Введите значения вершин графа ");
                string[] row = Console.ReadLine().Split(' ');
                values = new int[size];
                while (check && i < size)
                {
                    check = int.TryParse(row[i], out values[i]);
                    i++;
                }
                if (!check || i < size)
                    Console.WriteLine("Неверно введены значения графа");
            } while (!check);

            i = 0;
            matrix = new byte[size,size];
            do
            {
                Console.WriteLine("Введите строку матрицы графа с номером " + (i + 1));
                string[] row = Console.ReadLine().Split(' ');
                check = true;
                int j = 0;
                if (row.Length != size)
                    Console.WriteLine("Элементов в строке должно быть " + size + ", введено = " + row.Length);
                else
                {
                    while (check && j < size)
                    {
                        check = byte.TryParse(row[j], out matrix[i, j]);
                        if (matrix[i, j] != 0 && matrix[i, j] != 1)
                            check = false;
                        j++;
                    }
                    if (check)
                        i++;
                }
                if (!check)
                    Console.WriteLine("У элемента с номером " + j + " неверный тип данных");
            } while (i < size);
        }

        static void Main(string[] args)
        {
            Graph graph = Graph.ReadMatrix();

            int userChoice;
            bool check = true;
            do
            {
                check = int.TryParse(Console.ReadLine(), out userChoice);
            }while (!check);

            graph.Contraction(userChoice);
            graph.WriteMatrix();
        }
    }
}
