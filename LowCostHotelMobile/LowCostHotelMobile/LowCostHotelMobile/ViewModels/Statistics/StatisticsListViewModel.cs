using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using LowCostHotelMobile.Models;
using LowCostHotelMobile.Views.Statistics;
using Xamarin.Forms;

namespace LowCostHotelMobile.ViewModels.Statistics
{
	public class StatisticsListViewModel : BaseViewModel
	{
		private Statistic selectedStatistic;

		public ObservableCollection<Statistic> Statistics { get; }
		public Command LoadStatisticsCommand { get; }
		public Command<Statistic> StatisticTapped { get; }

		public StatisticsListViewModel()
		{
			Statistics = new ObservableCollection<Statistic>();

			LoadStatisticsCommand = new Command(async () => await ExecuteLoadStatisticsCommand());

			StatisticTapped = new Command<Statistic>(OnStatisticSelected);
		}

		async Task ExecuteLoadStatisticsCommand()
		{
			IsBusy = true;

			try
			{
				Statistics.Clear();
				var statistics = await StatisticService.FindAllAsync();

				foreach (var statistic in statistics)
				{
					Statistics.Add(statistic);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public void OnAppearing()
		{
			IsBusy = true;
			SelectedStatistic = null;
		}

		public Statistic SelectedStatistic
		{
			get => selectedStatistic;
			set
			{
				SetProperty(ref selectedStatistic, value);
				OnStatisticSelected(value);
			}
		}

		async void OnStatisticSelected(Statistic statistic)
		{
			if (statistic == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(StatisticDetailPage)}?{nameof(StatisticDetailViewModel.StatisticId)}={statistic.Id}");
		}
	}
}
