namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using ForumSystem.Web.ViewModels.Vote;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public IndexBlogPostViewModel()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<PostTagViewModel> Tags { get; set; }

        public VoteViewModel VoteData { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Title, u => u.MapFrom(t => t.Title))
            .ForMember(m => m.Tags, u => u.MapFrom(t => t.Tags))
            .ReverseMap();
        }
    }
}