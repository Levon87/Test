using Application.Office;
using Application.Office.CreateOffice;
using Application.Office.RemoveOffice;
using Application.Office.UpdateOffice;

namespace Application.AutoMapperProfiles
{
	public class OfficeProfile : AutoMapper.Profile
	{
		public OfficeProfile()
		{
			CreateMap<Domain.Entities.Office, OfficeViewModel>()
				.ForMember(d => d.Id, c => c.MapFrom(p => p.Id))
				.ForMember(d => d.Name, c => c.MapFrom(p => p.Name))
				.ForAllOtherMembers(c => c.Ignore());

			CreateMap<CreateOfficeCommand, Domain.Entities.Office>()
				.ForMember(d => d.Id, c => c.MapFrom(p => p.Id))
				.ForMember(d => d.Name, c => c.MapFrom(p => p.Name))
				.ForAllOtherMembers(c => c.Ignore());

			CreateMap<UpdateOfficeCommand, Domain.Entities.Office>()
				.ForMember(d => d.Id, c => c.MapFrom(p => p.Id))
				.ForMember(d => d.Name, c => c.MapFrom(p => p.Name))
				.ForAllOtherMembers(c => c.Ignore());

			CreateMap<RemoveOfficeCommand, Domain.Entities.Office>()
			.ForMember(d => d.Id, c => c.MapFrom(p => p.Id))			 
			.ForAllOtherMembers(c => c.Ignore());
		}

	}
}
