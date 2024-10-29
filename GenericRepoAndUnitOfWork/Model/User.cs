using System.ComponentModel.DataAnnotations;

namespace GenericRepoAndUnitOfWork.Model
{
	public class User
	{
		[Key]
		public Guid UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
	}
}
