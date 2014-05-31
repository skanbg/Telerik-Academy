using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CompareHumans
{
    /*
     * Define abstract class Human with first name and last name.
     * Define new class Student which is derived from Human and has new field – grade.
     * Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
     * that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy.
     * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
     * Initialize a list of 10 workers and sort them by money per hour in descending order.
     * Merge the lists and sort them by first name and last name.
     */
    class Program
    {
        static void Main()
        {
            //list of 10 students
            Student student1 = new Student("Ivan", "Petrov", 5.50);
            Student student2 = new Student("Petyr", "Ivanov", 6);
            Student student3 = new Student("Slavi", "Karakashev", 2.50);
            Student student4 = new Student("Karakash", "Slavov", 3.25);
            Student student5 = new Student("Aleksandyr", "Milanov", 4.00);
            Student student6 = new Student("Milan", "Aleksandrov", 2.00);
            Student student7 = new Student("Strahil", "Gergiovski", 3.50);
            Student student8 = new Student("Georgi", "Strahilov", 5.75);
            Student student9 = new Student("Zornitsa", "Iskrova", 2.25);
            Student student10 = new Student("Iskra", "Petrova", 4.50);
            IEnumerable<Student> studentsList = new List<Student>(){
                    student1,student2,student3,student4,student5,student6,student7,student8,student9,student10
                };
            //sort Students by grade in ascending order
            var sortedStudents = from student in studentsList orderby student.Grade ascending select student;
            foreach (var sortedStudent in sortedStudents)
            {
                Console.WriteLine("Hi i am {0} {1}. Grade: {2}", sortedStudent.FirstName, sortedStudent.LastName, sortedStudent.Grade);
            }

            //list of 10 workers
            Worker worker1 = new Worker("Ivan", "Petrov", 700, 10);
            Worker worker2 = new Worker("Petyr", "Ivanov", 4956, 12);
            Worker worker3 = new Worker("Slavi", "Karakashev", 290, 5);
            Worker worker4 = new Worker("Karakash", "Slavov", 140, 2);
            Worker worker5 = new Worker("Aleksandyr", "Milanov", 525, 8);
            Worker worker6 = new Worker("Milan", "Aleksandrov", 1000, 10);
            Worker worker7 = new Worker("Strahil", "Gergiovski", 300, 5);
            Worker worker8 = new Worker("Georgi", "Strahilov", 500, 7);
            Worker worker9 = new Worker("Zornitsa", "Iskrova", 250, 2);
            Worker worker10 = new Worker("Iskra", "Petrova", 4500, 14);
            List<Worker> workersList = new List<Worker>(){
                    worker1,worker2,worker3,worker4,worker5,worker6,worker7,worker8,worker9,worker10
                };
            //Sort workers by money per hour in descending order
            Console.WriteLine(Environment.NewLine + "Workers:");
            IEnumerable<Worker> sortedWorkers = from worker in workersList orderby worker.MoneyPerHour() descending select worker;
            foreach (var sortedWorker in sortedWorkers)
            {
                Console.WriteLine("Worker name: {0} {1}. Money per hour: {2}", sortedWorker.FirstName, sortedWorker.LastName, sortedWorker.MoneyPerHour());
            }

            //Merge the lists and sort them by first name and last name.
            List<Human> merged = new List<Human>();
            merged.AddRange(sortedStudents.ToList());
            merged.AddRange(sortedWorkers.ToList());
            IEnumerable<Human> sortedHumans = from human in merged
                                              orderby human.FirstName, human.LastName
                                              select human;
            Console.WriteLine(Environment.NewLine + "Sorted Humans:");
            foreach (var sortedHuman in sortedHumans)
            {
                Console.WriteLine("Human name: {0} {1}", sortedHuman.FirstName, sortedHuman.LastName);
            }
        }
    }
}
