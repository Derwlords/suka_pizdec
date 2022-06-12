using System;

namespace LowCostHotel.BusinessLogicLayer.Models.Statistic
{
	public class StatisticDTO
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string HostelRoom { get; set; }

		public double PricePerDay { get; set; }

		public string ResourceName { get; set; }

		public double ResourcePricePerHour { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public double Profit { get; set; }
	}
}
