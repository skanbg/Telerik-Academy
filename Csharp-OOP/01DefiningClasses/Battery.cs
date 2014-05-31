using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public enum BatteryType
{
    LiIon, NiMH, NiCd
}

public class Battery
{
    private BatteryType? model = null;
    private int? idleHours = null;
    private int? talkHours = null;
    public Battery()
    {
    }

    public Battery(BatteryType model)
    {
        this.Model = model;
    }

    public Battery(BatteryType model, int idleHours)
        : this(model)
    {
        this.IdleHours = idleHours;
    }

    public Battery(BatteryType model, int idleHours, int talkHours)
        : this(model, idleHours)
    {
        this.TalkHours = talkHours;
    }

    public BatteryType? Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (BatteryType.IsDefined(typeof(BatteryType), value))
            {
                this.model = value;
            }
        }
    }

    public int? IdleHours
    {
        get
        {
            return this.idleHours;
        }
        set
        {
            if (value > 0)
            {
                this.idleHours = value;
            }
        }
    }

    public int? TalkHours
    {
        get
        {
            return this.talkHours;
        }
        set
        {
            if (value > 0)
            {
                this.talkHours = value;
            }
        }
    }
}