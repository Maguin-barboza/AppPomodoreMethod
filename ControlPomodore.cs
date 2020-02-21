using System.Threading.Tasks;
using System.Threading;
using System;

namespace AppPomodoreMethod
{
    public class ControlPomodore
    {
        private CancellationTokenSource tokenstop;
        private bool IsPaused;
        private string timerInicialMinutos;

        public Pomodore Timer { get; set; } = new Pomodore();
        private int Minutes { get; set; }
        private int Seconds { get; set; }
        
        public ControlPomodore()
        {
            timerInicialMinutos = "25:00";
            string[] timer = timerInicialMinutos.Split(":");

            Minutes = Convert.ToInt32(timer[0]);
            Seconds = Convert.ToInt32(timer[1]);


            Timer.Timer = timerInicialMinutos;
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

            //if(Timer.Timer != )

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
                        Thread.Sleep(500);
                    }
                    Seconds = 59;
                }
            });
        }
    }
}