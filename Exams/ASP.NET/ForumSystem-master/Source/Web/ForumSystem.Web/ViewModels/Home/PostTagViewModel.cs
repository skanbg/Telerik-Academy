namespace ForumSystem.Web.ViewModels.Home
{
    using System;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PostTagViewModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, PostTagViewModel>()
            .ForMember(m => m.Id, u => u.MapFrom(t => t.Id))
            .ForMember(m => m.Name, u => u.MapFrom(t => t.Name))
            .ReverseMap();
        }
    }
}