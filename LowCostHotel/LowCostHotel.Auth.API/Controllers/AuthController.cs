using LowCostHotel.Auth.Common;
using LowCostHotel.BusinessLogicLayer.Models.Shared;
using LowCostHotel.BusinessLogicLayer.Models.User;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LowCostHotel.Auth.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOption> _authOptions;
		private readonly IUserService _userService;

		public AuthController(IOptions<AuthOption> authOptions,
			IUserService userService)
		{
			_authOptions = authOptions;
			_userService = userService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] Login login)
		{
			var user = await _userService.FindByLoginAsync(login);
			if (user == null)
			{
				return BadRequest("Error email or password!");
			}

			string token = GenerateJWT(user);
			return Ok(new { accessToken = token });
		}


		private string GenerateJWT(UserDTO user)
		{
			var authParams = _authOptions.Value;

			var securityKey = authParams.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("role", user.Role)
			};

			var token = new JwtSecurityToken(authParams.Issuer,
				authParams.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(authParams.Tokenlifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
