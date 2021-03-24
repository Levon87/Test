using Application.Exceptions;
using AutoMapper;
using Domain;
using EFData;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Office.DeleteOfficeUser
{
	class DeleteOfficeUserHandler : AsyncRequestHandler<DeleteOfficeUserCommand>
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;
		public DeleteOfficeUserHandler(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
		}
		protected async override Task Handle(DeleteOfficeUserCommand request, CancellationToken cancellationToken)
		{
			if (request.UserId != null && request.OfficeId != default)
			{
				var currentOffice = await _context.Offices.FindAsync(request.OfficeId);

				if (currentOffice == null)
				{
					throw new RestException(HttpStatusCode.NotFound);
				}

				var user = await _userManager.FindByIdAsync(request.UserId);

				if (user != null)
				{
					_context.OfficeUsers.Remove(new Domain.Entities.OfficeUsers { UserId = user.Id, OfficeId = currentOffice.Id });
					await _context.SaveChangesAsync();
				}
			}
			else
			{
				throw new RestException(HttpStatusCode.BadRequest);
			}
		}
	}
}
