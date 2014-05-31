using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, Gender sex, int age)
            : base(name, sex, age)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("{0} said: kwak!", this.Name);
        }
    }
}
