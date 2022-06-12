using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Models.Recidence;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using LowCostHotel.DataAccessLayer.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services
{
	public class ResidenceService : IResidenceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IResidenceRepository _residences;
		private readonly IMapper _mapper;

		public ResidenceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_residences = unitOfWork.Residences;
			_mapper = mapper;
		}

		public async Task<ResidenceDTO> CreateAsync(CreateResidenceDTO residence)
		{
			var mapped = _mapper.Map<Residence>(residence);
			var result = await _residences.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ResidenceDTO>(result);
		}

		public async Task<ResidenceDTO> DeleteAsync(int id)
		{
			var residence = await _residences.GetByIdAsync(id);
			if (residence != null)
			{
				var deleted = await _residences.DeleteAsync(residence);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<ResidenceDTO>(deleted);
			}

			return null;
		}

		public async Task<IEnumerable<ResidenceDTO>> FindAllResidencesAsync()
		{
			var residences = await _residences.GetAllAsync();
			return _mapper.Map<IEnumerable<ResidenceDTO>>(residences);
		}

		public async Task<ResidenceDTO> FindByIdAsync(int id)
		{
			var residence = await _residences.GetByIdAsync(id);
			return _mapper.Map<ResidenceDTO>(residence);
		}

		public async Task<IEnumerable<ResidenceDTO>> FindResidencesByUserAsync(int userId)
		{
			var residences = await _residences.GetAllAsync();
			var userResidences = residences.Where(r => r.UserId == userId);
			return _mapper.Map<IEnumerable<ResidenceDTO>>(userResidences);
		}

		public async Task<ResidenceDTO> UpdateAsync(UpdateResidenceDTO residenceToUpdate)
		{
			var residence = await _residences.GetByIdAsync(residenceToUpdate.Id);
			residence = _mapper.Map(residenceToUpdate, residence);

			var updated = await _residences.UpdateAsync(residence);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<ResidenceDTO>(updated);
		}
	}
}
