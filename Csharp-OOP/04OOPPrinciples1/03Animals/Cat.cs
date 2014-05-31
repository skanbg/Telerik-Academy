using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    public class Cat : Animal, ISound
    {
        public Cat(string name, Gender sex, int age)
            : base(name, sex, age)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("{0} said: Meow!", this.Name);
        }

        //public static double AverageAge(IEnumerable<Cat> catList)
        //{
        //    return catList.Average(x => x.Age);
        //}
    }
}
