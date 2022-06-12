using LowCostHotelMobile.Models;
using LowCostHotelMobile.Services.Interfaces;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services
{
	public class UserService : BaseService, IUserService
	{
		private string baseUrl;

		public UserService()
		{
			baseUrl = domain_api + "/api/users/";
		}

		public async Task<User> FindMyUserAsync()
		{
			return await GetQueryAsync<User>(baseUrl + "my/");
		}
	}
}
