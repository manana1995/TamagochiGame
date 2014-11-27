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
        int money = 10;
        public MainWindow()
        {
            InitializeComponent();
            HealthBar.progressBar1.Value = 50;
            HealthBar.label1.Content = "Health";
            MoodBar.progressBar1.Value = 20;
            MoodBar.label1.Content = "Mood";
            HungerBar.progressBar1.Value = 70;
            HungerBar.label1.Content = "Hunger";
            labelMoney.Content = money + "$";
        }
    }
}
