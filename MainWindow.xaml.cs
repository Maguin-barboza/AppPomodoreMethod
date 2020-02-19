using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace AppPomodoreMethod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public Pomodore Pomo { get; set; } = new Pomodore();
        public ControlPomodore Control { get; set; } = new ControlPomodore();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            BtnPlay.IsEnabled = false;
            BtnPause.IsEnabled = true;
            BtnStop.IsEnabled = true;
            Control.Play();
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            BtnPause.IsEnabled = false;
            BtnPlay.IsEnabled = true;
            Control.Pause();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            BtnStop.IsEnabled = false;
            BtnPause.IsEnabled = false;
            BtnPlay.IsEnabled = true;
            Control.Stop();
        }
    }
}
