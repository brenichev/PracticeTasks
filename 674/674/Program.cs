using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _674
{
    class Program
    {
        static double Del(double num)
        {
            if (num == 3)
                return 1;
            else
                if (num == 1 || num == 2 || num == 0)
                return 0;
            else
                if (num % 2 == 0)
                return Del((int)num / 2) * 2;
            else
                return Del((int)num / 2) + Del((int)num / 2 + (int)num % 2);
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = 0;
            bool check = int.TryParse(input, out n);
            if (!check)
            {
                Console.WriteLine(0);
                return;
            }

            double res = Del(n);
            Console.WriteLine(res);
        }
    }
}
