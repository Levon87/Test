using MediatR;

namespace Application.Office.RemoveOffice
{
	public sealed class RemoveOfficeCommand : IRequest
	{
		public int Id { get; set; }
	}
}
