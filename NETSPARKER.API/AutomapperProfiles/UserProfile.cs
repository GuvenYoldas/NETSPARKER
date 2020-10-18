using AutoMapper;
using NETSPARKER.Core.Entities;
using NETSPARKER.API.Models;

namespace NETSPARKER.API.AutomapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}
