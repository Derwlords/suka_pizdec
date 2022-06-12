using LowCostHotel.BusinessLogicLayer.Validation;
using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.User
{
	public class UpdateUserDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string FullName { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		[UpdateUserEmail(ErrorMessage = "Email already taken")]
		public string Email { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Role { get; set; }
	}
}
