using MediatR;

namespace Application.Office.UpdateOffice
{
	public sealed class UpdateOfficeCommand : IRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
