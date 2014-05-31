using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Delegates.Timer
{
    public class Timerclass
    {
        public int SecondsCounter { get; private set; }
        private int SecondsInterval { get; set; }
        private delegate void newDelegate(int seconds);
        private newDelegate currentDel;
        public Timerclass(int interval)
        {
            //Attaching methods when new instance of the class is created
            currentDel = new newDelegate(CheckForOverflow);
            currentDel += WriteOnConsole;
            SecondsInterval = interval;
        }

        private void CheckForOverflow(int seconds)
        {
            //Overflow check
            if (seconds > int.MaxValue)
            {
                this.SecondsCounter = 0;
            }
        }

        private void WriteOnConsole(int seconds)
        {
            //Printing the timer
            Console.WriteLine("Timer: {0} seconds", seconds);
        }

        public void ExecuteMethods()
        {
            SecondsCounter++;
            if (SecondsCounter % SecondsInterval == 0)
            {
                currentDel(SecondsCounter);
            }
        }
    }
}
