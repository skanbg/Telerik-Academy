using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Exceptions
{
    class InvalidRangeException<T> : ApplicationException
    {
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
        public InvalidRangeException(string msg, T minValue, T maxValue)
            : base(msg)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
    }
}
