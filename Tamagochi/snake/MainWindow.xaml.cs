using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int FIELD_RANGE = 20;
        double time = 0.8;
        double multiplier = 0.95;
        bool moved = false;
        Side side = Side.Up;
        System.Windows.Threading.DispatcherTimer t =
            new System.Windows.Threading.DispatcherTimer();
        List<Rectangle> list = new List<Rectangle>();
        public LinkedList<SnakeItem> snake = new LinkedList<SnakeItem>();
        int candyX = 5;
        int candyY = 5;
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            t.Interval = TimeSpan.FromSeconds(time);
            t.Tick += Move;
            snake.AddFirst(new SnakeItem(FIELD_RANGE - 3, 0));
            snake.AddLast(new SnakeItem(FIELD_RANGE - 2, 0));
            snake.AddLast(new SnakeItem(FIELD_RANGE - 1,0));


            for (int i = 0; i < FIELD_RANGE * FIELD_RANGE ; i++)
            {
                Rectangle r = new Rectangle();
                r.Height = 500 / FIELD_RANGE ;
                r.Width = 500 / FIELD_RANGE ;
                r.Fill = Brushes.White;
                Field.Children.Add(r);
                list.Add(r);
            }
            list[candyX * FIELD_RANGE + candyY].Fill = Brushes.Red;
            drawSnake();
            t.Start();
        }

        public void drawSnake()
        {
            foreach(SnakeItem s in snake)
            {
                list[s.x * FIELD_RANGE + s.y].Fill = Brushes.Black;
            }
            list[snake.First.Value.x * FIELD_RANGE + snake.First.Value.y].Fill = Brushes.BlueViolet;
        }

        public void Move(object o, EventArgs arg)
        {
            try
            {
                list[snake.Last.Value.x * FIELD_RANGE + snake.Last.Value.y].Fill = Brushes.White;
                if (side == Side.Right)
                {
                    if (candyX == snake.First.Value.x &&
                            candyY == snake.First.Value.y + 1)
                    {
                        snake.AddFirst(new SnakeItem(candyX, candyY));
                        newCandy();
                        time *= multiplier;
                        t.Interval = TimeSpan.FromSeconds(time) ;
                    }
                    else
                    {
                        bool found = true;
                        try
                        {
                            snake.First(
                            e => e.x == snake.First.Value.x &&
                                e.y == snake.First.Value.y + 1 &&
                                e != snake.Last.Value);
                        }
                        catch
                        {
                            found = false;
                        }
                        if (snake.First.Value.y > FIELD_RANGE - 2 || found)
                        {
                            throw new Exception("Wrong move!");
                        }
                        update();
                        snake.First.Value.y++;
                    }
                }

                if (side == Side.Left)
                {
                    if (candyX == snake.First.Value.x &&
                            candyY == snake.First.Value.y - 1)
                    {
                        snake.AddFirst(new SnakeItem(candyX, candyY));
                        newCandy();
                        time *= multiplier;
                        t.Interval = TimeSpan.FromSeconds(time);
                    }
                    else
                    {
                        bool found = true;
                        try
                        {
                            snake.First(
                            e => e.x == snake.First.Value.x &&
                                e.y == snake.First.Value.y - 1 &&
                                e != snake.Last.Value);
                        }
                        catch
                        {
                            found = false;
                        }
                        if (snake.First.Value.y < 1 || found)
                        {
                            throw new Exception("Wrong move!");
                        }
                        update();
                        snake.First.Value.y--;
                    }
                }

                if (side == Side.Down)
                {
                    if (candyX == snake.First.Value.x + 1 &&
                            candyY == snake.First.Value.y)
                    {
                        snake.AddFirst(new SnakeItem(candyX, candyY));
                        newCandy();
                        time *= multiplier;
                        t.Interval = TimeSpan.FromSeconds(time);
                    }
                    else
                    {
                        bool found = true;
                        try
                        {
                            snake.First(
                            e => e.x == snake.First.Value.x + 1 &&
                                e.y == snake.First.Value.y &&
                                e != snake.Last.Value);
                        }
                        catch
                        {
                            found = false;
                        }
                        if (snake.First.Value.x > FIELD_RANGE - 2 || found)
                        {
                            throw new Exception("Wrong move!");
                        }
                        update();
                        snake.First.Value.x++;
                    }
                }

                if (side == Side.Up)
                {
                    if (candyX == snake.First.Value.x - 1 &&
                            candyY == snake.First.Value.y)
                    {
                        snake.AddFirst(new SnakeItem(candyX, candyY));
                        newCandy();
                        time *= multiplier;
                        t.Interval = TimeSpan.FromSeconds(time);
                    }
                    else
                    {
                        bool found = true;
                        try
                        {
                            snake.First(
                           e => e.x == snake.First.Value.x - 1 &&
                               e.y == snake.First.Value.y &&
                               e != snake.Last.Value);
                        }
                        catch
                        {
                            found = false;
                        }
                        if (snake.First.Value.x < 1 || found)
                        {
                            throw new Exception("Wrong move!");
                        }
                        update();
                        snake.First.Value.x--;
                    }
                }
                drawSnake();
                moved = true;
            }
            catch
            {
                //list[snake.Last.Value.x * FIELD_RANGE + snake.Last.Value.y].Fill = Brushes.Black;
                t.Stop();
                //MessageBox.Show("Game over!");
                this.Close();
            }
        }
        public void newCandy()
        {
            do
            {
                candyX = rnd.Next(0, FIELD_RANGE);
                candyY = rnd.Next(0, FIELD_RANGE);
            } while (list[FIELD_RANGE * candyX + candyY].Fill != Brushes.White);
            list[FIELD_RANGE * candyX + candyY].Fill = Brushes.Red;
        }
        public void update()
        {
            LinkedListNode<SnakeItem> x = snake.Last;
            while( x != snake.First)
            {
                x.Value.x = x.Previous.Value.x;
                x.Value.y = x.Previous.Value.y;
                x = x.Previous;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A && side != Side.Right && moved)
            {
                side = Side.Left;
                moved = false;
            }
            if (e.Key == Key.W && side != Side.Down && moved)
            {
                side = Side.Up;
                moved = false;
            }
            if (e.Key == Key.D && side != Side.Left && moved)
            {
                side = Side.Right;
                moved = false;
            }
            if (e.Key == Key.S && side != Side.Up && moved)
            {
                side = Side.Down;
                moved = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            t.Stop();
            MessageBox.Show("Game over! increase of " + snake.Count/1 + " in hunger bar");
        }
    }

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

}
