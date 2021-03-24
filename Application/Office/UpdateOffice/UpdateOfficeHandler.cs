using AutoMapper;
using EFData;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Office.UpdateOffice
{
	public sealed class UpdateOfficeHandler : AsyncRequestHandler<UpdateOfficeCommand>
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		public UpdateOfficeHandler(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		protected async override Task Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
		{
			if (request.Id == default)
			{
				throw new ArgumentException(nameof(request.Id));
			}

			var officeInRepo = await _context.Offices.FindAsync(request.Id);

			if (officeInRepo != null)
			{
				var office = _mapper.Map(request, officeInRepo);

				_context.Offices.Update(office);
				await _context.SaveChangesAsync(cancellationToken);
			}
			else
			{
				throw new Exception("Not Found");
			}
		}
	}
}
