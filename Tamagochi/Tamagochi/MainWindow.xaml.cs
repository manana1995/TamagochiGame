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

namespace Tamagochi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int money = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 10)
            {
                this.Visibility = System.Windows.Visibility.Hidden;
                ClickGame.MainWindow m = new ClickGame.MainWindow();
                m.Closed += moodClosed;
                m.Show();
                money -= 10;
                labelMoney.Content = money + "$";
            }
            else MessageBox.Show("Not enough gold! You need 10!");
        }
        private void moodClosed(object sender, EventArgs e)
        {
            MoodBar.progressBar1.Value += ((ClickGame.MainWindow)sender).score;
            this.Visibility = System.Windows.Visibility.Visible;
            changePicture();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            MathGame.MainWindow m = new MathGame.MainWindow();
            m.Closed += moneyClosed;
            m.Show();
        }

        private void moneyClosed(object sender, EventArgs e)
        {
            money += ((MathGame.MainWindow)sender).dollars;
            labelMoney.Content = money + "$";
            this.Visibility = System.Windows.Visibility.Visible;
            changePicture();
        }

        private void changePicture()
        {
            if(HealthBar.progressBar1.Value > 70 && 
                MoodBar.progressBar1.Value > 70 &&
                HungerBar.progressBar1.Value > 70)
            {
                good g = new good();
                grid1.Children.Clear();
                grid1.Children.Add(g);
            }
            else if (HealthBar.progressBar1.Value > 40 &&
                MoodBar.progressBar1.Value > 40 &&
                HungerBar.progressBar1.Value > 40)
            {
                norm g = new norm();
                grid1.Children.Clear();
                grid1.Children.Add(g);
            }
            else
            {
                bad g = new bad();
                grid1.Children.Clear();
                grid1.Children.Add(g);
            }
        }

        private void HealthButton_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 10)
            {
                money -= 10;
                labelMoney.Content = money + "$";
                this.Visibility = System.Windows.Visibility.Hidden;
                Conquest.MainWindow m = new Conquest.MainWindow();
                m.Closed += healthClosed;
                m.Show();
            }
            else MessageBox.Show("Not enough gold! You need 10!");
        }
        private void healthClosed(object sender, EventArgs e)
        {
            HealthBar.progressBar1.Value += ((Conquest.MainWindow)sender).turn;
            this.Visibility = System.Windows.Visibility.Visible;
            changePicture();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 10)
            {
                money -= 10;
                labelMoney.Content = money + "$";
                this.Visibility = System.Windows.Visibility.Hidden;
                Snake.MainWindow m = new Snake.MainWindow();
                m.Closed += meelClosed;
                m.Show();
            }
            else MessageBox.Show("Not enough gold! You need 10!");
        }
        private void meelClosed(object sender,EventArgs e)
        {
            HungerBar.progressBar1.Value += ((Snake.MainWindow)sender).snake.Count/1;
            this.Visibility = System.Windows.Visibility.Visible;
            changePicture();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                string[] text = System.IO.File.ReadAllText("t.txt").Split(' ');
                int health = Convert.ToInt32(text[0]);
                int hunger = Convert.ToInt32(text[1]);
                int mood = Convert.ToInt32(text[2]);
                int moneyX = Convert.ToInt32(text[3]);
                DateTime d = Convert.ToDateTime(text[4]);
                int d1 = Convert.ToInt32(text[5]);
                DateTime h = DateTime.Now;
                int delta = 0;
                if(d.Year == h.Year && d.Month == h.Month)
                {
                    delta += (h.Day - d.Day) * 24;
                    delta += h.Hour - d1;
                }
                delta *= 2;

                HealthBar.progressBar1.Value = health-delta;
                HealthBar.label1.Content = "Health";
                MoodBar.progressBar1.Value = mood - delta;
                MoodBar.label1.Content = "Mood";
                HungerBar.progressBar1.Value = hunger - delta;
                HungerBar.label1.Content = "Hunger";
                money = moneyX;
                labelMoney.Content = moneyX + "$";
                changePicture();
            }
            catch
            {
                HealthBar.progressBar1.Value = 50;
                HealthBar.label1.Content = "Health";
                MoodBar.progressBar1.Value = 50;
                MoodBar.label1.Content = "Mood";
                HungerBar.progressBar1.Value = 50;
                HungerBar.label1.Content = "Hunger";
                money = 30;
                labelMoney.Content = money + "$";
                changePicture();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int health = (int)HealthBar.progressBar1.Value;
            int hunger = (int)HungerBar.progressBar1.Value;
            int mood = (int)MoodBar.progressBar1.Value; 
            int moneyX = money;
            string d = DateTime.Now.ToShortDateString();
            string d1 = DateTime.Now.Hour+"";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("t.txt"))
            {
                file.Write(health + " ");
                file.Write(hunger + " ");
                file.Write(mood + " ");
                file.Write(moneyX + " ");
                file.Write(d+" ");
                file.Write(d1);
            }
        }
    }
}
