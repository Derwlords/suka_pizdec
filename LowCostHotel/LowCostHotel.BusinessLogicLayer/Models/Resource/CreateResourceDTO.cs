using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.Resource
{
	public class CreateResourceDTO
	{
		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		public double PricePerHour { get; set; }
	}
}
