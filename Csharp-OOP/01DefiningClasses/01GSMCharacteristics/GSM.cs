using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class GSM
{
    private string model;
    private string manufacturer;
    private decimal? price = null;
    private string owner = null;
    private Battery battery = new Battery();
    private Display display = new Display();
    private List<Call> callHistory = new List<Call>();
    private static GSM Iphone4S = new GSM("Iphone4s", "Apple", 700, "Someone", new Battery(BatteryType.LiIon, 200, 14), new Display(9, 16777216));

    public GSM(string model, string manufacturer)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
    }

    public GSM(string model, string manufacturer, decimal price)
        : this(model, manufacturer)
    {
        this.Price = price;
    }

    public GSM(string model, string manufacturer, decimal price, string owner)
        : this(model, manufacturer, price)
    {
        this.Owner = owner;
    }

    public GSM(string model, string manufacturer, decimal price, string owner, Battery battery)
        : this(model, manufacturer, price, owner)
    {
        this.battery = battery;
    }

    public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        : this(model, manufacturer, price, owner, battery)
    {
        this.display = display;
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            ValidateData(value, "GSM model", 3, 30, @"^[a-zA-Z0-9 ]+$");
            this.model = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            ValidateData(value, "Manufacturer", 3, 30, @"^[a-zA-Z0-9 ]+$");
            this.manufacturer = value.Trim();
        }
    }

    public decimal? Price
    {
        get
        {
            return this.price;
        }
        set
        {
            decimal parsedPrice = 0;
            if (!decimal.TryParse(value.ToString(), out parsedPrice))
            {
                throw new FormatException("Invalid price format!");
            }
            if (parsedPrice < 0)
            {
                throw new ArgumentException("Price cant be negative!");
            }
            this.price = parsedPrice;
        }
    }

    public string Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            ValidateData(value, "Owner's name", 3, 40, @"^[a-zA-Z -]+$");
            this.owner = value.Trim();
        }
    }

    public List<Call> CallHistory
    {
        get
        {
            return this.callHistory;
        }
    }

    public static GSM Iphone
    {
        get
        {
            return Iphone4S;
        }
    }

    private void ValidateData(string value, string subject, int minLength, int maxLength, string regex = null)
    {
        value = value.Trim();
        if (regex != null && !Regex.IsMatch(value, regex))
        {
            throw new ArgumentException(subject + " contains invalid symbols!");
        }
        if (value.Length < minLength || value.Length > maxLength)
        {
            throw new ArgumentException("Maximal \"" + subject + "\" length is " + maxLength + " symbols and minimum " + minLength + " symbols!");
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        int dot = 0;
        output.AppendFormat("{0} is produced by {1}. ", this.Model, this.Manufacturer);
        if (this.Price != null)
        {
            output.AppendFormat("{0} costs {1}$. ", this.Model, this.Price);
        }
        if (this.battery.IdleHours != null)
        {
            output.AppendFormat("This mobile phone battery can last up to {0} hours idle", this.battery.IdleHours);
            dot++;
        }
        if (this.battery.TalkHours != null)
        {
            if (dot > 0)
            {
                output.AppendFormat(" and up to {0} hours talking", this.battery.TalkHours);
            }
            else
            {
                output.AppendFormat("This mobile phone battery can last up to {0} hours talking", this.battery.TalkHours);
                dot++;
            }
        }
        if (this.battery.Model != null)
        {
            if (dot > 0)
            {
                output.AppendFormat(" with its {0} battery. ", this.battery.Model);
                dot = 0;
            }
            else
            {
                output.AppendFormat("This mobile phone has {0} battery. ", this.battery.Model);
                dot = 0;
            }
        }
        if (dot > 0)
        {
            output.Append(". ");
            dot = 0;
        }
        if (this.display.Size != null)
        {
            output.AppendFormat("{0} has {1}cm display", this.Model, this.display.Size);
            dot++;
        }
        if (this.display.NumberOfColors != null)
        {
            if (dot > 0)
            {
                output.AppendFormat(" with {0} colors. ", this.display.NumberOfColors);
                dot = 0;
            }
            else
            {
                output.AppendFormat("{0} has {1} colors. ", this.Model, this.display.NumberOfColors);
                dot = 0;
            }
        }
        if (dot > 0)
        {
            output.Append(". ");
            dot = 0;
        }
        if (this.Owner != null)
        {
            output.AppendFormat("{0} bought this phone.", this.Owner);
        }
        return output.ToString();
    }

    public void AddCall(DateTime date, string phoneNumber, int duration)
    {
        Call newCall = new Call(date, phoneNumber, duration);
        this.callHistory.Add(newCall);
    }

    public void RemoveCall(string phoneNumber)
    {
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i].PhoneNumber == phoneNumber)
            {
                callHistory.RemoveAt(i);
            }
        }
    }

    public void DeleteAllCalls()
    {
        callHistory.Clear();
    }

    public decimal TotalCallPrice(decimal callPrice)
    {
        decimal totalPrice = 0;
        foreach (var call in callHistory)
        {

            totalPrice += (call.Duration / 60) * callPrice;
        }
        return Math.Round(totalPrice, 2);
    }

    public void DisplayCallHistory()
    {
        Console.WriteLine(new string('=', Console.WindowWidth - 1));
        int callsCount = callHistory.Count;
        Console.WriteLine("Number of calls: {0}", callsCount);
        for (int i = 0; i < callsCount; i++)
        {
            Console.WriteLine("Date: {0}, Number: {1}, Duration: {2}", CallHistory[i].DateAndTime, CallHistory[i].PhoneNumber, CallHistory[i].Duration);
        }
        Console.WriteLine(new string('=', Console.WindowWidth - 1));
    }

    public void RemoveLongestCall()
    {
        int longestCall = -1;
        int index = -1;
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i].Duration > longestCall)
            {
                longestCall = callHistory[i].Duration;
                index = i;
            }
        }
        callHistory.RemoveAt(index);
    }
}