using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public abstract class CommentIntegration
    {
        private List<string> Comments;
        public CommentIntegration()
        {
            Comments = new List<string>();
        }
        public virtual void AddComment(string comment)
        {
            Comments.Add(comment);
        }
        public virtual string ViewComments()
        {
            return string.Join(Environment.NewLine, Comments);
        }
    }
}
