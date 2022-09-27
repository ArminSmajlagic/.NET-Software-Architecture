using AutoMapper;
using basket.api.Models;
using EventBus.Messages.Events;

namespace basket.api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
