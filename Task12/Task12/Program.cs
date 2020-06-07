using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {
        static void SortArr(ref int[,] arr, int i, int first, int last, ref int colComparBlock, ref int colTransBlock)
        {
            int L, R, c, x;
            colComparBlock++;
            if (first < last)
            {                
                x = arr[i, (first + last) / 2];
                L = first; R = last;
                colComparBlock++;
                while (L <= R)
                {
                    colComparBlock++;
                    while (arr[i, L] < x)
                    {
                        colComparBlock++;
                        L++;
                    }
                    colComparBlock++;
                    while (arr[i, R] > x)
                    {
                        colComparBlock++;
                        R--;
                    }
                    colComparBlock++;
                    if (L <= R)
                    {                        
                        colTransBlock += 3;
                        c = arr[i, L];
                        arr[i, L] = arr[i, R];
                        arr[i, R] = c;
                        L++;
                        R--;
                    }
                }
                SortArr(ref arr, i, first, R, ref colComparBlock, ref colTransBlock);
                SortArr(ref arr, i, L, last,  ref colComparBlock, ref colTransBlock);
            }
        }

        static void BlockSort(ref int[] a, ref int colComparBlock, ref int colTransBlock)
        {
            int max = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > max)
                    max = a[i];
            int[,] b = new int[max, a.Length];
            int[] exist = new int[a.Length];
            int[] Sizes = new int[max];
            for (int i = 0; i < a.Length; i++)
            {
                colTransBlock += 2;
                b[a[i] / 10, Sizes[(a[i] / 10)]] = a[i];                
                Sizes[(a[i] / 10)] = Sizes[(a[i] / 10)] + 1;
                exist[i] = a[i] / 10;
            }

            for (int i = 0; i < exist.Length; i++)
            {
                    SortArr(ref b, i, 0, Sizes[exist[i]] - 1, ref colComparBlock, ref colTransBlock);
            }              

            int k = 0;
            for (int i = 0; i < max; i++)
                for (int j = 0; j < Sizes[i]; j++)
                {
                    colTransBlock++;
                    a[k] = b[i, j];
                    k++;
                }
        }

        static void SelectionSort(ref int[] a, ref int colComparSelect, ref int colTransSelect)
        {
            int i, j, min, temp;
            for (i = 0; i < a.Length - 1; i++)
            {
                min = i;
                
                for (j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {                        
                        min = j;
                    }
                    colComparSelect++;
                }
                colTransSelect += 3;
                temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }

        public static void ReadArray(ref int[] array)
        {
            int i = 0;
            bool check = true;
            do
            {
                string[] row = Console.ReadLine().Split(' ');
                check = true;
                if (row.Length != array.Length)
                {
                    Console.WriteLine("Элементов в строке должно быть " + array.Length + ", введено = " + row.Length);
                    check = false;
                }
                else
                {
                    while (check && i < array.Length)
                    {
                        check = int.TryParse(row[i], out array[i]);
                        i++;
                    }
                    if (!check)
                        Console.WriteLine("У элемента с номером " + i + " неверный тип данных");
                }
            } while (!check);
        }

        static void Main(string[] args)
        {
            int origWidth = Console.WindowWidth * 2;
            int origHeight = Console.WindowHeight * 2;
            //Console.BufferWidth += 10;
            Console.SetWindowSize(origWidth, origHeight);
            int n = 0;
            int colComparBlock = 0;
            int colTransBlock = 0;
            int colComparSelect = 0;
            int colTransSelect = 0;

            int[] a = new int[n];

            bool check = false;
            do
            {
                Console.WriteLine("Введите количество элементов");
                check = int.TryParse(Console.ReadLine(), out n);
            } while (!check);

            a = new int[n];
            //ReadArray(ref a);

            int[] a2 = new int[n];
            a = new int[] { 9587, 8818, 1491, 7903, 600, 2062, 2584, 5546, 3946, 2770, 8766, 1265, 9895, 79, 76, 2898, 8653, 1638, 512, 8793, 8315, 9630, 8588, 1310, 7455, 6766, 8766, 558, 5240, 9652, 8498, 4827, 8469, 9989, 2729, 9069, 2050, 5313, 4615, 5996, 8082, 3381, 7260, 7977, 3459, 7336, 874, 2112, 8974, 1386, 905, 7288, 1015, 9492, 8598, 8470, 6258, 7363, 9027, 1498, 7015, 7524, 6324, 5484, 7512, 9053, 4553, 9562, 4365, 9167, 5558, 2447, 2548, 2818, 423, 6007, 153, 1296, 8118, 9126, 2681, 9022, 6414, 3696, 8514, 5011, 2165, 4771, 2374, 1192, 6268, 9389, 8716, 2592, 4872, 6228, 1644, 9424, 5789, 6009 };
            a2 = a;

            BlockSort(ref a, ref colComparBlock, ref colTransBlock);
            SelectionSort(ref a2, ref colComparSelect, ref colTransSelect);

            Console.WriteLine("Количество сравнений блочной сортировки = " + colComparBlock);
            Console.WriteLine("Количество пересылок блочной сортировки = " + colTransBlock);
            Console.WriteLine("Количество сравнений сортировки выбором = " + colComparSelect);
            Console.WriteLine("Количество пересылок  сортировки выбором = " + colTransSelect);

            for (int i = 0; i < a.Length; i++)
            {
                if (i % 10 == 0)
                    Console.WriteLine();
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < a2.Length; i++)
            {
                if (i % 10 == 0)
                    Console.WriteLine();
                Console.Write(a2[i] + " ");
            }
                
        }
    }
}
