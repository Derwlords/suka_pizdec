using LowCostHotel.Auth.Common;
using LowCostHotel.BusinessLogicLayer.Integrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace LowCostHotel.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var authOptions = Configuration.GetSection("Auth").Get<AuthOption>();
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = authOptions.Issuer,

						ValidateAudience = true,
						ValidAudience = authOptions.Audience,

						ValidateLifetime = true,

						IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
						ValidateIssuerSigningKey = true
					};
				});

			string connectionString = Configuration.GetConnectionString("LowCostHotelDefault");
			services.AddContext(connectionString);

			services.AddServices();
			services.AddMapper();

			services.AddControllers().AddNewtonsoftJson();

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowAnyOrigin();
				});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
