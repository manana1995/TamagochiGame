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

namespace ClickGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int increase = 20;
        int counter = 0;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        System.Windows.Threading.DispatcherTimer t = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {          
            InitializeComponent();
            mediaPlayer.Open(new Uri(@"pack://application:,,,/Resources/1.mp3", UriKind.RelativeOrAbsolute));
            //m.Open(new Uri(@"pack://application:,,,/Resources/laughter.mp3", UriKind.RelativeOrAbsolute));
            mediaPlayer.MediaEnded += play;
            t.Tick += update;
            //grid1.Children.Add(mediaPlayer);
            
            t.Interval = TimeSpan.FromMilliseconds(20);
            t.Start();
            progressBar1.Value = 0;
            mediaPlayer.Play();
        }

        private void update(object sender, EventArgs e)
        {
            progressBar1.Value --;
            counter++;
        }

        private void play(object sender, EventArgs e)
        {
            mediaPlayer.Play();
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            progressBar1.Value += 10;
            if (progressBar1.Value == 100)
            {
                t.Stop();
                MessageBox.Show("Hurray! Your Mood increased by " + (int)(increase * ((double)50 / counter)));

            }
            label1.Margin = new Thickness(12, 20, 0, 0);
        }

        private void label1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            label1.Margin = new Thickness(12, 12, 0, 0);
        }

    }
}
