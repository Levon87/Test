using MediatR;

namespace Application.Office.CreateOffice
{
	public sealed class CreateOfficeCommand : IRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
