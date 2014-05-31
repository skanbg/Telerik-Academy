using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionIEnumerable
{
    public static class ExtensionIEnumerable
    {
        public static T Sum<T>(this IEnumerable inter)
        {
            //T buffer = default(T);
            dynamic buffer = 0;
            foreach (var number in inter)
            {
                buffer += number;
            }
            return buffer;
        }

        public static T Product<T>(this IEnumerable inter)
        {
            dynamic buffer = 1;
            foreach (var number in inter)
            {
                buffer *= number;
            }
            return buffer;
        }

        public static T Min<T>(this IEnumerable inter)
        {
            //IEnumerator<T> iter = inter.GetEnumerator();
            dynamic output = inter.GetEnumerator().Current;
            foreach (var number in inter)
            {
                if (output < number)
                {
                    output = number;
                }
            }
            return output;
        }

        public static T Max<T>(this IEnumerable inter)
        {
            //IEnumerator<T> iter = inter.GetEnumerator();
            dynamic output = inter.GetEnumerator().Current;
            foreach (var number in inter)
            {
                if (output > number)
                {
                    output = number;
                }
            }
            return output;
        }

        public static T Average<T>(this IEnumerable inter)
        {
            dynamic elementsCount = 0;
            while (inter.GetEnumerator().MoveNext())
            {
                elementsCount++;
            }
            T sum = inter.Sum<T>();
            return sum/elementsCount;
        }
    }
}
