using LowCostHotelMobile.Models;
using LowCostHotelMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services
{
	public class StatisticService : BaseService, IStatisticService
	{
		private readonly string baseUrl;

		public StatisticService()
		{
			baseUrl = domain_api + "/api/statistics/";
		}

		public async Task<IEnumerable<Statistic>> FindAllAsync()
		{
			string url = baseUrl;
			return await GetQueryAsync<IEnumerable<Statistic>>(url);
		}

		public async Task<Statistic> FindByIdAsync(int id)
		{
			string url = baseUrl + id + "/";
			return await GetQueryAsync<Statistic>(url);
		}
	}
}
