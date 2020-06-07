using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task10
{
    class Graph
    {
        int size;
        byte[,] matrix;
        int[] values;

        public Graph(int Size, int[] Val, byte[,] Matrix)
        {
            this.size = Size;
            matrix = Matrix;
            values = Val;
        }

        public static Graph ReadMatrix()
        {
            int size = 0;
            bool check = true;
            do
            {
                check = int.TryParse(Console.ReadLine(), out size);
            } while (!check);

            int[] values = new int[size];
            int i = 0;
            do
            {
                Console.WriteLine("Введите значения вершин графа ");
                string[] row = Console.ReadLine().Split(' ');
                while (check && i < size)
                {
                    check = int.TryParse(row[i], out values[i]);
                    i++;
                }
                if (!check || i < size)
                    Console.WriteLine("Неверно введены значения графа");
            } while (!check);

            i = 0;
            byte[,] matrix = new byte[size, size];
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
                        j++;
                    }
                    if (check)
                        i++;
                }
                if (!check)
                    Console.WriteLine("У элемента с номером " + j + " неверный тип данных");
            } while (i < size);
            return new Graph(size, values, matrix);
        }

        public void WriteMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }

        // Чтение графа из файла
        public static Graph ReadGraph(string P)
        {
            try
            {
                FileStream File = new FileStream(P, FileMode.Open);
                StreamReader sr = new StreamReader(File);
                // Размер графа
                int Size;
                // Флаг правильности ввода
                bool ok = Int32.TryParse(sr.ReadLine(), out Size);
                // Массив значений
                string vals = sr.ReadLine();
                int[] Val = new int[Size];
                if (vals.Length > Size * 2 - 1)
                    vals = vals.Remove(Size * 2 - 1);
                Val = vals.Split(' ').Select(n => Int32.Parse(n)).ToArray();
                // Матрица смежности
                byte[,] Matrix = new byte[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    vals = sr.ReadLine();
                    if (vals.Length > Size * 2 - 1)
                        vals = vals.Remove(Size * 2 - 1);
                    // Чтение строки матрицы
                    byte[] Row = vals.Split(' ').Select(n => Byte.Parse(n)).ToArray();
                    for (int j = 0; j < Size; j++)
                    {
                        if (Row[j] != 0 && Row[j] != 1)
                        {
                            Console.WriteLine("В файле содержатся некорректные данные.");
                            return null;
                        }
                        Matrix[i, j] = Row[j];
                    }
                }

                sr.Close();
                File.Close();

                return new Graph(Size, Val, Matrix);
            }
            catch
            {
                Console.WriteLine("Не удается открыть файл, проверьте его наличие и правильность пути.");
                return null;
            }
        }

        // Запись графа в файл
        public void WriteGraph(string P)
        {
            P = Path.GetDirectoryName(P) + Path.GetFileNameWithoutExtension(P) + "output" + Path.GetExtension(P);
            FileStream File;
            try
            {
                File = new FileStream(P, FileMode.Truncate);
            }
            catch (FileNotFoundException)
            {
                File = new FileStream(P, FileMode.CreateNew);
            }
            StreamWriter sw = new StreamWriter(File);
            // Размер графа
            sw.WriteLine(size);
            // Массив значений
            foreach (int item in values)
                sw.Write(item + " ");
            sw.WriteLine();
            // Матрица смежности
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    sw.Write(matrix[i, j] + " ");
                sw.WriteLine();
            }

            Console.WriteLine("Информация об обработанном графе записана в файл " + P);

            sw.Close();
            File.Close();
        }

        // Стягиевание графа
        public void Contraction(int Val)
        {
            // Если искомое значение отсутствует в графе
            if (!values.Contains(Val))
            {
                Console.WriteLine("В графе нет вершины с указанным значением");
                return;
            }
            // Номер вершины, где впервые встречается искомое значение
            int FirstVertex = Array.IndexOf(values, Val);

            int i = FirstVertex + 1;
            // Проходим по оставшимся вершинам графа
            while (i < size)
            {
                // Если нашлась еще одна вершина с искомым значением
                if (values[i] == Val)
                {
                    // Переносим ребра
                    // Перенос ребер, исходящих из этой вершины
                    for (int col = 0; col < size; col++)
                        // Если из данной вершины исходит ребро (но не в точку, в которую стягиваем, чтобы не было петлей)
                        if (matrix[i, col] == 1 && col != FirstVertex)
                            // Переносим начало ребра в вершину, куда стягиваем
                            matrix[FirstVertex, col] = 1;

                    // Перенос ребер, входящих в эту вершину
                    for (int row = 0; row < size; row++)
                        // Если в данную вершину входит ребро (но не из точки, в которую стягиваем, чтобы не было петлей)
                        if (matrix[row, i] == 1 && row != FirstVertex)
                            // Переносим конец ребра в вершину, куда стягиваем
                            matrix[row, FirstVertex] = 1;

                    // Удаление вершины из графа
                    RemoveVertex(i);
                }
                else
                    i++;
            }
        }

        // Удаление вершины графа
        void RemoveVertex(int index)
        {
            // Удаление значения
            int[] NewValues = new int[size - 1];
            for (int i = 0; i < index; i++)
                NewValues[i] = values[i];
            for (int i = index + 1; i < size; i++)
                NewValues[i - 1] = values[i];
            values = NewValues;

            // Удаление вершины из матрицы
            byte[,] NewMatrix = new byte[size - 1, size - 1];

            // Копирование незатронутой части
            for (int i = 0; i < index; i++)
                for (int j = 0; j < index; j++)
                    NewMatrix[i, j] = matrix[i, j];
            // Удаление столбца
            for (int i = 0; i < NewMatrix.GetLength(0); i++)
                for (int j = index; j < NewMatrix.GetLength(1); j++)
                    NewMatrix[i, j] = matrix[i, j + 1];
            // Удаление строки
            for (int i = index; i < NewMatrix.GetLength(0); i++)
                for (int j = 0; j < NewMatrix.GetLength(1); j++)
                    NewMatrix[i, j] = matrix[i + 1, j];
            matrix = NewMatrix;

            size--;
        }
    }
}
