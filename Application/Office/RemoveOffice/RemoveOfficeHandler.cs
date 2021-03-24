using Application.Exceptions;
using AutoMapper;
using EFData;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Office.RemoveOffice
{
	public sealed class RemoveOfficeHandler : AsyncRequestHandler<RemoveOfficeCommand>
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public RemoveOfficeHandler(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		protected async override Task Handle(RemoveOfficeCommand request, CancellationToken cancellationToken)
		{
			if (request.Id != default)
			{
				var OfficeToRemove = _mapper.Map<RemoveOfficeCommand, Domain.Entities.Office>(request);

				_context.Offices.Remove(OfficeToRemove);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new RestException(HttpStatusCode.BadRequest, new { request.Id });
			}
		}
	}
}
