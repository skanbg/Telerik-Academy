using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GSMTest
{
    static void Main()
    {
        //Settings to show scrollbar
        Console.BufferHeight = Int16.MaxValue - 1;
        //Creating objects(phones)
        GSM nokiaFlagman = new GSM("Lumia 1020", "Nokia", 1000, "Ivan", new Battery(BatteryType.LiIon, 384, 19), new Display(11, 16777216));
        GSM samsungFlagman = new GSM("Galaxy S5", "Samsung", 1020, "Petyr", new Battery(BatteryType.NiCd, 384, 19));
        GSM htcFlagman = new GSM("HTC One", "HTC", 1010, "Dragan", new Battery(BatteryType.NiCd), new Display(11));
        //Adding objects(phones) to array
        GSM[] flagmans = new GSM[3] { nokiaFlagman, samsungFlagman, htcFlagman };
        //Printing phones information
        foreach (var flagman in flagmans)
        {
            Console.WriteLine(flagman.ToString() + "\n");
        }

        //Printing Iphone4s information
        Console.WriteLine(GSM.Iphone.ToString());

        //Creating new phone
        GSM personalPhone = new GSM("ChinaPhone", "China");
        //Adding call History to the new phone
        personalPhone.AddCall(DateTime.Now.AddDays(-1), "0879564754", 73);
        personalPhone.AddCall(DateTime.Now, "0888952152", 120);
        personalPhone.AddCall(DateTime.Now.AddDays(1), "0879564754", 59);
        personalPhone.AddCall(DateTime.Now.AddDays(2), "0879564754", 10);

        //Displaying the call history
        personalPhone.DisplayCallHistory();
        Console.WriteLine("Phone bill: {0}", personalPhone.TotalCallPrice(0.37m));

        //Removing the longest call and printing history again
        personalPhone.RemoveLongestCall();
        personalPhone.DisplayCallHistory();
        Console.WriteLine("Phone bill: {0}", personalPhone.TotalCallPrice(0.37m));

        //Deleting all calls and printing history
        personalPhone.DeleteAllCalls();
        personalPhone.DisplayCallHistory();
    }
}