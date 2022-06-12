using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LowCostHotel.DataAccessLayer.Models
{
	public class Resource
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
		public double PricePerHour { get; set; }

		public virtual ICollection<Residence> Residences { get; set; }

		public Resource()
		{
			Residences = new Collection<Residence>();
		}
	}
}
