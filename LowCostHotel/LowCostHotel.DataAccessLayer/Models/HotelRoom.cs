using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LowCostHotel.DataAccessLayer.Models
{
	public class HotelRoom
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[Column(Order = 3)]
		public int NumberOfRooms { get; set; }

		[Required]
		[Column(Order = 4)]
		[StringLength(50)]
		public string Address { get; set; }

		[Required]
		[Column(Order = 5)]
		public double PricePerDay { get; set; }

		public virtual ICollection<Residence> Residences { get; set; }

		public HotelRoom()
		{
			Residences = new Collection<Residence>();
		}
	}
}
