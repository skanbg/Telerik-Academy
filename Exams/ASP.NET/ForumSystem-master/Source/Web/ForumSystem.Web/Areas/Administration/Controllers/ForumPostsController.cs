namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Areas.Administration.ViewModels.ForumPosts;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class ForumPostsController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public ForumPostsController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        // GET: Administration/ForumPosts
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReadPosts([DataSourceRequest]DataSourceRequest request)
        {
            var postsDataSource = this.posts.All().Where(p => !p.IsDeleted)
                .ToDataSourceResult(request, post => Mapper.Map<ForumPostViewModel>(post));

            return this.Json(postsDataSource);
        }

        [HttpPost]
        public ActionResult DestroyPost([DataSourceRequest]DataSourceRequest request, ForumPostViewModel model)
        {
            ModelState["ModifiedOn"].Errors.Clear();
            ModelState["CreatedOn"].Errors.Clear();
            if (model != null && this.ModelState.IsValid)
            {
                var post = this.posts.All().FirstOrDefault(p => p.Id == model.Id);
                if (post != null)
                {
                    this.posts.Delete(post);
                    this.posts.SaveChanges();
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult UpdatePost([DataSourceRequest]DataSourceRequest request, ForumPostViewModel model)
        {
            ModelState["ModifiedOn"].Errors.Clear();
            ModelState["CreatedOn"].Errors.Clear();
            if (model != null && this.ModelState.IsValid)
            {
                var post = this.posts.All().FirstOrDefault(p => p.Id == model.Id);
                if (post != null)
                {
                    post.Title = model.Title;
                    post.Content = model.Content;
                    this.posts.Update(post);
                    this.posts.SaveChanges();
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}