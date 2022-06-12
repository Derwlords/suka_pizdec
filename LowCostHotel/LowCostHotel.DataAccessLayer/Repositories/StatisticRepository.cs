using LowCostHotel.DataAccessLayer.EF;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Common;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;

namespace LowCostHotel.DataAccessLayer.Repositories
{
	public class StatisticRepository : Repository<Statistic>, IStatisticRepository
	{
		public StatisticRepository(LowCostHotelContext lowCostHotelContext)
			: base(lowCostHotelContext)
		{

		}
	}
}
