using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Delegates.Timer;

//Using delegates write a class Timer that has can execute certain method at each t seconds.

class Program
{
    static void Main()
    {
        Console.WriteLine("Shows time info every 3 seconds");
        Timerclass newTimer = new Timerclass(3);
        while (true)
        {
            newTimer.ExecuteMethods();
            Thread.Sleep(1000);
        }
    }
}