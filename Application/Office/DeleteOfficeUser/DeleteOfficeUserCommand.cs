using MediatR;

namespace Application.Office.DeleteOfficeUser
{
	public sealed class DeleteOfficeUserCommand : IRequest
	{
		public string UserId { get; set; }
		public int OfficeId { get; set; }
	}
}
