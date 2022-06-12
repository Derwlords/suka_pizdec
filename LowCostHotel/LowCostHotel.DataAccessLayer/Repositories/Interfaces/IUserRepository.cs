using LowCostHotel.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync();

		Task<User> GetByIdAsync(int id);

		Task<User> AddAsync(User user);

		Task<User> UpdateAsync(User updatedUser);

		Task<User> DeleteAsync(User user);
	}
}
