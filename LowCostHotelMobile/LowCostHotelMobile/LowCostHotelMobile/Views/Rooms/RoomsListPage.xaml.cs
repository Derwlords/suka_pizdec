using LowCostHotelMobile.ViewModels.Rooms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LowCostHotelMobile.Views.Rooms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomsListPage : ContentPage
	{
		RoomsListViewModel viewModel;

		public RoomsListPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new RoomsListViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OnAppearing();
		}
	}
}