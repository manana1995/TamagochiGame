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

namespace MathGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        int x, y;
        int spree = 1;
        public int dollars = 0;
        int time = 0;
        System.Windows.Threading.DispatcherTimer t = 
            new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            t.Interval = TimeSpan.FromSeconds(1);
            t.Tick += timeChange;
            generate();
        }
        private void timeChange(object sender,EventArgs e)
        {
            if (time < 10)
            {
                time++;
                timeLabel.Content = "   00 : " + time.ToString("00");
                if (time > 5)
                {
                    timeLabel.Foreground = Brushes.Red;
                }
            }
            else
            {
                timeLabel.Foreground = Brushes.Black;
                timeLabel.Content = "   00 : 10";
                t.Stop();
                MessageBox.Show("Game over!");
                this.Close();
            }
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            click();
        }
        private void generate()
        {
            timeLabel.Foreground = Brushes.Black;
            x = rnd.Next(100, 501);
            y = rnd.Next(100, 501);
            dollarsLabel.Content = dollars + "$";
            problem.Content = x + " + " + y + " = ?";
            t.Stop();
            t.Start();
            AnswerBox.Focus();
            time = 0;
            timeLabel.Content = "   00 : " + time.ToString("00");
        }

        private void AnswerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                click();
        }
        private void click()
        {
            int res = 0;
            int.TryParse(AnswerBox.Text, out res);
            AnswerBox.Text = "";
            if (res == x + y)
            {
                dollars += spree;
                spree++;
                generate();

            }
            else
            {
                t.Stop();
                MessageBox.Show("Game over!");
                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}
