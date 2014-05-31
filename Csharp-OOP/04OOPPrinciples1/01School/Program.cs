using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    /*
     * We are given a school. In the school there are classes of students.
     * Each class has a set of teachers. Each teacher teaches a set of disciplines.
     * Students have name and unique class number. Classes have unique text identifier.
     * Teachers have name. Disciplines have name, number of lectures and number of exercises.
     * Both teachers and students are people. Students, classes, teachers and disciplines
     * could have optional comments (free text block).
     * 
     * Your task is to identify the classes (in terms of  OOP) and their attributes and operations,
     * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
     */
    class Program
    {
        static void Main()
        {
            //New instances of Student
            Student mariika = new Student("Mariika", 1);
            Student ivancho = new Student("Ivancho", 2);
            Student dragancho = new Student("Dragancho", 3);
            //Adding comment to Dragancho
            dragancho.AddComment("My favorite Student is Dragancho!");
            dragancho.AddComment("Bad Dragancho!");
            //View Draganchos comment
            Console.WriteLine(dragancho.ViewComments());
            //New instances of Teacher
            Teacher Rada = new Teacher("Rada Gospojina");
            Discipline subject = new Discipline("Literature", 2, 5);
            //Using Dictionary for SchoolClass guarantee unique student IDs
            SchoolClass newClass = new SchoolClass("A class", new Dictionary<int, Student> {
                { mariika.StudentID, mariika },
                { ivancho.StudentID, ivancho },
                { dragancho.StudentID, dragancho },
            }, new List<Teacher> { Rada });
            //New instance of School
            School newSchool = new School(new Dictionary<string, SchoolClass> { 
                {newClass.ClassName, newClass}
            });

        }
    }
}
