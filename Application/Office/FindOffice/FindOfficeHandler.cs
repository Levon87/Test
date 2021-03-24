using AutoMapper;
using EFData;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Office.FindOffice
{
	public sealed class FindOfficeHandler : IRequestHandler<FindOfficeQuery, List<OfficeViewModel>>
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public FindOfficeHandler(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<OfficeViewModel>> Handle(FindOfficeQuery request, CancellationToken cancellationToken)
		{
			var querable = _context.Offices.AsQueryable();
			if (request.Ids != null && request.Ids.Any())
			{
				querable = querable.Where(x => request.Ids.Contains(x.Id));
			}
			if (request.Skip != null)
			{
				querable = querable.Skip(request.Skip.Value);
			}
			if (request.Amount != null)
			{
				querable = querable.Take(request.Amount.Value);
			}

			var offices = await querable.ToListAsync(cancellationToken);
			var officeViewModel = _mapper.Map<List<Domain.Entities.Office>, List<OfficeViewModel>>(offices);

			return officeViewModel;
		}


	}
}
