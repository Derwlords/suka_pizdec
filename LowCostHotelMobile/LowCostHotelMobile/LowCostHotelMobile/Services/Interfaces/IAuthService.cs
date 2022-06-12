using LowCostHotelMobile.Models;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services.Interfaces
{
	public interface IAuthService
	{
		Task<bool> LoginAsync(Login login);

		Task<bool> IsLogged();

		Task<bool> Logout();
	}
}
