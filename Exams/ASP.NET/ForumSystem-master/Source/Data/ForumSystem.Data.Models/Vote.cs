namespace ForumSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ForumSystem.Data.Common.Models;

    public class Vote : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int VotePoints { get; set; } // First i implemented it with enum but i think will be faster if the DB makes the calc

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
