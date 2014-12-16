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
        int increase = 10;
        int counter = 0;
        public int score;
        System.Windows.Threading.DispatcherTimer t = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {          
            InitializeComponent();
            sound.Children.Clear();
            MediaElement media = new MediaElement();
            media.Source = new Uri("1.mp3", UriKind.Relative);
            media.LoadedBehavior = MediaState.Manual;
            sound.Children.Add(media);
            media.Play();
            media.Volume = 0.5;
            media.MediaEnded += play;
            t.Tick += update;
            
            t.Interval = TimeSpan.FromSeconds(0.5);
            t.Start();
            progressBar1.Value = 0;
        }

        private void update(object sender, EventArgs e)
        {
            progressBar1.Value --;
            counter++;
        }

        private void play(object sender, EventArgs e)
        {
            ((MediaElement)(sound.Children[0])).Play();
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value == 100)
            {
                t.Stop();
                ((MediaElement)(sound.Children[0])).Pause();
                score = (int)(increase * ((double)50 / counter));
                MessageBox.Show("Hurray! Your Mood increased by " + score);
                this.Close();
            }
            label1.Margin = new Thickness(12, 20, 0, 0);
        }

        private void label1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            label1.Margin = new Thickness(12, 12, 0, 0);
        }

    }
}
