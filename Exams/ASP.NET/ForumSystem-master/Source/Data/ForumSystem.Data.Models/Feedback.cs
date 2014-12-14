namespace ForumSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Data.Common.Models;

    public class Feedback : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
