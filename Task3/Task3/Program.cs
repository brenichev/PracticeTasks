using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            Console.WriteLine("Введите действительное число");
            bool check = double.TryParse(Console.ReadLine(), out a);

            while(check == false)
            {
                Console.WriteLine("Введите действительное число");
                check = double.TryParse(Console.ReadLine(), out a);
            }

            if (a < 1)
                Console.WriteLine(a);
            else
                if (a >= 1 && a <= 2)
                Console.WriteLine(1);
            else
                Console.WriteLine(-2 * a + 5);
        }
    }
}
