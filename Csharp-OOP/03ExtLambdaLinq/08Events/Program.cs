using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Delegates.Timer;
using System.Globalization;

//Using delegates write a class Timer that has can execute certain method at each t seconds.

class Program
{
    static void Main()
    {
        Console.WriteLine(double.Parse("3,5", CultureInfo.InvariantCulture));
        Console.WriteLine("Shows time info every second 3 seconds!");
        //Change the default parameter in Timerclass to shorten or extend interval
        Timerclass newTimer = new Timerclass(3);
        EventListener listener = new EventListener(newTimer);
        while (true)
        {
            newTimer.AddSecond();
            Thread.Sleep(1000);
        }
    }
}