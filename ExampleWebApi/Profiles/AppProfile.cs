using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;

namespace ExampleWebApi.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
            
            CreateMap<WishedItem, WishedItemDto>().ReverseMap();
            CreateMap<OwnedItem, OwnedItemDto>().ReverseMap();
            
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();

            CreateMap<User, ResponseUserDTO>();
        }
    }
}
