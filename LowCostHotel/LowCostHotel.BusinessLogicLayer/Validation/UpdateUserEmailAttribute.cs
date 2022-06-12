using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LowCostHotel.BusinessLogicLayer.Validation
{
	public class UpdateUserEmailAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				IUserService userService =
					(IUserService)validationContext.GetService(typeof(IUserService));

				var user = userService.FindByEmailAsync(value.ToString()).Result;
				if (user == null)
				{
					return ValidationResult.Success;
				}

				PropertyInfo pi = validationContext.ObjectInstance.GetType().GetProperty("Id");
				int userId = (int)pi.GetValue(validationContext.ObjectInstance, null);

				if (user.Id != userId)
				{
					return new ValidationResult(ErrorMessage);
				}

			}

			return ValidationResult.Success;
		}
	}
}
