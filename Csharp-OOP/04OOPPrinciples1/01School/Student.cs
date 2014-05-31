using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class Student : Person
    {
        public int StudentID { get; set; }
        public Student(string name, int id)
            : base(name)
        {
            this.StudentID = id;
        }
    }
}
