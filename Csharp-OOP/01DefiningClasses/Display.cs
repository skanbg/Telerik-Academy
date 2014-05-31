using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Display
{
    private int? size = null;
    private int? numberOfColors = null;

    public Display()
    {
    }

    public Display(int size)
    {
        this.Size = size;
    }

    public Display(int size, int numberOfColors)
        : this(size)
    {
        this.NumberOfColors = numberOfColors;
    }

    public int? Size
    {
        get
        {
            return this.size;
        }
        set
        {
            if (value > 0)
            {
                this.size = value;
            }
        }
    }

    public int? NumberOfColors
    {
        get
        {
            return this.numberOfColors;
        }
        set
        {
            if (value > 0)
            {
                this.numberOfColors = value;
            }
        }
    }
}