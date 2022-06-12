using LowCostHotel.DataAccessLayer.EF;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Common;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.Repositories
{
	public class HotelRoomRepository : Repository<HotelRoom>, IHotelRoomRepository
	{
		private readonly DbSet<HotelRoom> _hostelRooms;

		public HotelRoomRepository(LowCostHotelContext lowCostHotelContext)
			: base(lowCostHotelContext)
		{
			_hostelRooms = lowCostHotelContext.HotelRooms;
		}

		public override async Task<IEnumerable<HotelRoom>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<HotelRoom> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(h => h.Id == id);
		}

		private IQueryable<HotelRoom> GetQueryWithIncludes()
		{
			return _hostelRooms.Include(r => r.Residences);
		}
	}
}
