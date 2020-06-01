using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _602
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] Num = s.Split();
            int n = int.Parse(Num[0]);

            int[] a = new int[n-1];
            s = Console.ReadLine();
            Num = s.Split();
            int j = 0;
            int min = 0;
            for (int i = 0; i < n - 1; i++)
            {
                a[i] = Math.Abs(int.Parse(Num[i + 1]) - int.Parse(Num[i]));
                if (a[i] < a[min])
                    min = i;
            }

            Console.WriteLine(Num[min] + " " + Num[min + 1]);
            Console.ReadLine();
        }
    }
}
