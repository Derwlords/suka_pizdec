using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Validation
{
	public class ExistUserEmailAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IUserService userService =
					(IUserService)validationContext.GetService(typeof(IUserService));

				var user = userService.FindByEmailAsync(value.ToString()).Result;
				if (user != null)
				{
					return new ValidationResult(ErrorMessage);
				}
			}

			return ValidationResult.Success;
		}
	}
}
