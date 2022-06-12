using LowCostHotelMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services.Interfaces
{
	public interface IStatisticService
	{
		Task<IEnumerable<Statistic>> FindAllAsync();

		Task<Statistic> FindByIdAsync(int id);
	}
}
