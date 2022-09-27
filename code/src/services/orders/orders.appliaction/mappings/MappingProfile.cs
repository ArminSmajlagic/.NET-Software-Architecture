using AutoMapper;
using EventBus.Messages.Events;
using orders.appliaction.features.orders.commands.CheckoutOrder;
using orders.appliaction.features.orders.commands.UpdateOrder;
using orders.appliaction.models.OrderVM;
using orders.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.appliaction.mappings
{
    internal class MappingProfile : Profile
    {

        
        public MappingProfile()
        {
            CreateMap<Order,CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order,UpdateOrderCommand>().ReverseMap();
            CreateMap<BasketCheckoutEvent, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order,OrdersVM>().ReverseMap();
            
        }
        
    }
}
