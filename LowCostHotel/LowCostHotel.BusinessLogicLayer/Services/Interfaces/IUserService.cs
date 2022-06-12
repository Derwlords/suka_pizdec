using LowCostHotel.BusinessLogicLayer.Models.Shared;
using LowCostHotel.BusinessLogicLayer.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> FindByLoginAsync(Login login);

		Task<IEnumerable<UserDTO>> FindAllUsersAsync();

		Task<UserDTO> FindByIdAsync(int id);

		Task<UserDTO> FindByEmailAsync(string email);

		Task<UserDTO> CreateAsync(CreateUserDTO user);

		Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate);

		Task<UserDTO> DeleteAsync(int id);
	}
}
