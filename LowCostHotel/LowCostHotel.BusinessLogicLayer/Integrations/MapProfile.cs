using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Models.HotelRoom;
using LowCostHotel.BusinessLogicLayer.Models.Recidence;
using LowCostHotel.BusinessLogicLayer.Models.Resource;
using LowCostHotel.BusinessLogicLayer.Models.Statistic;
using LowCostHotel.BusinessLogicLayer.Models.User;
using LowCostHotel.DataAccessLayer.Models;

namespace LowCostHotel.BusinessLogicLayer.Integrations
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			//user
			CreateMap<User, UserDTO>();
			CreateMap<CreateUserDTO, User>();
			CreateMap<UpdateUserDTO, User>();

			//HotelRoom
			CreateMap<HotelRoom, HotelRoomDTO>();
			CreateMap<CreateHotelRoomDTO, HotelRoom>();
			CreateMap<UpdateHotelRoomDTO, HotelRoom>();

			//residence
			CreateMap<Residence, ResidenceDTO>();
			CreateMap<CreateResidenceDTO, Residence>();
			CreateMap<UpdateResidenceDTO, Residence>();

			//resources
			CreateMap<Resource, ResourceDTO>();
			CreateMap<CreateResourceDTO, Resource>();
			CreateMap<UpdateResourceDTO, Resource>();

			//statistics
			CreateMap<Statistic, StatisticDTO>();
		}
	}
}
