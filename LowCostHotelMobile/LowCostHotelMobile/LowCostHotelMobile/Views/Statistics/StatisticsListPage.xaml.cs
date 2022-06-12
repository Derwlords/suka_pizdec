using LowCostHotelMobile.ViewModels.Statistics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LowCostHotelMobile.Views.Statistics
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticsListPage : ContentPage
	{
		StatisticsListViewModel viewModel;

		public StatisticsListPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new StatisticsListViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OnAppearing();
		}
	}
}