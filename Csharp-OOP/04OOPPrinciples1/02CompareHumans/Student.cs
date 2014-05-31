using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CompareHumans
{
    class Student : Human
    {
        public double Grade { get; set; }
        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        { }
        public Student(string firstName, string lastName, double grade)
            : this(firstName, lastName)
        {
            this.Grade = grade;
        }
    }
}
