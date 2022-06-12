using LowCostHotel.BusinessLogicLayer.Models.HotelRoom;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.API.Controllers
{
	[ApiController]
	[Route("api/hotelrooms")]
	public class HotelRoomsController : ControllerBase
	{
		private readonly IHotelRoomService _hotelRoomService;

		public HotelRoomsController(IHotelRoomService hotelRoomService)
		{
			_hotelRoomService = hotelRoomService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetHotelRooms()
		{
			var items = await _hotelRoomService.FindAllHotelRoomsAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetHotelRoomById(int id)
		{
			var item = await _hotelRoomService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateHotelRoom(
			[FromBody] CreateHotelRoomDTO hotelRoomToCreate)
		{
			var result = await _hotelRoomService.CreateAsync(hotelRoomToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateHotelRoom(
			[FromBody] UpdateHotelRoomDTO hotelRoomToUpdate)
		{
			var result = await _hotelRoomService.UpdateAsync(hotelRoomToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteHotelRoom(int id)
		{
			await _hotelRoomService.DeleteAsync(id);
			return Ok();
		}
	}
}
