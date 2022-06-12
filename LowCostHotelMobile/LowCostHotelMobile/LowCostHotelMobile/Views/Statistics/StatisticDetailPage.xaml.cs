using LowCostHotelMobile.ViewModels.Statistics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LowCostHotelMobile.Views.Statistics
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticDetailPage : ContentPage
	{
		public StatisticDetailPage()
		{
			InitializeComponent();
			BindingContext = new StatisticDetailViewModel();
		}
	}
}