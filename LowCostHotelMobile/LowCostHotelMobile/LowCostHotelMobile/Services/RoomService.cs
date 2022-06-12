using LowCostHotelMobile.Models;
using LowCostHotelMobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services
{
	public class RoomService : BaseService, IRoomService
	{
		private readonly string baseUrl;

		public RoomService()
		{
			baseUrl = domain_api + "/api/hotelrooms/";
		}

		public async Task<IEnumerable<Room>> FindAllAsync()
		{
			string url = baseUrl;
			return await GetQueryAsync<IEnumerable<Room>>(url);
		}

		public async Task<Room> FindByIdAsync(int id)
		{
			string url = baseUrl + id + "/";
			return await GetQueryAsync<Room>(url);
		}
	}
}
