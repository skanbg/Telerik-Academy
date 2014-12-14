namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure;
    using ForumSystem.Web.InputModels.Feedback;
    using Microsoft.AspNet.Identity;

    public class FeedbackController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedbacks;
        private readonly ISanitizer sanitizer;

        public FeedbackController(IDeletableEntityRepository<Feedback> feedbacks, ISanitizer sanitizer)
        {
            this.feedbacks = feedbacks;
            this.sanitizer = sanitizer;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackInputModel input)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var feedback = new Feedback
                {
                    Title = input.Title,
                    Content = this.sanitizer.Sanitize(input.Content),
                    AuthorId = userId
                };

                this.feedbacks.Add(feedback);
                this.feedbacks.SaveChanges();

                this.TempData["message"] = "Feedback sent!";
                return this.RedirectToAction("Index", "Home", null);
            }

            return this.View(input);
        }
    }
}