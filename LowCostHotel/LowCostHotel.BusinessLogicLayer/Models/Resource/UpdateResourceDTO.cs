using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.Resource
{
	public class UpdateResourceDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		public double PricePerHour { get; set; }
	}
}
