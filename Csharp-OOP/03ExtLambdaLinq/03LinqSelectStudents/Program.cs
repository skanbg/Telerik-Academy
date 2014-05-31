using System;
using System.Collections.Generic;
using System.Linq;

//Problem 03
//Write a method that from a given array of students finds all students
//whose first name is before its last name alphabetically. Use LINQ query operators.

//Problem 04
//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

class Program
{
    static void Main()
    {
        Student student1 = new Student("Georgi", "Petrov", 20);
        Student student2 = new Student("Georgi", "Zografski", 30);
        Student student3 = new Student("Georgi", "Ivanov", 25);
        Student student4 = new Student("Georgi", "Alexandrov", 19);
        Student student5 = new Student("Georgi", "Dimitrov", 50);
        List<Student> listStudents = new List<Student>() { student1, student2, student3, student4, student5 };
        Console.WriteLine("List of Students whose first name is before its last name alphabetically:");
        //Linq task 03
        //var newStudentsList = listStudents.Where(x => string.Compare(x.FirstName, x.LastName) == -1);
        var newStudentsList = from student in listStudents where string.Compare(student.FirstName, student.LastName) == -1 select student;
        //Printing the result
        foreach (var st in newStudentsList)
        {
            Console.WriteLine("First name: {0}, Last name: {1}", st.FirstName, st.LastName);
        }

        Console.WriteLine(Environment.NewLine + "List of Students between 18 and 24(including):");
        //Linq for task 04
        //var studentsListAge = listStudents.Where(x => x.Age >= 18 && x.Age <= 24);
        var studentsListAge = from student in listStudents where student.Age >= 18 && student.Age <= 24 select student;
        //Printing the result
        foreach (var st in studentsListAge)
        {
            Console.WriteLine("Age: {0}, First name: {1}, Last name: {2}", st.Age, st.FirstName, st.LastName);
        }

        //Lambda for task 05
        var descSortedStudents = listStudents.OrderByDescending(x => x.FirstName).ThenByDescending(y => y.LastName);
        //Printing the result
        Console.WriteLine(Environment.NewLine + "Sorted descending students(by name)");
        foreach (var st in descSortedStudents)
        {
            Console.WriteLine("Age: {0}, First name: {1}, Last name: {2}", st.Age, st.FirstName, st.LastName);
        }

        //Linq for task 05
        var linqDescSortedStudents = from student in listStudents orderby student.FirstName descending orderby student.LastName descending select student;
        //Printing the result
        Console.WriteLine(Environment.NewLine + "Sorted descending students(by name)");
        foreach (var st in descSortedStudents)
        {
            Console.WriteLine("Age: {0}, First name: {1}, Last name: {2}", st.Age, st.FirstName, st.LastName);
        }
    }
}