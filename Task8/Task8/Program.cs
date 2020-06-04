using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static int Menu()
        {
            Console.Clear();
            //Console.CursorVisible = false;

            int current = 0;
            int previous = 0;
            int positionX = 5, positionY = 2;
            bool Chosen = false;

            string[] items = { "Заполнение матрицы инциденций случайным образом", "Ручное заполнение матрицы инциденций", "Выход" };

            //Вывод пунктов меню
            for (int i = 0; i < items.Length; i++)
            {
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + i;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
            }

            do
            {

                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + previous;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previous]);

                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + current;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[current]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previous = current;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        current++;
                        if (current >= items.Length)
                            current = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        current--;
                        if (current < 0)
                            current = items.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        Chosen = true;
                        break;
                }
            }
            while (!Chosen);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
            return current;
        }
        static bool IsTree(int[,] a)
        {
            if (a.GetLength(1) - a.GetLength(0) != 1)
            {
                bool[] Checked = new bool[a.GetLength(0)];
                Checked[0] = true;
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    for (int i = 0; i < a.GetLength(1); i++)
                    {
                        if (a[j, i] == 1)
                        {
                            for (int k = 0; k < a.GetLength(0); k++)
                            {
                                if (a[k, i] == 1) { Checked[k] = true; }
                            }
                        }
                    }
                }
                for (int i = 0; i < Checked.Length; i++)
                {
                    if (Checked[i] == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[,] RandomGraph(int n)
        {
            int[,] b = new int[n, n];
            int[,] a = new int[n, n - 1];
            int[] bLength = new int[n];
            Random rnd = new Random();
            int num = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == j)
                        b[i, j] = -1;
                    else
                        b[i, j] = j;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                    a[i, j] = 0;

            for (int i = 0; i < n; i++)
                bLength[i] = n - 1;
            for (int i = 0; i < n; i++)
            {
                b[i, i] = b[i, bLength[i]];
                bLength[i]--;
            }
            /*for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                    Console.Write(b[i, j] + " ");
                Console.WriteLine();
            }*/
            for (int i = 0; i < n - 1; i++)
            {
                num = rnd.Next(0, bLength[i]);
                if (b[i, num] == -1)
                {
                    b[i, num] = b[i, bLength[i]];
                    bLength[i]--;
                }

                a[i, i] = 1;
                a[b[i, num], i] = 1;
            }
            return a;
        }

        static void Show(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int n = 5, m = 6;
            //int[,] a = new int[,] { { 0, 0, 1, 1, 0, 1 }, { 0, 0, 0, 1, 0, 0 }, { 1, 0, 0, 0, 1, 1 }, { 1, 1, 0, 0, 0, 0 }, { 0, 1, 1, 0, 1, 0 } };
            //int[,] a = new int[6, 5] { { 1, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 1, 1, 1, 0, 0 }, { 0, 0, 0, 1, 0 }, { 0, 0, 1, 1, 1 }, { 0, 0, 0, 0, 1 } };
            //int[,] a = new int[7, 6] { { 1, 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0, 0 }, { 0, 0, 0, 1, 0, 1 }, { 0, 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 1, 1 }, { 0, 0, 0, 0, 0, 0 } };
            int[,] a = new int[,] { { 0, 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0, 0 }, { 1, 0, 0, 1, 1, 0 }, { 1, 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } };
            bool f = false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine(a.GetLength(1));
            Console.WriteLine(a.GetLength(0));
            bool check = false;
            do
            {
                switch (Menu())
                {

                    case 0:
                        Console.CursorTop += 3;
                        a = RandomGraph(5);
                        Show(a);
                        Console.WriteLine();
                        if (IsTree(a))
                            Console.WriteLine("Дерево");
                        else
                            Console.WriteLine("Не дерево");
                        Console.ReadLine();
                        break;
                    case 1:
                        break;
                    case 2:
                        check = true;
                        break;
                }
            } while (!check);
        }
    }
}
