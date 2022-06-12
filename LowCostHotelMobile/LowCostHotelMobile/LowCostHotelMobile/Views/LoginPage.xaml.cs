using LowCostHotelMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LowCostHotelMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			this.BindingContext = new LoginViewModel();
		}
	}
}