using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Program
    {
        public static double func(double x)
        {            
            return (x + Math.Log(x + 0.5) - 0.5);
        }

        public static double res(double xn, double xk, double eps)
        {
            double xi = 0;
            while (xk - xn > eps)
            {
                double dx = (xk - xn) / 2;
                xi = xn + dx;
                if (func(xn) * func(xk) < 0)
                    xk = xi;
                else
                    xn = xi;
            }
            return xi;
        }
        static void Main(string[] args)
        {
            double eps = 0;
            bool check = true;
            do
            {
                Console.WriteLine("Введите точность вычисления: ");
                check = double.TryParse(Console.ReadLine(), out eps);
                if (!check)
                    Console.WriteLine("Неверный формат числа");
            } while (!check);


            double xn, xk, xi;
            xn = 0;
            xk = 2;
            xi = 0;
            if (func(xn) == 0)
                Console.WriteLine("Корень уравнения = " + xn);
            else
            if(func(xk) == 0)
                Console.WriteLine("Корень уравнения = " + xk);
            else
            {
                xi = res(xn, xk, eps);
                Console.WriteLine("Корень уравнения = " + xi + " с точностью по y = " + eps);
            }
        }
    }
}
