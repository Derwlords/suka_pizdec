using LowCostHotel.BusinessLogicLayer.Models.Resource;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.API.Controllers
{
	[ApiController]
	[Route("api/resources")]
	public class ResourcesController : ControllerBase
	{
		private readonly IResourceService _resourceService;

		public ResourcesController(IResourceService resourceService)
		{
			_resourceService = resourceService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetResources()
		{
			var items = await _resourceService.FindAllResourcesAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetResourceById(int id)
		{
			var item = await _resourceService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> CreateResource(
			[FromBody] CreateResourceDTO resourceToCreate)
		{
			var result = await _resourceService.CreateAsync(resourceToCreate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error create!");
		}

		[HttpPut]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateResource(
			[FromBody] UpdateResourceDTO resourceToUpdate)
		{
			var result = await _resourceService.UpdateAsync(resourceToUpdate);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error update!");
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteResource(int id)
		{
			await _resourceService.DeleteAsync(id);
			return Ok();
		}
	}
}
