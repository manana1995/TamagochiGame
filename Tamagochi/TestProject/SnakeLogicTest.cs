using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    /// <summary>
    /// Summary description for SnakeLogicTest
    /// </summary>
    [TestClass]
    public class SnakeLogicTest
    {
        const int FIELD_RANGE = 20;
        public SnakeLogicTest()
        {
            
        }

        private TestContext testContextInstance;

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

        public LinkedList<SnakeItem> snake;
        Side side = Side.Up;

        enum Side
        {
            Up = 0,
            Right,
            Down,
            Left
        }

        public class SnakeItem
        {
            public int x;
            public int y;
            public SnakeItem(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public void update()
        {
            
            LinkedListNode<SnakeItem> x = snake.Last;
            while (x != snake.First)
            {
                x.Value.x = x.Previous.Value.x;
                x.Value.y = x.Previous.Value.y;
                x = x.Previous;
            }
        }

        public void init()
        {
            snake = new LinkedList<SnakeItem>();
            snake.AddFirst(new SnakeItem(FIELD_RANGE - 3, 0));
            snake.AddLast(new SnakeItem(FIELD_RANGE - 2, 0));
            snake.AddLast(new SnakeItem(FIELD_RANGE - 1, 0));
        }
        public void step()
        {
            if (side == Side.Left)
            {
                update();
                snake.First.Value.y--;
            }
            if (side == Side.Right)
            {
                update();
                snake.First.Value.y++;
            }
            if (side == Side.Down)
            {
                update();
                snake.First.Value.x++;
            }
            if (side == Side.Up)
            {
                update();
                snake.First.Value.x--;
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

        [TestMethod]
        public void snakeGoesUp()
        {
            init();
            int stepCount = 0;
            while (snake.First.Value.x > 0)
            {
                step();
                stepCount++;
            }
            print();
            Assert.AreEqual(stepCount, 17);
        }

        [TestMethod]
        public void snakeGoesUpAndRight()
        {
            init();
            int stepCount = 0;
            while (snake.First.Value.x > 0 && snake.First.Value.y <FIELD_RANGE)
            {
                step();
                if (side == Side.Up) side = Side.Right;
                else side = Side.Up;
                stepCount++;
            }
            print();
            Assert.AreEqual(stepCount, 33);
        }

        [TestMethod]
        public void snakeMakesCircle()
        {
            init();
            int stepCount = 0;
            while (snake.First.Value.x >= 0 && snake.First.Value.x < FIELD_RANGE 
                && snake.First.Value.y < FIELD_RANGE && snake.First.Value.y >= 0 
                && stepCount<1000)
            {
                step();
                if (side == Side.Up) side = Side.Right;
                else if (side == Side.Right) side = Side.Down;
                else if (side == Side.Down) side = Side.Left;
                else if (side == Side.Left) side = Side.Up;
                stepCount++;
            }
            print();
            

            Assert.AreEqual(stepCount, 1000);
        }

        void print()
        {
            for (int i = 0; i < FIELD_RANGE; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < FIELD_RANGE; j++)
                {
                    if (snake.First.Value.x == i && snake.First.Value.y == j) Console.Write("G   ");
                    else
                    try
                    {
                        snake.First(
                        e => e.x == i &&
                            e.y == j);
                        Console.Write("Z   ");
                    }
                    catch
                    {
                        Console.Write("_   ");
                    }
                }
            }
        }
    }
}
