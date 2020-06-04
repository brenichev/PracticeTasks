using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Sequence(ref double[] a, int N, int last)
        {
            if (last < N)
                a[last] = 13 * a[last - 1] - 10 * a[last - 2] + a[last - 3];
            else
                return;
            last++;
            Sequence(ref a, N, last);
        }
        static void Main(string[] args)
        {
            bool check = true;
            int N = 0;
            double[] a = new double[3];
            do
            {
                check = true;
                Console.WriteLine("Введите a1, a2, a3, N (в одной строке, через пробел)");
                string s = Console.ReadLine();
                string[] input = s.Split(' ');
                if (input.Length != 4)
                {
                    Console.WriteLine("Неверный ввод");
                    check = false;
                }
                else
                {
                    check = double.TryParse(input[0], out a[0]);
                    if (check)
                    {
                        check = double.TryParse(input[1], out a[1]);
                        if (check)
                        {
                            check = double.TryParse(input[2], out a[2]);
                            if (check)
                            {
                                check = int.TryParse(input[3], out N);
                            }
                        }
                    }
                    if (!check)
                        Console.WriteLine("Неверный ввод");
                }
            } while (check != true);

            int last = 3;
            Array.Resize(ref a, N);
            Sequence(ref a, N, last);

            int i = 1;
            bool grow = true;
            while (grow != false && i < N)
            {
                if (a[i] < 0)
                    grow = false;
                else
                    if (i + 2 < N)
                    i = i + 2;
                else
                    i = N;
            }
            Console.WriteLine(a[N - 1]);
            if (grow)
                Console.WriteLine("Элементы, стоящие на четных местах образуют возрастающую последовательность");
            else
                Console.WriteLine("Элементы, стоящие на четных местах не образуют возрастающую последовательность");


        }
    }
}
