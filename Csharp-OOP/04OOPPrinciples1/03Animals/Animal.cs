using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    public class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public Animal(string name, Gender sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }

        public static double AverageAge(IEnumerable<Animal> animalList)
        {
            return animalList.Average(x => x.Age);
        }
    }
}
