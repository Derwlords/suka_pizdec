using LowCostHotelMobile.Services;
using Xamarin.Forms;

namespace LowCostHotelMobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			DependencyService.Register<AuthService>();
			DependencyService.Register<UserService>();
			DependencyService.Register<RoomService>();
			DependencyService.Register<StatisticService>();

			MainPage = new AppShell();

			Shell.Current.GoToAsync("LoginPage");
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
