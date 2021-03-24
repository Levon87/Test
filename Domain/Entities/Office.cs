 using System.Collections.Generic; 

namespace Domain.Entities
{
	public class Office
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<OfficeUsers> OfficeUsers { get; set; } = new List<OfficeUsers>();
	}
}
