using AutoMapper;
using Project.Minimal.Domain.Product;
using Project.Minimal.Domain.Response;

namespace Project.Minimal.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductResponse>().ReverseMap();
        }
    }
}
