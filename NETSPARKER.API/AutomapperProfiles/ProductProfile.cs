using AutoMapper;
using NETSPARKER.Core.Entities;
using NETSPARKER.API.Models;

namespace NETSPARKER.API.AutomapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, ProductEntity>().ReverseMap();
        }
    }
}
