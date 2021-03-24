using System;
using System.Collections.Generic;
using System.Text;
using Application.Client;

namespace Application.AutoMapperProfiles
{
    public class ClientProfile : AutoMapper.Profile
    {
        public ClientProfile()
        {
            CreateMap<Domain.Entities.Client, ClientViewModel>()
                .ForMember(d => d.Id, c => c.MapFrom(p => p.Id))
                .ForMember(d => d.FirstName, c => c.MapFrom(p => p.FirstName))
                .ForMember(d => d.SecondName, c => c.MapFrom(p => p.SecondName))
                .ForMember(d => d.Surname, c => c.MapFrom(p => p.Surname))
                .ForMember(d => d.Email, c => c.MapFrom(p => p.Email))
                .ForMember(d => d.Phone, c => c.MapFrom(p => p.Phone))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}
