using LowCostHotelMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LowCostHotelMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPage : ContentPage
	{
		public UserPage()
		{
			InitializeComponent();
			BindingContext = new UserViewModel();
		}
	}
}