using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LowCostHotel.Auth.Common
{
	public class AuthOption
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Secret { get; set; }
		public int Tokenlifetime { get; set; }

		public SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
		}
	}
}
