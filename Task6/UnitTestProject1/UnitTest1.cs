using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var arr = new double[] { 1, 2, 3 };
            var last = 3;
            var N = 4;

            var expected = new double[] { 1, 2, 3, 20 };
            Array.Resize(ref arr, N);
            Program.Sequence(ref arr, N, last);

            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
