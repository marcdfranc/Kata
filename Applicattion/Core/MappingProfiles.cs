using AutoMapper;
using Domain;
using Domain.Dto;
using Domain.Profiles;

namespace Applicattion.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Basket, Basket>();
            CreateMap<Basket, BasketDto>();

            CreateMap<BasketItem, ProductProfile>()
                .ForMember(b => b.Product, o => o.MapFrom(s => s.Product.Name))
                .ForMember(b => b.Price, o => o.MapFrom(s => s.Product.Price))
                .ForMember(b => b.Promotion, o => o.MapFrom(s => s.Product.type))
                .ForMember(b => b.Basket, o => o.MapFrom(s => s.Basket.Description));
        }
    }
}
