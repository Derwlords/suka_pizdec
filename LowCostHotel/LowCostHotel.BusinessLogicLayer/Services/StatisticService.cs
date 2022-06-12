using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Models.Statistic;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using LowCostHotel.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IStatisticRepository _statistics;
		private readonly IResidenceRepository _residences;
		private readonly IMapper _mapper;

		public StatisticService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_statistics = unitOfWork.Statistics;
			_residences = unitOfWork.Residences;
			_mapper = mapper;
		}

		public async Task<IEnumerable<StatisticDTO>> FindAllStatisticsAsync()
		{
			await UpdateStatisticsAsync();
			var statistics = await _statistics.GetAllAsync();
			return _mapper.Map<IEnumerable<StatisticDTO>>(statistics);
		}

		public async Task<StatisticDTO> FindByIdAsync(int id)
		{
			await UpdateStatisticsAsync();
			var statistic = await _statistics.GetByIdAsync(id);
			return _mapper.Map<StatisticDTO>(statistic);
		}

		private async Task UpdateStatisticsAsync()
		{
			var residences = await _residences.GetAllAsync();
			var unPaidedFinishedResidences = residences
				.Where(r => r.End.CompareTo(DateTime.Now) < 0)
				.Where(r => !r.Paided).ToList();
			
			foreach(var residence in unPaidedFinishedResidences)
			{
				await CreateAsync(residence);
				await UpdateResidenceAsync(residence);
			}
		}

		private async Task CreateAsync(Residence residence)
		{
			int hoursSpent = (int)(residence.End - residence.Start).TotalHours;

			double profitPerRoom = hoursSpent * residence.HotelRoom.PricePerDay / 24;
			double profitPerResource = hoursSpent * residence.Resource.PricePerHour;

			double profit = profitPerRoom + profitPerResource;

			var statistic = new Statistic
			{
				Id = 0,
				UserName = residence.User.FullName,
				HostelRoom = residence.HotelRoom.Name,
				PricePerDay = residence.HotelRoom.PricePerDay,
				ResourceName = residence.Resource.Name,
				ResourcePricePerHour = residence.Resource.PricePerHour,
				Start = residence.Start,
				End = residence.End,
				Profit = profit
			};

			var result = await _statistics.AddAsync(statistic);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateResidenceAsync(Residence residenceToUpdate)
		{
			var residence = await _residences.GetByIdAsync(residenceToUpdate.Id);
			residence.Paided = true;

			var updated = await _residences.UpdateAsync(residence);
			await _unitOfWork.SaveAsync();
		}
	}
}
