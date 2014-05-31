using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class Call
{
    private DateTime date;
    private string phoneNumber;
    private int duration;

    public Call(DateTime date, string phoneNumber, int duration)
    {
        this.DateAndTime = date;
        this.PhoneNumber = phoneNumber;
        this.Duration = duration;
    }

    public DateTime DateAndTime
    {
        get
        {
            return this.date;
        }
        set
        {
            this.date = value;
        }
    }

    public string PhoneNumber
    {
        get
        {
            return this.phoneNumber;
        }
        set
        {
            if (!Regex.IsMatch(value, @"^[0-9]+$"))
            {
                throw new ArgumentException("Invalid phone number!");
            }
            this.phoneNumber = value;
        }
    }

    public int Duration
    {
        get
        {
            return this.duration;
        }
        set
        {
            this.duration = value;
        }
    }
}