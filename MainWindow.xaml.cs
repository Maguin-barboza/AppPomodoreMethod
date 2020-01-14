using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppPomodoreMethod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            BtnPlay.IsEnabled = false;
            BtnPause.IsEnabled = true;
            BtnStop.IsEnabled = true;

        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            BtnPause.IsEnabled = false;
            BtnPlay.IsEnabled = true;
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            BtnStop.IsEnabled = false;
            BtnPause.IsEnabled = false;
            BtnPlay.IsEnabled = true;
        }
    }
}
