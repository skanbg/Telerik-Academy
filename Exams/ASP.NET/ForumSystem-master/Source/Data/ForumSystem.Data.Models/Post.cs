namespace ForumSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ForumSystem.Data.Common.Models;

    public class Post : AuditInfo, IDeletableEntity
    {
        private ICollection<Tag> tags;
        private ICollection<Vote> votes;

        public Post()
        {
            this.tags = new HashSet<Tag>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public ICollection<Tag> Tags
        {
            get { return this.tags; }

            set { this.tags = value; }
        }

        public ICollection<Vote> Votes
        {
            get { return this.votes; }

            set { this.votes = value; }
        }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
