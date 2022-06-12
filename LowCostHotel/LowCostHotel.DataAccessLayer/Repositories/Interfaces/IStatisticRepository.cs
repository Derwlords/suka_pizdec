using LowCostHotel.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.Repositories.Interfaces
{
	public interface IStatisticRepository
	{
		Task<IEnumerable<Statistic>> GetAllAsync();

		Task<Statistic> GetByIdAsync(int id);

		Task<Statistic> AddAsync(Statistic statistic);

		Task<Statistic> UpdateAsync(Statistic updatedStatistic);

		Task<Statistic> DeleteAsync(Statistic statistic);
	}
}
