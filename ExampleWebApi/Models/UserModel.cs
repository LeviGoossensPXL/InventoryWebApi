using AutoMapper;
using ExampleWebApi.Domain.Entities;

namespace ExampleWebApi.Api.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}