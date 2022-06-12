using LowCostHotel.BusinessLogicLayer.Models.Resource;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services.Interfaces
{
	public interface IResourceService
	{
		Task<IEnumerable<ResourceDTO>> FindAllResourcesAsync();

		Task<ResourceDTO> FindByIdAsync(int id);

		Task<ResourceDTO> CreateAsync(CreateResourceDTO resource);

		Task<ResourceDTO> UpdateAsync(UpdateResourceDTO resourceToUpdate);

		Task<ResourceDTO> DeleteAsync(int id);
	}
}
