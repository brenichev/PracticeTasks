using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();

            /*grid.Str = "Это повторяется еще дважды. Таким образом, на бумагу наносится 100 букв текста. Решетку можно изобра";
            grid.Generate();
            Console.WriteLine();
            grid.Test();
            grid.Encode();
            Console.WriteLine(grid.Str);
            Console.WriteLine();
            grid.Decode();
            Console.WriteLine(grid.Str);
            Console.WriteLine();*/
            
            grid = Grid.Read();

            grid.Encode();
            Console.WriteLine(grid.Str);
            Console.WriteLine();
            grid.Decode();
            Console.WriteLine(grid.Str);
        }
    }
}
