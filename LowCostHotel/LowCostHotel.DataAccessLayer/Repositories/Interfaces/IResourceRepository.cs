using LowCostHotel.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.Repositories.Interfaces
{
	public interface IResourceRepository
	{
		Task<IEnumerable<Resource>> GetAllAsync();

		Task<Resource> GetByIdAsync(int id);

		Task<Resource> AddAsync(Resource resource);

		Task<Resource> UpdateAsync(Resource updatedResource);

		Task<Resource> DeleteAsync(Resource resource);
	}
}
