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
	public class ResidenceRepository : Repository<Residence>, IResidenceRepository
	{
		private readonly DbSet<Residence> _residences;

		public ResidenceRepository(LowCostHotelContext lowCostHotelContext)
			: base(lowCostHotelContext)
		{
			_residences = lowCostHotelContext.Residences;
		}

		public override async Task<IEnumerable<Residence>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<Residence> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(r => r.Id == id);
		}

		private IQueryable<Residence> GetQueryWithIncludes()
		{
			return _residences.Include(r => r.User)
				.Include(r => r.Resource)
				.Include(r => r.HotelRoom);
		}
	}
}
