namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ForumSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private UserManager<ApplicationUser> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            this.SeedUsers(context, 30);
            this.SeedPosts(context, 30);
            this.SeedTagsToPosts(context, 3);
        }

        private void SeedTagsToPosts(ApplicationDbContext context, int tagsCountPerEachPost)
        {
            if (context.Tags.Any())
            {
                return;
            }

            var posts = context.Posts.OrderBy(x => Guid.NewGuid()).ToList();
            foreach (Post post in posts)
            {
                for (int i = 0; i < tagsCountPerEachPost; i++)
                {
                    var tag = new Tag()
                    {
                        Name = "Tag" + post.Id + " - " + i
                    };
                    post.Tags.Add(tag);
                }
            }

            context.SaveChanges();
        }

        private void SeedPosts(ApplicationDbContext context, int postsCount)
        {
            if (context.Posts.Any())
            {
                return;
            }

            var users = context.Users.Select(u => u.Id).OrderBy(x => Guid.NewGuid()).Take(postsCount).ToList();
            for (int i = 0; i < postsCount; i++)
            {
                var post = new Post
                {
                    AuthorId = users[i % users.Count],
                    Content = "Content " + i,
                    Title = "Post" + i
                };

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context, int usersCount)
        {
            if (context.Users.Any())
            {
                return;
            }

            for (int i = 0; i < usersCount; i++)
            {
                var user = new ApplicationUser
                {
                    Email = string.Format("{0}@{1}.com", "user" + i, "domain"),
                    UserName = string.Format("{0}@{1}.com", "user" + i, "domain")
                };
                this.userManager.Create(user, "123456");
            }
        }
    }
}
