using System;
using System.Security.Claims;

namespace LowCostHotel.API.Additional
{
	public static class CurrentUserClaims
	{
		public static int Id(this ClaimsPrincipal claims)
		{
			Int32.TryParse(claims
				.FindFirstValue(ClaimsIdentity.DefaultNameClaimType + "identifier"), out int id);
			return id;
		}
	}
}
