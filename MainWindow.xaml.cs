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
using System.Threading;
using System.ComponentModel;

namespace AppPomodoreMethod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int Timer;
        private CancellationTokenSource tokenstop;
        private bool IsPaused;

        public MainWindow()
        {
            Timer = 25;
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            BtnPlay.IsEnabled = false;
            BtnPause.IsEnabled = true;
            BtnStop.IsEnabled = true;

            ContagemTimer();
            LblTimer.Content = Timer.ToString("00:00");
        }


        private async Task ContagemTimer()
        {
            //Reiniciando o TokenStop;
            //Se não destruir o objeto para criá-lo novamente, IsCancellationRequested será sempre true;
            tokenstop = new CancellationTokenSource();
            
            IsPaused = false;

            await Task.Run(() =>
            {
                for (int i = Timer; i > 0; i--)
                {
                    //Verificando se foi solicitado o cancelamento;
                    if (tokenstop.IsCancellationRequested)
                        break;

                    Timer = i;



                    //Descobrir como eu posso enviar mensagens para a thread principal, atualizando a UI 
                    //conforme o processamento é realizado;
                    //LblTimer.Content = i.ToString("00:00");
                    Thread.Sleep(1000);
                }
            });
        }


        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            BtnPause.IsEnabled = false;
            BtnPlay.IsEnabled = true;

            tokenstop.Cancel();
            IsPaused = true;
            LblTimer.Content = Timer.ToString("00:00");

            tokenstop.Dispose();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            BtnStop.IsEnabled = false;
            BtnPause.IsEnabled = false;
            BtnPlay.IsEnabled = true;

            //Enviando solicitação de cancelamento para tarefa;
            if(!IsPaused)
                tokenstop.Cancel();

            LblTimer.Content = Timer.ToString("00:00");
            Timer = 25;

            //Se não destruir o objeto para criá-lo novamente, IsCancellationRequested será sempre true;
            tokenstop.Dispose();
        }
    }
}
