using System.Threading;
using System;

namespace AppPomodoreMethod
{
    public class ControlPomodore
    {
        public Pomodore Cronometro { get; set; } = new Pomodore();
        private Thread Contagem;
        private TimeSpan Segundos = new TimeSpan();

        public ControlPomodore()
        {
            Contagem = new Thread(new ThreadStart(IniciarContagem));
            Cronometro.Timer = TimeSpan.FromMinutes(25);
            Segundos = TimeSpan.FromSeconds(1);
        }

        public void Play()
        {
            Contagem.Start();
        }

        public void Pause()
        {

        }

        public void Stop()
        {
            //Contagem.Abort();
        }

        private void IniciarContagem()
        {
            while(Cronometro.Timer.Minutes > 0)
            {
                Cronometro.Timer = Cronometro.Timer.Subtract(Segundos);
                Thread.Sleep(500);
            }
        }
    }
}