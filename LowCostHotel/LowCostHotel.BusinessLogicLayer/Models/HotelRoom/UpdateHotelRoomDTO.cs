using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.HotelRoom
{
	public class UpdateHotelRoomDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		public int NumberOfRooms { get; set; }

		[Required]
		[StringLength(50)]
		public string Address { get; set; }

		[Required]
		public double PricePerDay { get; set; }
	}
}
