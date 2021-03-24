using Application.Exceptions;
using AutoMapper;
using Domain;
using EFData;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Office.AddOfficeUser
{
	public sealed class AddOfficeUserHandler : AsyncRequestHandler<AddOfficeUserCommand>
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;
		public AddOfficeUserHandler(DataContext context, IMapper mapper, UserManager<AppUser> userManagerr)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManagerr;
		}
		protected async override Task Handle(AddOfficeUserCommand request, CancellationToken cancellationToken)
		{
			if (request.UserId != null && request.OfficeId != default )
			{
				var currentOffice = await _context.Offices.FindAsync(request.OfficeId);

				if(currentOffice == null)
				{
					throw new RestException(HttpStatusCode.NotFound);
				}

				var user = await _userManager.FindByIdAsync(request.UserId);

				if(user != null)
				{
					_context.OfficeUsers.Add(new Domain.Entities.OfficeUsers { UserId = user.Id, OfficeId = currentOffice.Id });

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
