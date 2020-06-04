using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    /*public static void P(int n, int m, int[,] a, int x, string st, string sk, bool f)
    {
        int s = 0;
        for (int i = 0; i < m; i++)
            s = s + a[x, i];
        if (s > 1)
        {
            int k = 0;
            if (st != "")
                k = int.Parse(st[st.Length - 1].ToString());
            for (int i = 0; i < m; i++)
            {
                if ((a[x, i] == 1) && (i != k))
                {
                    for (int j = 0; j < n; j++)
                        if (a[j, i] > 0)
                        {
                            sk = j.ToString();
                            if (st.IndexOf(sk) > 0)
                                f = true;
                            else
                                P(n, m, a, j, st + sk, sk, f);
                        }
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int n = 5, m = 6;
        int[,] a = new int[,] { { 0, 0, 1, 1, 0, 1 }, { 0, 0, 0, 1, 0, 0 }, { 1, 0, 0, 0, 1, 1 }, { 1, 1, 0, 0, 0, 0 }, { 0, 1, 1, 0, 1, 0 } };
        bool f = false;
        string sk = "";
        for (int i = 0; i < n; i++)
        {
            P(n, m, a, i, "", sk, f);

        }
        if (f)
            Console.WriteLine("Не дерево");
        else
            Console.WriteLine("Дерево");
    }*/
    class Graph
    {
    }
}
