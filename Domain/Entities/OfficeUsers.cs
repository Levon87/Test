 namespace Domain.Entities
{
	public class OfficeUsers
	{
		public string UserId { get; set; }
		public AppUser User { get; set; }
		public int OfficeId { get; set; }
		public Office Office { get; set; }
	}
}
