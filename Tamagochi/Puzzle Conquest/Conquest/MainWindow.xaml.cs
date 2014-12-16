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
using System.Collections;

namespace Conquest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rectangle> buttons = new List<Rectangle>();
        public int turn;
        Random rnd = new Random();
        const int n = 20;
        int[,] a = new int[n,n];
        public MainWindow()
        {
            InitializeComponent();
            this.Background = Brushes.Indigo;
            for(int i = 0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = rnd.Next(1,6);
                    Rectangle b = new Rectangle();
                    b.Width = wrapPanel1.Width/n;
                    b.Height = (wrapPanel1.Height-49) / n;
                    //b.Content = a[i, j];
                    wrapPanel1.Children.Add(b);
                    b.Tag = 1000 * i + j;
                    buttons.Add(b);
                    if (a[i,j]==1)
                        b.Fill = new SolidColorBrush(Colors.BlueViolet);
                    if (a[i, j] == 2)
                        b.Fill = new SolidColorBrush(Colors.SkyBlue);
                    if (a[i, j] == 3)
                        b.Fill = new SolidColorBrush(Colors.Orchid);
                    if (a[i, j] == 4)
                        b.Fill = new SolidColorBrush(Colors.PaleGreen);
                    if (a[i, j] == 5)
                        b.Fill = new SolidColorBrush(Colors.Bisque);

                }
            button1.Background = new SolidColorBrush(Colors.BlueViolet);
            button2.Background = new SolidColorBrush(Colors.SkyBlue);
            button3.Background = new SolidColorBrush(Colors.Orchid);
            button4.Background = new SolidColorBrush(Colors.PaleGreen);
            button5.Background = new SolidColorBrush(Colors.Bisque);
            a[0, 0] = 0;
            //buttons[0].Content = 0;
            buttons[0].Fill = new SolidColorBrush(Colors.Black);

        }
        public void check(int[,] a,int c)
        {
            turn++;
            for(int i = 0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 0)
                    {
                        if ((j < n-1) && (a[i, j + 1] == c))
                            a[i, j + 1] = 0;
                        if ((i < n-1) && (a[i + 1, j] == c))
                            a[i + 1, j] = 0;
                        if ((j > 0) && (a[i, j - 1] == c))
                            a[i, j - 1] = 0;
                        if ((i > 0 ) && (a[i - 1, j] == c))
                            a[i - 1, j] = 0;
                    }
                }
            Color paint = Colors.Black;
            if (c == 1)
            paint = Colors.BlueViolet;
            if (c == 2)
                paint = Colors.SkyBlue;
            if (c == 3)
                paint = Colors.Orchid;
            if (c == 4)
                paint = Colors.PaleGreen;
            if (c == 5)
                paint = Colors.Bisque;
            foreach (Rectangle b in buttons)
                if (a[(int)b.Tag / 1000, (int)b.Tag % 1000] == 0)
                    b.Fill = new SolidColorBrush(paint);
            bool flag = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] != 0)
                        flag = false;
            if (flag)
            {
                int increase = turn < 50 ?(50 - turn): 0;
                MessageBox.Show("Игра окончена!" + " получено здоровья:" + increase);
                turn = increase;
                this.Close();
                //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                //Application.Current.Shutdown();
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            check(a,1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            check(a, 2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            check(a, 3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            check(a, 4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            check(a, 5);
        }

        private void window1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Escape)
            {
                MessageBoxResult  res;
                res = MessageBox.Show("Выйти?", "", MessageBoxButton.OKCancel);
                if(res == MessageBoxResult.OK)
                this.Close();
            }
            
        }

    }
}
