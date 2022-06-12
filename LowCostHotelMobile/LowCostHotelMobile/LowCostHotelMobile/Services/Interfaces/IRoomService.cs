using LowCostHotelMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services.Interfaces
{
	public interface IRoomService
	{
		Task<IEnumerable<Room>> FindAllAsync();

		Task<Room> FindByIdAsync(int id);
	}
}
