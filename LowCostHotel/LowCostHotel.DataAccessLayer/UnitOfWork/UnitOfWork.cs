using LowCostHotel.DataAccessLayer.EF;
using LowCostHotel.DataAccessLayer.Repositories;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly LowCostHotelContext _lowCostHotelContext;
		private IUserRepository _userRepository;
		private IHotelRoomRepository _hotelRoomRepository;
		private IResidenceRepository _residenceRepository;
		private IResourceRepository _resourceRepository;
		private IStatisticRepository _statisticRepository;

		public UnitOfWork(LowCostHotelContext lowCostHotelContext)
		{
			_lowCostHotelContext = lowCostHotelContext;
		}
			
		public IUserRepository Users
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_lowCostHotelContext);
				}

				return _userRepository;
			}
		}

		public IHotelRoomRepository HotelRooms
		{
			get
			{
				if (_hotelRoomRepository == null)
				{
					_hotelRoomRepository = new HotelRoomRepository(_lowCostHotelContext);
				}

				return _hotelRoomRepository;
			}
		}

		public IResidenceRepository Residences
		{
			get
			{
				if (_residenceRepository == null)
				{
					_residenceRepository = new ResidenceRepository(_lowCostHotelContext);
				}

				return _residenceRepository;
			}
		}

		public IResourceRepository Resources
		{
			get
			{
				if (_resourceRepository == null)
				{
					_resourceRepository = new ResourceRepository(_lowCostHotelContext);
				}

				return _resourceRepository;
			}
		}

		public IStatisticRepository Statistics
		{
			get
			{
				if (_statisticRepository == null)
				{
					_statisticRepository = new StatisticRepository(_lowCostHotelContext);
				}

				return _statisticRepository;
			}
		}

		public async Task SaveAsync()
		{
			await _lowCostHotelContext.SaveChangesAsync();
		}
	}
}
