using LowCostHotel.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.Repositories.Interfaces
{
	public interface IHotelRoomRepository
	{
		Task<IEnumerable<HotelRoom>> GetAllAsync();

		Task<HotelRoom> GetByIdAsync(int id);

		Task<HotelRoom> AddAsync(HotelRoom hostelRoom);

		Task<HotelRoom> UpdateAsync(HotelRoom updatedHostelRoom);

		Task<HotelRoom> DeleteAsync(HotelRoom hostelRoom);
	}
}
