using LowCostHotel.API.Additional;
using LowCostHotel.BusinessLogicLayer.Models.Recidence;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.API.Controllers
{
	[ApiController]
	[Route("api/residences")]
	public class ResidencesController : ControllerBase
	{
		private readonly IResidenceService _residenceService;

		public ResidencesController(IResidenceService residenceService)
		{
			_residenceService = residenceService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetResidences()
		{
			var items = await _residenceService.FindAllResidencesAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetResidenceById(int id)
		{
			var item = await _residenceService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpGet("my")]
		[Authorize]
		public async Task<IActionResult> GetMyResidences()
		{
			int myId = User.Id();
			var items = await _residenceService.FindResidencesByUserAsync(myId);

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateResidence(
			[FromBody] CreateResidenceDTO ResidenceToCreate)
		{
			var result = await _residenceService.CreateAsync(ResidenceToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateResidence(
			[FromBody] UpdateResidenceDTO ResidenceToUpdate)
		{
			var result = await _residenceService.UpdateAsync(ResidenceToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteResidence(int id)
		{
			await _residenceService.DeleteAsync(id);
			return Ok();
		}
	}
}
