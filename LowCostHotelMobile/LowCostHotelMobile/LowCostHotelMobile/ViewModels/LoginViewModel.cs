using LowCostHotelMobile.Models;
using System;
using Xamarin.Forms;

namespace LowCostHotelMobile.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		private string email = "user2@gmail.com";
		private string password = "useruser2";
		private string error = "";

		public string Email
		{
			get => email;
			set => SetProperty(ref email, value);
		}

		public string Password
		{
			get => password;
			set => SetProperty(ref password, value);
		}
		public string Error
		{
			get => error;
			set => SetProperty(ref error, value);
		}

		public Command LoginCommand { get; }

		public LoginViewModel()
		{
			LoginCommand = new Command(OnLoginClicked, Validate);
		}

		private bool Validate()
		{
			return !String.IsNullOrWhiteSpace(email)
				&& !String.IsNullOrWhiteSpace(password);
		}

		private async void OnLoginClicked()
		{
			Login login = new Login
			{
				Email = email,
				Password = password
			};

			bool result = await AuthService.LoginAsync(login);

			if (result)
			{
				await Shell.Current.GoToAsync("..");
			}
			else
			{
				Error = "Error email or password!";
			}
		}
	}
}
