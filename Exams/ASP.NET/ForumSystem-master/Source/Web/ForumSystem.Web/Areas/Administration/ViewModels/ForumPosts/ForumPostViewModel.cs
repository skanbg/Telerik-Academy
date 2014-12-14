namespace ForumSystem.Web.Areas.Administration.ViewModels.ForumPosts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class ForumPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedOn { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, ForumPostViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Title, u => u.MapFrom(t => t.Title))
            .ForMember(m => m.AuthorName, u => u.MapFrom(t => t.Author.UserName))
            .ForMember(m => m.Content, u => u.MapFrom(t => t.Content))
            .ForMember(m => m.IsDeleted, u => u.MapFrom(t => t.IsDeleted))
            .ForMember(m => m.ModifiedOn, u => u.MapFrom(t => t.ModifiedOn))
            .ForMember(m => m.CreatedOn, u => u.MapFrom(t => t.CreatedOn))
            .ReverseMap();
        }
    }
}