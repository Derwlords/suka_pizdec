using LowCostHotel.BusinessLogicLayer.Validation;
using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.User
{
	public class CreateUserDTO
	{
		[Required(ErrorMessage = "Field is required.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "The full name must be between {2} and {1} characters.")]
		[DataType(DataType.Text)]
		public string FullName { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		[ExistUserEmail(ErrorMessage = "Email already exist!")]
		public string Email { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 6, ErrorMessage = "The password must be between {2} and {1} characters.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Role { get; set; }
	}
}
