using LowCostHotel.BusinessLogicLayer.Models.Recidence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services.Interfaces
{
	public interface IResidenceService
	{
		Task<IEnumerable<ResidenceDTO>> FindAllResidencesAsync();

		Task<ResidenceDTO> FindByIdAsync(int id);

		Task<IEnumerable<ResidenceDTO>> FindResidencesByUserAsync(int userId);

		Task<ResidenceDTO> CreateAsync(CreateResidenceDTO residence);

		Task<ResidenceDTO> UpdateAsync(UpdateResidenceDTO residenceToUpdate);

		Task<ResidenceDTO> DeleteAsync(int id);
	}
}
