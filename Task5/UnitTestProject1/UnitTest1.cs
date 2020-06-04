using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /*public static void res(double[,] matrix, ref int[,] matrix2)
        {
            for (int t = 0; t < 9; t++)
            {
                for (int f = 0; f < 9; f++)
                {
                    if (matrix[t, f] > matrix[t, t])
                        matrix2[t, f] = 1;
                    else
                        matrix2[t, f] = 0;
                }
            }
        }*/

        [TestMethod]
        public void TestMethod1()
        {
            double[,] matrix = new double[,] { { 1, 2, 3, 4, 5, 6, 7, 8, 9, }, { 9, 8, 7, 6, 5, 4, 3, 2, 1, }, { 1, 1, 1, 1, 1, 1, 1, 1, 1, }, { 9, 9, 9, 9, 9, 9, 9, 9, 9, }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, }, { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5 }, { 100, 100, 100, 101, 101, 101, 101, 100, 100, }, { 3, 2, 1, 1, 2, 3, 3, 2, 1, }, { 0, 9, 9, 0, 0, 9, 9, 0, 9, } };
            int[,] expected = new int[,] { { 0, 1, 1, 1, 1, 1, 1, 1, 1, }, { 1, 0, 0, 0, 0, 0, 0, 0, 0, }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, }, { 0, 0, 0, 0, 0, 0, 1, 1, 1, }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, }, { 1, 0, 0, 0, 0, 1, 1, 0, 0, }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, } };
            int[,] matrix2 = new int[9, 9];

            Program.res(matrix, ref matrix2);

            CollectionAssert.AreEqual(expected, matrix2);
        }
    }
}
