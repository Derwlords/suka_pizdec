using LowCostHotel.BusinessLogicLayer.Models.HotelRoom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services.Interfaces
{
	public interface IHotelRoomService
	{
		Task<IEnumerable<HotelRoomDTO>> FindAllHotelRoomsAsync();

		Task<HotelRoomDTO> FindByIdAsync(int id);

		Task<HotelRoomDTO> CreateAsync(CreateHotelRoomDTO hotelRoom);

		Task<HotelRoomDTO> UpdateAsync(UpdateHotelRoomDTO hotelRoomToUpdate);

		Task<HotelRoomDTO> DeleteAsync(int id);
	}
}
