using LowCostHotelMobile.Services.Interfaces;
using LowCostHotelMobile.Views;
using LowCostHotelMobile.Views.Rooms;
using LowCostHotelMobile.Views.Statistics;
using System;
using Xamarin.Forms;

namespace LowCostHotelMobile
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(RoomsListPage), typeof(RoomsListPage));
			Routing.RegisterRoute(nameof(RoomDetailPage), typeof(RoomDetailPage));

			Routing.RegisterRoute(nameof(StatisticsListPage), typeof(StatisticsListPage));
			Routing.RegisterRoute(nameof(StatisticDetailPage), typeof(StatisticDetailPage));

			Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
			Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			var authService = DependencyService.Get<IAuthService>();
			await authService.Logout();

			await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
		}
	}
}
