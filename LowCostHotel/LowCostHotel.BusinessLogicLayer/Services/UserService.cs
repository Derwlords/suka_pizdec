using AutoMapper;
using LowCostHotel.BusinessLogicLayer.Integrations;
using LowCostHotel.BusinessLogicLayer.Models.Shared;
using LowCostHotel.BusinessLogicLayer.Models.User;
using LowCostHotel.BusinessLogicLayer.Services.Interfaces;
using LowCostHotel.DataAccessLayer.Models;
using LowCostHotel.DataAccessLayer.Repositories.Interfaces;
using LowCostHotel.DataAccessLayer.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCostHotel.BusinessLogicLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _users;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_users = unitOfWork.Users;
			_mapper = mapper;
		}

		public async Task<UserDTO> CreateAsync(CreateUserDTO user)
		{
			var mapped = _mapper.Map<User>(user);
			mapped.Email = mapped.Email.ToLower();
			mapped.HashedPassword = Hash.CreateMD5(user.Password);

			var result = await _users.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			return _mapper.Map<UserDTO>(result);
		}

		public async Task<UserDTO> DeleteAsync(int id)
		{
			var user = await _users.GetByIdAsync(id);
			if (user != null)
			{
				var deleted = await _users.DeleteAsync(user);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<UserDTO>(user);
			}

			return null;
		}

		public async Task<IEnumerable<UserDTO>> FindAllUsersAsync()
		{
			var users = await _users.GetAllAsync();
			return _mapper.Map<IEnumerable<UserDTO>>(users);
		}

		public async Task<UserDTO> FindByEmailAsync(string email)
		{
			email = email.ToLower();
			var users = await _users.GetAllAsync();
			var user = users.FirstOrDefault(u => u.Email == email);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> FindByIdAsync(int id)
		{
			var user = await _users.GetByIdAsync(id);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> FindByLoginAsync(Login login)
		{
			var users = await _users.GetAllAsync();
			string passwordHash = Hash.CreateMD5(login.Password);
			login.Email = login.Email.ToLower();

			var user = users.FirstOrDefault(u => u.Email == login.Email &&
				u.HashedPassword == passwordHash);

			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> UpdateAsync(UpdateUserDTO userToUpdate)
		{
			var user = await _users.GetByIdAsync(userToUpdate.Id);
			user = _mapper.Map(userToUpdate, user);

			user.Email = user.Email.ToLower();
			user.HashedPassword = Hash.CreateMD5(userToUpdate.Password);

			var updated = await _users.UpdateAsync(user);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<UserDTO>(updated);
		}
	}
}
