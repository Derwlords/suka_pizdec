using LowCostHotel.BusinessLogicLayer.Models.Statistic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services.Interfaces
{
	public interface IStatisticService
	{
		Task<IEnumerable<StatisticDTO>> FindAllStatisticsAsync();

		Task<StatisticDTO> FindByIdAsync(int id);
	}
}
