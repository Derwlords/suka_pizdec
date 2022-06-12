using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LowCostHotel.DataAccessLayer.Models
{
	public class Statistic
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Column(Order = 2)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string UserName { get; set; }

		[Required]
		[Column(Order = 3)]
		[StringLength(50)]
		[DataType(DataType.Text)]
		public string HostelRoom { get; set; }

		[Required]
		[Column(Order = 4)]
		public double PricePerDay { get; set; }

		[Required]
		[Column(Order = 5)]
		public string ResourceName { get; set; }

		[Required]
		[Column(Order = 6)]
		public double ResourcePricePerHour { get; set; }

		[Required]
		[Column(Order = 7)]
		[DataType(DataType.DateTime)]
		public DateTime Start { get; set; }

		[Required]
		[Column(Order = 8)]
		[DataType(DataType.DateTime)]
		public DateTime End { get; set; }

		[Required]
		[Column(Order = 9)]
		public double Profit { get; set; }
	}
}
