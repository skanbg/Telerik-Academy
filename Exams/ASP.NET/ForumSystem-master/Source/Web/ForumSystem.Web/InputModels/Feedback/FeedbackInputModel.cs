namespace ForumSystem.Web.InputModels.Feedback
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class FeedbackInputModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}