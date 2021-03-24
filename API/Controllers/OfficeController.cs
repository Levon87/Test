using Application.Office;
using Application.Office.AddOfficeUser;
using Application.Office.CreateOffice;
using Application.Office.DeleteOfficeUser;
using Application.Office.FindOffice;
using Application.Office.RemoveOffice;
using Application.Office.UpdateOffice;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class OfficeController : BaseController
	{		 
		private readonly IMediator _mediator;

		public OfficeController(IMediator mediator )
		{
			_mediator = mediator;			 
		}

		[HttpGet("findoffice")]
		[AllowAnonymous]
		public Task<List<OfficeViewModel>> FindOffice([FromQuery] FindOfficeQuery query)
		{
			return Mediator.Send(query);
		}

		[HttpPost("createoffice")]
		[AllowAnonymous]
		public Task CreateOffice([FromBody] CreateOfficeCommand command)
		{
			return Mediator.Send(command);
		}

		[HttpPost("updateoffice")]
		[AllowAnonymous]
		public Task UpdateOffice([FromBody] UpdateOfficeCommand command)
		{
			return Mediator.Send(command);
		}

		[HttpPost("removeoffice")]
		[AllowAnonymous]
		public Task RemoveOffice([FromBody] RemoveOfficeCommand command)
		{
			return Mediator.Send(command);
		}

		[HttpPost("addofficeuser")]
		[AllowAnonymous]
		public Task AddOfficeUser([FromBody] AddOfficeUserCommand command)
		{
			return Mediator.Send(command);
		}

		[HttpPost("deletefficeuser")]
		[AllowAnonymous]
		public Task DeleteOfficeUser([FromBody] DeleteOfficeUserCommand command)
		{
			return Mediator.Send(command);
		}
	}
}
