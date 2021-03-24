using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Office.FindOffice
{
	public sealed class FindOfficeQuery : IRequest<List<OfficeViewModel>>
	{
		public List<int> Ids { get; set; }
		public int? Skip { get; set; }
		public int? Amount { get; set; }
	}
}
