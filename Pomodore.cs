using System;
using System.ComponentModel;

namespace AppPomodoreMethod
{
    public class Pomodore: INotifyPropertyChanged
    {
        private TimeSpan _Timer;

        public TimeSpan Timer
        {
            get { return _Timer; }
            set 
            { 
                if(_Timer != value)
                {
                    _Timer = value;
                    RaisePropertyChangedHandler("Timer");
                }
            }
        }

        public Pomodore()
        {
            _Timer = new TimeSpan();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedHandler(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
