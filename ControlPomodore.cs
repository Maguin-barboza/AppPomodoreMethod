using System.Threading.Tasks;
using System.Threading;

namespace AppPomodoreMethod
{
    public class ControlPomodore
    {
        private CancellationTokenSource tokenstop;
        private bool IsPaused;

        public Pomodore Timer { get; set; } = new Pomodore();
        private int Minutes { get; set; }
        private int Seconds { get; set; }
        
        public ControlPomodore()
        {
            Minutes = 25;
            Seconds = 0;
        }

        public void Play()
        {
            ContagemTimer();
        }

        public void Pause()
        {
            tokenstop.Cancel();
            IsPaused = true;
            tokenstop.Dispose();
        }

        public void Stop()
        {
            if (!IsPaused)
                tokenstop.Cancel();
            
            Minutes = 25;
            Seconds = 0;
            
            //Se não destruir o objeto para criá-lo novamente, IsCancellationRequested será sempre true;
            tokenstop.Dispose();
        }

        private async Task ContagemTimer()
        {
            //Reiniciando o TokenStop;
            //Se não destruir o objeto para criá-lo novamente, IsCancellationRequested será sempre true;
            tokenstop = new CancellationTokenSource();
            IsPaused = false;

            await Task.Run(() =>
            {
                for (Minutes = Minutes; Minutes > 0; Minutes--)
                {
                    for (Seconds = Seconds; Seconds >= 0; Seconds--)
                    {
                        //Verificando se foi solicitado o cancelamento;
                        if (tokenstop.IsCancellationRequested)
                            break;

                        Timer.Timer = Minutes.ToString("00") + ":" + Seconds.ToString("00");

                        //ModificandoUI();

                        //Descobrir como eu posso enviar mensagens para a thread principal, atualizando a UI 
                        //conforme o processamento é realizado;
                        //LblTimer.Content = i.ToString("00:00");
                        Thread.Sleep(50);
                    }
                }

                Stop();
            });
        }
    }
}
