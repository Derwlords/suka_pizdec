using LowCostHotelMobile.Views.Rooms;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LowCostHotelMobile.ViewModels
{
	public class UserViewModel : BaseViewModel
	{
		private string fullName;
		private string email;
		private string role;

		public int Id { get; set; }

		public string FullName
		{
			get => fullName;
			set => SetProperty(ref fullName, value);
		}

		public string Email
		{
			get => email;
			set => SetProperty(ref email, value);
		}

		public string Role
		{
			get => role;
			set => SetProperty(ref role, value);
		}

		public Command MoveToRoomsListCommand { get; }

		public UserViewModel()
		{
			MoveToRoomsListCommand = new Command(async () => await ExecuteMoveToRoomsListCommand());

			LoadUser();
		}

		private async Task ExecuteMoveToRoomsListCommand()
		{
			await Shell.Current.GoToAsync($"{nameof(RoomsListPage)}");
		}

		private async void LoadUser()
		{
			try
			{
				var user = await UserService.FindMyUserAsync();
				Id = user.Id;
				FullName = user.FullName;
				Email = user.Email;
				Role = user.Role;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
