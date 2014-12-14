namespace ForumSystem.Web.ViewModels.Vote
{
    using System.Linq;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class VoteViewModel : IMapFrom<Vote>, IHaveCustomMappings
    {
        public int PostId { get; set; }

        public int PostPoints { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Vote, VoteViewModel>()
            .ForMember(m => m.PostId, u => u.MapFrom(t => t.PostId))
            .ForMember(m => m.PostPoints, u => u.MapFrom(t => t.Post.Votes.Select(v => v.VotePoints).Sum()))
            .ReverseMap();

            configuration.CreateMap<Post, VoteViewModel>()
            .ForMember(m => m.PostId, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.PostPoints, u => u.MapFrom(t => t.Votes.Select(v => v.VotePoints).Sum()))
            .ReverseMap();
        }
    }
}