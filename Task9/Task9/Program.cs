using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.Task(5);
            list.Show();

            Console.WriteLine();
            bool check = list.Remove(5);
            if (check)
                Console.WriteLine("Элемент удален");
            else
                Console.WriteLine("Такого элемента нет");
            list.Show();

            Console.WriteLine();
            int find = list.Search(4);
            if (find == -1)
                Console.WriteLine("Такого элемента нет");
            else
            Console.WriteLine("Заданный элемент находится на " + find + " месте");
        }
    }
}
