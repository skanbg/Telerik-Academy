using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class Discipline : CommentIntegration
    {
        public string Name { get; set; }
        public int Lectures { get; set; }
        public int Exercises { get; set; }
        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exercises = exercises;
        }
    }
}
