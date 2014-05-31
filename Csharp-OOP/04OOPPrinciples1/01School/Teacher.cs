using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class Teacher : Person
    {
        public List<Discipline> TeachingDisciplines { get; set; }
        public Teacher(string name)
            : this(name, new List<Discipline>())
        {

        }
        public Teacher(string name, List<Discipline> disciplines)
            : base(name)
        {
            TeachingDisciplines = disciplines;
        }
    }
}
