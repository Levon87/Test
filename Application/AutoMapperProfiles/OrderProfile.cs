using System;
using System.Collections.Generic;
using System.Text;
using Application.Order;

namespace Application.AutoMapperProfiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.Entities.Order, OrderViewModel>()
                .ForMember(d => d.Id, c => c.MapFrom(p => p.Id))
                .ForMember(d => d.PaintType, c => c.MapFrom(p => p.PaintType))
                .ForMember(d => d.MaterialType, c => c.MapFrom(p => p.MaterialType))
                .ForMember(d => d.ModelElement, c => c.MapFrom(p => p.ModelElement))
                .ForMember(d => d.QuantityOfMaterial, c => c.MapFrom(p => p.QuantityOfMaterial))
                .ForMember(d => d.PrePrice, c => c.MapFrom(p => p.PrePrice))
                .ForMember(d => d.Brush, c => c.MapFrom(p => p.Brush))
                .ForMember(d => d.Balloon, c => c.MapFrom(p => p.Balloon))
                .ForMember(d => d.OrderDetails, c => c.MapFrom(p => p.OrderDetails))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}
