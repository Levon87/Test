using AutoMapper;
using EFData;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Office.CreateOffice
{
	public sealed class CreateOfficeHandler : AsyncRequestHandler<CreateOfficeCommand>
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public CreateOfficeHandler(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		protected async override Task Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
		{
			if (request != null)
			{
				var office = _mapper.Map<CreateOfficeCommand, Domain.Entities.Office>(request);

				await _context.Offices.AddAsync(office, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
