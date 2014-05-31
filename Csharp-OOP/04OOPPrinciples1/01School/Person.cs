using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public abstract class Person : CommentIntegration
    {
        public string Name { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }
    }
}
