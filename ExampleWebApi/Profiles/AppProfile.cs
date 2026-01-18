using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;

namespace ExampleWebApi.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            
            CreateMap<WishedItem, WishedItemDto>().ReverseMap();
            CreateMap<OwnedItem, OwnedItemDto>().ReverseMap();
            
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();

            CreateMap<User, ResponseUserDto>();
        }
    }
}
