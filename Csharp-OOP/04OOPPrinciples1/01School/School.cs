using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class School
    {
        public Dictionary<string, SchoolClass> ClassList { get; set; }
        public School()
            : this(new Dictionary<string, SchoolClass>())
        {

        }
        public School(Dictionary<string, SchoolClass> students)
        {
            this.ClassList = students;
        }
    }
}
