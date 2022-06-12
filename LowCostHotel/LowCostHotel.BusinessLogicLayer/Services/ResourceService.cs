using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Models.Resource;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using LowCostHotel.DataAccessLayer.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services
{
	public class ResourceService : IResourceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IResourceRepository _resources;
		private readonly IMapper _mapper;

		public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_resources = unitOfWork.Resources;
			_mapper = mapper;
		}

		public async Task<ResourceDTO> CreateAsync(CreateResourceDTO resource)
		{
			var mapped = _mapper.Map<Resource>(resource);
			var result = await _resources.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<ResourceDTO>(result);
		}

		public async Task<ResourceDTO> DeleteAsync(int id)
		{
			var resource = await _resources.GetByIdAsync(id);
			if (resource != null)
			{
				var deleted = await _resources.DeleteAsync(resource);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<ResourceDTO>(deleted);
			}

			return null;
		}

		public async Task<IEnumerable<ResourceDTO>> FindAllResourcesAsync()
		{
			var resources = await _resources.GetAllAsync();
			return _mapper.Map<IEnumerable<ResourceDTO>>(resources);
		}

		public async Task<ResourceDTO> FindByIdAsync(int id)
		{
			var resource = await _resources.GetByIdAsync(id);
			return _mapper.Map<ResourceDTO>(resource);
		}

		public async Task<ResourceDTO> UpdateAsync(UpdateResourceDTO resourceToUpdate)
		{
			var resource = await _resources.GetByIdAsync(resourceToUpdate.Id);
			resource = _mapper.Map(resourceToUpdate, resource);

			var updated = await _resources.UpdateAsync(resource);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<ResourceDTO>(updated);
		}
	}
}
