using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct | System.AttributeTargets.Interface | System.AttributeTargets.Enum | System.AttributeTargets.Method)]

public class Version : System.Attribute
{
    public double version;
    public Version()
    {
        this.version = 1.0;
    }
}