namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Vote;
    using Microsoft.AspNet.Identity;

    public class VoteController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public VoteController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        [ChildActionOnly]
        public ActionResult GetVoteBox(int postId, int? votePoints)
        {
            var allVotes = this.posts.All().SelectMany(v => v.Votes).ToList();
            if (votePoints == null)
            {
                var postPoints = this.posts.All().FirstOrDefault(p => p.Id == postId);
                votePoints = postPoints.Votes.Select(v => v.VotePoints).Sum();
            }

            var model = new VoteViewModel() { PostId = postId, PostPoints = votePoints.Value };
            return this.PartialView("_VoteBoxPartial", model);
        }

        [Authorize]
        public ActionResult RegisterVote(int? postId, int? points)
        {
            var post = this.posts.All().FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return this.HttpNotFound("Post not found!");
            }
            else if (points == null || points > 1 || points < -1)
            {
                return this.HttpNotFound("Invalid points!");
            }

            var userId = this.User.Identity.GetUserId();
            var allVotes = this.posts.All().SelectMany(v => v.Votes).FirstOrDefault(v => v.PostId == postId);
            Vote vote = post.Votes.FirstOrDefault(v => v.AuthorId == userId);
            if (vote == null)
            {
                vote = new Vote()
                {
                    AuthorId = userId,
                    VotePoints = points.Value,
                    Post = post
                };
                post.Votes.Add(vote);
                this.posts.Update(post);
            }
            else
            {
                if (points.Value == 0)
                {
                    vote.VotePoints = points.Value;
                }
                else
                {
                    vote.VotePoints = vote.VotePoints + points.Value;
                }
            }

            this.posts.SaveChanges();
            this.posts.Context.Entry(post).Reload();

            var model = Mapper.Map<VoteViewModel>(vote);
            return this.GetVoteBox(model.PostId, null);
        }
    }
}