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
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly DbSet<User> _users;

		public UserRepository(LowCostHotelContext lowCostHotelContext)
			: base(lowCostHotelContext)
		{
			_users = lowCostHotelContext.Users;
		}

		public override async Task<IEnumerable<User>> GetAllAsync()
		{
			return await GetQueryWithIncludes().ToListAsync();
		}

		public override async Task<User> GetByIdAsync(int id)
		{
			return await GetQueryWithIncludes().FirstOrDefaultAsync(u => u.Id == id);
		}

		private IQueryable<User> GetQueryWithIncludes()
		{
			return _users.Include(u => u.Residences);
		}
	}
}
