using LowCostHotel.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace LowCostHotel.DataAccessLayer.EF
{
	public class LowCostHotelContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }
		public DbSet<Residence> Residences { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Statistic> Statistics { get; set; }

		public LowCostHotelContext(DbContextOptions<LowCostHotelContext> options)
			: base(options)
		{
		}
	}
}
