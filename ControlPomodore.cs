using System.Threading;
using System;

namespace AppPomodoreMethod
{
    public class ControlPomodore
    {
        public Pomodore Cronometro { get; set; } = new Pomodore();
        
        private Thread Contagem;
        private TimeSpan Segundos = new TimeSpan();
        private bool IsPaused = false;

        public ControlPomodore()
        {
            Contagem = new Thread(new ThreadStart(IniciarContagem));
            Contagem.IsBackground = true;
            Cronometro.Timer = TimeSpan.FromMinutes(25);
            Segundos = TimeSpan.FromSeconds(1);
        }

        public void Play()
        {
            if (!IsPaused)
            {
                Contagem.Start();
            }
            else
            {
                //Retornar contagem
                //pesquisar sobre semaforos Threads
                IsPaused = false;
            }

        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Stop()
        {
            //pesquisar meios de parar a execução de uma thread.
            //Contagem é reiniciada (retornar para o tempo definido.
            //Contagem.Abort();
        }

        private void IniciarContagem()
        {
            while(Cronometro.Timer != TimeSpan.Zero)
            {
                Cronometro.Timer = Cronometro.Timer.Subtract(Segundos);
                Thread.Sleep(500);
            }
        }
    }
}