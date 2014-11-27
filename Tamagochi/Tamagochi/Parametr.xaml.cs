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
    /// Interaction logic for Parametr.xaml
    /// </summary>
    public partial class Parametr : UserControl
    {
        public Parametr()
        {
            InitializeComponent();
        }

        private void progressBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelPercent.Content = progressBar1.Value + "%";
            if (progressBar1.Value < 35)
                progressBar1.Foreground = Brushes.DarkRed;
            else
                progressBar1.Foreground = Brushes.Green;
        }
    }
}
