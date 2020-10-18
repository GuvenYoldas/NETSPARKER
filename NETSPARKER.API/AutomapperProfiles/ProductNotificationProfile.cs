
using AutoMapper;
using NETSPARKER.Core.Entities;
using NETSPARKER.API.Models;

namespace NETSPARKER.API.AutomapperProfiles
{
    public class ProductNotificationProfile : Profile
    {
        public ProductNotificationProfile()
        {
            CreateMap<ProductNotificationModel, ProductNotificationEntity>().ReverseMap();
        }
    }
}