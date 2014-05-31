using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class SchoolClass : CommentIntegration
    {
        public Dictionary<int, Student> StudentsList { get; set; }
        public List<Teacher> TeachersList { get; set; }
        public string ClassName { get; set; }
        public SchoolClass(string className)
            : this("", new Dictionary<int, Student>(), new List<Teacher>())
        {
            this.ClassName = className;
        }

        public SchoolClass(string className, Dictionary<int, Student> students, List<Teacher> teachers)
        {
            this.ClassName = className;
            this.StudentsList = students;
            this.TeachersList = teachers;
        }
    }
}
