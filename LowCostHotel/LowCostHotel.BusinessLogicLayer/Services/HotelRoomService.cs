using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Models.HotelRoom;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using LowCostHotel.DataAccessLayer.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services
{
	public class HotelRoomService : IHotelRoomService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IHotelRoomRepository _hotelRooms;
		private readonly IMapper _mapper;

		public HotelRoomService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_hotelRooms = unitOfWork.HotelRooms;
			_mapper = mapper;
		}

		public async Task<HotelRoomDTO> CreateAsync(CreateHotelRoomDTO hotelRoom)
		{
			var mapped = _mapper.Map<HotelRoom>(hotelRoom);
			var result = await _hotelRooms.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<HotelRoomDTO>(result);
		}

		public async Task<HotelRoomDTO> DeleteAsync(int id)
		{
			var hotelRoom = await _hotelRooms.GetByIdAsync(id);
			if (hotelRoom != null)
			{
				var deleted = await _hotelRooms.DeleteAsync(hotelRoom);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<HotelRoomDTO>(deleted);
			}

			return null;
		}

		public async Task<IEnumerable<HotelRoomDTO>> FindAllHotelRoomsAsync()
		{
			var hotelRooms = await _hotelRooms.GetAllAsync();
			return _mapper.Map<IEnumerable<HotelRoomDTO>>(hotelRooms);
		}

		public async Task<HotelRoomDTO> FindByIdAsync(int id)
		{
			var hotelRoom = await _hotelRooms.GetByIdAsync(id);
			return _mapper.Map<HotelRoomDTO>(hotelRoom);
		}

		public async Task<HotelRoomDTO> UpdateAsync(UpdateHotelRoomDTO hotelRoomToUpdate)
		{
			var hotelRoom = await _hotelRooms.GetByIdAsync(hotelRoomToUpdate.Id);
			hotelRoom = _mapper.Map(hotelRoomToUpdate, hotelRoom);

			var updated = await _hotelRooms.UpdateAsync(hotelRoom);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<HotelRoomDTO>(updated);
		}
	}
}
