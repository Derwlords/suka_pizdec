using LowCostHotelMobile.ViewModels.Rooms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LowCostHotelMobile.Views.Rooms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomDetailPage : ContentPage
	{
		public RoomDetailPage()
		{
			InitializeComponent();
			BindingContext = new RoomDetailViewModel();
		}
	}
}