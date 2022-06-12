using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LowCostHotel.DataAccessLayer.Models
{
	public class Residence
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		public int UserId { get; set; }

		public virtual User User { get; set; }

		[Required]
		[Column(Order = 3)]
		public int HotelRoomId { get; set; }

		public virtual HotelRoom HotelRoom { get; set; }

		[Required]
		[Column(Order = 4)]
		public int ResourceId { get; set; }

		public virtual Resource Resource { get; set; }

		[Required]
		[Column(Order = 5)]
		[DataType(DataType.DateTime)]
		public DateTime Start { get; set; }

		[Required]
		[Column(Order = 6)]
		[DataType(DataType.DateTime)]
		public DateTime End { get; set; }

		[Required]
		[Column(Order = 7)]
		public bool Paided { get; set; }
	}
}
