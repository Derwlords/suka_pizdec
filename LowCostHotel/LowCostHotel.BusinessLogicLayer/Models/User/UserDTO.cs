
namespace LowCostHotel.BusinessLogicLayer.Models.User
{
	public class UserDTO
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public string Email { get; set; }

		public string HashedPassword { get; set; }

		public string Role { get; set; }
	}
}
