using LowCostHotel.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.Repositories.Interfaces
{
	public interface IResidenceRepository
	{
		Task<IEnumerable<Residence>> GetAllAsync();

		Task<Residence> GetByIdAsync(int id);

		Task<Residence> AddAsync(Residence residence);

		Task<Residence> UpdateAsync(Residence updatedResidence);

		Task<Residence> DeleteAsync(Residence residence);
	}
}
