namespace ForumSystem.Web.ViewModels.PageableFeedbackList
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Feedback, FeedbackViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Title, u => u.MapFrom(t => t.Title))
            .ForMember(m => m.Content, u => u.MapFrom(t => t.Content))
            .ForMember(m => m.AuthorName, u => u.MapFrom(t => t.Author.UserName))
            .ForMember(m => m.CreatedOn, u => u.MapFrom(t => t.CreatedOn))
            .ReverseMap();
        }
    }
}