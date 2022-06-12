using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.API.Controllers
{
	[ApiController]
	[Route("api/statistics")]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticService _statisticService;

		public StatisticsController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetStatistics()
		{
			var items = await _statisticService.FindAllStatisticsAsync();

			if (items.Count() > 0)
			{
				return Ok(items);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<IActionResult> GetStatisticById(int id)
		{
			var item = await _statisticService.FindByIdAsync(id);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}
	}
}
