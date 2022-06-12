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
	public class ResourceRepository : Repository<Resource>, IResourceRepository
	{
		private readonly DbSet<Resource> _resources;

		public ResourceRepository(LowCostHotelContext lowCostHotelContext)
			: base(lowCostHotelContext)
		{
			_resources = lowCostHotelContext.Resources;
		}

		public override async Task<IEnumerable<Resource>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<Resource> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(r => r.Id == id);
		}

		private IQueryable<Resource> GetQueryWithIncludes()
		{
			return _resources.Include(r => r.Residences);
		}
	}
}
