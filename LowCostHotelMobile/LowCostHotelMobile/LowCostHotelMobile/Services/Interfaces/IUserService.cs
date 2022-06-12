using LowCostHotelMobile.Models;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> FindMyUserAsync();
	}
}
