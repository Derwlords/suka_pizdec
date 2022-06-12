using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LowCostHotel.DataAccessLayer.UnitOfWork
{
	public interface IUnitOfWork
	{
		IUserRepository Users { get; }

		IHotelRoomRepository HotelRooms{ get; }

		IResidenceRepository Residences { get; }

		IResourceRepository  Resources { get; }

		IStatisticRepository Statistics { get; }

		Task SaveAsync();
	}
}
