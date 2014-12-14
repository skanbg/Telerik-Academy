namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.PageableFeedbackList;

    [Authorize]
    public class PageableFeedbackListController : Controller
    {
        private const int FeedbacksOnPage = 4;
        private const int FeedbackCacheInterval = 30; // in seconds
        private readonly IDeletableEntityRepository<Feedback> feedbacksData;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacksData)
        {
            this.feedbacksData = feedbacksData;
        }

        // GET: PageableFeedbackList
        public ActionResult Index(int? page = 0)
        {
            // this.Cache.Remove("time");
            if (this.HttpContext.Cache[page.ToString()] == null)
            {
                var feedbacks = this.feedbacksData.All();
                var selectedFeedbacksQuery = feedbacks
                    .OrderBy(f => f.Id).AsQueryable();
                if (page != null && page > 0)
                {
                    selectedFeedbacksQuery = selectedFeedbacksQuery.Skip((page.GetValueOrDefault(0) - 1) * FeedbacksOnPage).AsQueryable();
                }

                selectedFeedbacksQuery = selectedFeedbacksQuery
                    .Take(FeedbacksOnPage);

                var selectedFeedbacks = selectedFeedbacksQuery
                    .Project().To<FeedbackViewModel>().ToList();
                var model = new IndexViewModel()
                {
                    CurrentPage = page ?? 1,
                    Feedbacks = selectedFeedbacks,
                    FeedbacksCount = feedbacks.Count(),
                    FeedbacksOnPage = FeedbacksOnPage
                };

                this.HttpContext.Cache.Insert(
                page.ToString(), // key
                model, // value
                null, // dependencies
                DateTime.Now.AddSeconds(FeedbackCacheInterval), // absolute exp.
                TimeSpan.Zero, // sliding exp.
                CacheItemPriority.Default, // priority
                this.OnCacheItemRemovedCallback); // callback delegate
            }

            var cachedModel = this.HttpContext.Cache[page.ToString()] as IndexViewModel;
            return this.View(cachedModel);
        }

        private void OnCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
        }
    }
}