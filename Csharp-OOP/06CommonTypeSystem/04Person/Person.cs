using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Person
{
    public class Person
    {
        public int? Age { get; set; }
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return (this.Age != null) ? "My name is " + this.Name + " and i am " + this.Age + " years old." : "My name is " + this.Name + ". Information about age is missing!";
        }
    }
}
