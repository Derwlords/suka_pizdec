using LowCostHotel.BusinessLogicLayer.Models.HotelRoom;
using LowCostHotel.BusinessLogicLayer.Models.Resource;
using LowCostHotel.BusinessLogicLayer.Models.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace LowCostHotel.BusinessLogicLayer.Models.Recidence
{
	public class ResidenceDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		public virtual UserDTO User { get; set; }

		[Required]
		public int HotelRoomId { get; set; }

		public virtual HotelRoomDTO HotelRoom { get; set; }

		[Required]
		public int ResourceId { get; set; }

		public virtual ResourceDTO Resource { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime Start { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime End { get; set; }

		[Required]
		public bool Paided { get; set; }
	}
}
