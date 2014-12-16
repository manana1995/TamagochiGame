using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conquest;


namespace TestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestConquestLogic
    {
        public TestConquestLogic()
        {
        }

        private TestContext testContextInstance;

        bool check(int[,] a, int c)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 0)
                    {
                        if ((j < n - 1) && (a[i, j + 1] == c))
                            a[i, j + 1] = 0;
                        if ((i < n - 1) && (a[i + 1, j] == c))
                            a[i + 1, j] = 0;
                        if ((j > 0) && (a[i, j - 1] == c))
                            a[i, j - 1] = 0;
                        if ((i > 0) && (a[i - 1, j] == c))
                            a[i - 1, j] = 0;
                    }
                }
            bool flag = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] != 0)
                        flag = false;
            return flag;
        }

        int[,] generate(int lenght)
        {
            Random rnd = new Random();
            int n = lenght;
            int[,] a = new int[n,n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = rnd.Next(1, 6);
                }
            a[0, 0] = 0;
            return a;
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod, Timeout(1)]
        public void testPlay20()
        {
            
            Random rnd = new Random();
            int[,] a = generate(20);
            print(a);
            Console.WriteLine();
            int i = 0;
            while (!check(a, rnd.Next(1, 6))) { ++i; }
            Console.WriteLine(i);
            print(a);
        }

        [TestMethod, Timeout(100)]
        public void testPlay100()
        {
            Random rnd = new Random();
            int[,] a = generate(100);
            int i = 0;
            while (!check(a, rnd.Next(1, 6))) { ++i; }
            Console.WriteLine(i);

        }

        [TestMethod, Timeout(10000)]
        public void testPlay500()
        {
            Random rnd = new Random();
            int[,] a = generate(500);
            int i = 0;
            while (!check(a, rnd.Next(1, 6))) { ++i; }
            Console.WriteLine(i);
        }

        [TestMethod, Timeout(1000)]
        public void testBestOf100()
        {
            Random rnd = new Random();
            int[,] a = generate(20);
            int i = 0;
            int max = int.MaxValue;
            for (int j = 0; j < 100; j++)
            {
                while (!check(a, rnd.Next(1, 6))) { ++i; }
                a = generate(20);
                if (max > i) max = i;
                i = 0;
            }
            
            Console.WriteLine(max);

        }

        [TestMethod, Timeout(1)]
        public void testBeginFromRandomPlace()
        {
            Random rnd = new Random();
            int[,] a = generate(20);
            a[0, 0] = 3;
            a[rnd.Next(20), rnd.Next(20)] = 0;

            print(a);
            Console.WriteLine();

            
            int i = 0;
            while (!check(a, rnd.Next(1, 6))) { ++i; }
 
            Console.WriteLine(i);
            print(a);
        }

        [TestMethod]
        public void checkFill()
        {
            int[,] a = generate(20);
            a[0, 1] = 1;
            a[1, 0] = 2;
            Assert.AreEqual(a[0, 0], 0);
            check(a, 1);
            Assert.AreEqual(a[0, 1], 0);
            check(a, 2);
            Assert.AreEqual(a[1, 0], 0);
            print(a);
        }

        void print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i,j] + "   ");
                }
            }
        }
    }
}
