using System;
using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.Recidence
{
	public class UpdateResidenceDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int HotelRoomId { get; set; }

		[Required]
		public int ResourceId { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Start { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime End { get; set; }
	}
}
