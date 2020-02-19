using System.ComponentModel;

namespace AppPomodoreMethod
{
    public class Pomodore: INotifyPropertyChanged
    {
        private string _timer;

        public string Timer
        {
            get
            {
                return _timer;
            }
            set
            {
                if(_timer != value)
                {
                    _timer = value;
                    PropertyChangedHandler("Timer");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void PropertyChangedHandler(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
