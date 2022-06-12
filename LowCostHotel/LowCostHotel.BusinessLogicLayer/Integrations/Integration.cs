using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Services;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using LowCostHotel.DataAccessLayer.EF;
using LowCostHotel.DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LowCostHotel.BusinessLogicLayer.Integrations
{
	public static class Integration
	{
		public static void AddContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<LowCostHotelContext>(options =>
				options.UseSqlServer(connectionString),
				ServiceLifetime.Transient);
		}

		public static void AddMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile(new MapProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IResidenceService, ResidenceService>();
			services.AddScoped<IResourceService, ResourceService>();
			services.AddScoped<IHotelRoomService, HotelRoomService>();
			services.AddScoped<IStatisticService, StatisticService>();
		}
	}
}
