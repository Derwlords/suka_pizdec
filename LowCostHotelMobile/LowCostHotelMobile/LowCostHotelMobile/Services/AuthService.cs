using LowCostHotelMobile.Models;
using LowCostHotelMobile.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace LowCostHotelMobile.Services
{
	public class AuthService : BaseService, IAuthService
	{
		private readonly string baseUrl;

		public AuthService()
		{
			baseUrl = domain_auth_api + "/api/auth/";
		}

		public async Task<bool> LoginAsync(Login login)
		{
			string url = baseUrl + "login/";

			var response = await PostQueryWithResponseAsync(url, login);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				string stringResponse = await response.Content.ReadAsStringAsync();

				string token = stringResponse.Substring(16).Trim('\\', '\"', '}');

				SetToken(token);

				return true;
			}

			return false;
		}

		public async Task<bool> Logout()
		{
			bool result = RemoveToken();
			return await Task.FromResult(result);
		}

		private void SetToken(string token)
		{
			RemoveToken();
			App.Current.Properties.Add(nameAccessToken, token);
		}

		private bool RemoveToken()
		{
			return App.Current.Properties.Remove(nameAccessToken);
		}

		public async Task<bool> IsLogged()
		{
			return await Task.FromResult(IsAuthorized());
		}
	}
}
