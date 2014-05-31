using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Delegates.Timer
{
    public delegate void SecondElapsed(object sender, EventArgs e);
    public class Timerclass
    {
        public event SecondElapsed Elapsed;
        public int SecondsCounter { get; private set; }
        private int SecondsInterval { get; set; }

        public Timerclass(int interval)
        {
            SecondsInterval = interval;
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Elapsed != null)
            {
                Elapsed(this, e);
            }
        }

        public void AddSecond()
        {
            SecondsCounter++;
            if ((SecondsCounter % SecondsInterval) == 0)
            {
                OnChanged(EventArgs.Empty);
            }
        }
    }

    class EventListener
    {
        private Timerclass CurrentTimer;

        public EventListener(Timerclass timer)
        {
            CurrentTimer = timer;
            CurrentTimer.Elapsed += new SecondElapsed(PrintTime);
        }

        // this method will be called when new second is added
        private void PrintTime(object sender, EventArgs e)
        {
            Console.WriteLine("Timer: {0} seconds", CurrentTimer.SecondsCounter);
        }

        public void Detach()
        {
            // Detach the event
            CurrentTimer.Elapsed -= new SecondElapsed(PrintTime);
            CurrentTimer = null;
        }
    }
}
