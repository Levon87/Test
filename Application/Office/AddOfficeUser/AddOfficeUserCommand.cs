using MediatR;

namespace Application.Office.AddOfficeUser
{
	public sealed class AddOfficeUserCommand : IRequest
	{
		public int OfficeId { get; set; }
		public string UserId { get; set; }
	}
}
