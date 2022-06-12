using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LowCostHotelMobile.ViewModels.Statistics
{
	[QueryProperty(nameof(StatisticId), nameof(StatisticId))]
	public class StatisticDetailViewModel : BaseViewModel
	{
		private int statisticId;
		private string userName;
		private string hostelRoom;
		private double pricePerDay;
		private string resourceName;
		private double resourcePricePerHour;
		private string start;
		private string end;
		private double profit;

		public int Id { get; set; }

		public string UserName
		{
			get => userName;
			set => SetProperty(ref userName, value);
		}

		public string HostelRoom
		{
			get => hostelRoom;
			set => SetProperty(ref hostelRoom, value);
		}

		public double PricePerDay
		{
			get => pricePerDay;
			set => SetProperty(ref pricePerDay, value);
		}

		public string ResourceName
		{
			get => resourceName;
			set => SetProperty(ref resourceName, value);
		}

		public double ResourcePricePerHour
		{
			get => resourcePricePerHour;
			set => SetProperty(ref resourcePricePerHour, value);
		}

		public string Start
		{
			get => start;
			set => SetProperty(ref start, value);
		}

		public string End
		{
			get => end;
			set => SetProperty(ref end, value);
		}

		public double Profit
		{
			get => profit;
			set => SetProperty(ref profit, value);
		}

		public int StatisticId
		{
			get
			{
				return statisticId;
			}
			set
			{
				statisticId = value;
				LoadStatisticId(value);
			}
		}

		public async void LoadStatisticId(int statisticId)
		{
			try
			{
				var statistic = await StatisticService.FindByIdAsync(statisticId);
				Id = statistic.Id;
				UserName = statistic.UserName;
				HostelRoom = statistic.HostelRoom;
				PricePerDay = statistic.PricePerDay;
				ResourceName = statistic.ResourceName;
				ResourcePricePerHour = statistic.ResourcePricePerHour;
				Start = statistic.Start.ToLongDateString();
				End = statistic.End.ToLongDateString();
				Profit = statistic.Profit;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
