using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Animals
{
    /*
     * Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
     * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
     * Kittens and tomcats are cats. All animals are described by age, name and sex.
     * Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
     * Create arrays of different kinds of animals and calculate the average age of each kind
     * of animal using a static method (you may use LINQ).
     * */
    class Program
    {
        static void Main()
        {
            List<Cat> catList = new List<Cat>() { new Cat("Felix", Gender.Male, 10), new Cat("Monika", Gender.Female, 5), new Cat("Johny", Gender.Male, 7) };
            Console.WriteLine("Average cat age: {0}", Cat.AverageAge(catList));

            List<Cat> kittenList = new List<Cat>() { new Cat("Mona Liza", Gender.Male, 10), new Cat("Monika", Gender.Female, 5), new Cat("Kitty", Gender.Male, 7) };
            Console.WriteLine("Average kitten age: {0}", Kitten.AverageAge(kittenList));
            // Or this way
            //Console.WriteLine("Average kitten age: {0}", Cat.AverageAge(KittenList));

            List<Dog> dogList = new List<Dog>() { new Dog("Mona Liza", Gender.Male, 10), new Dog("Monika", Gender.Female, 5), new Dog("Kitty", Gender.Male, 7) };
            Console.WriteLine("Average dog age: {0}", Dog.AverageAge(dogList));
        }
    }
}
