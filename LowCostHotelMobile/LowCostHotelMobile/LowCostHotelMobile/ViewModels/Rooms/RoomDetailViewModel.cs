using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LowCostHotelMobile.ViewModels.Rooms
{
	[QueryProperty(nameof(RoomId), nameof(RoomId))]
	public class RoomDetailViewModel : BaseViewModel
	{
		private int roomId;
		private string name;
		private int numberOfRooms;
		private string address;
		private double pricePerDay;

		public int Id { get; set; }

		public string Name
		{
			get => name;
			set => SetProperty(ref name, value);
		}

		public int NumberOfRooms
		{
			get => numberOfRooms;
			set => SetProperty(ref numberOfRooms, value);
		}

		public string Address
		{
			get => address;
			set => SetProperty(ref address, value);
		}

		public double PricePerDay
		{
			get => pricePerDay;
			set => SetProperty(ref pricePerDay, value);
		}

		public int RoomId
		{
			get
			{
				return roomId;
			}
			set
			{
				roomId = value;
				LoadRoomId(value);
			}
		}

		public async void LoadRoomId(int roomId)
		{
			try
			{
				var room = await RoomService.FindByIdAsync(roomId);
				Id = room.Id;
				Name = room.Name;
				NumberOfRooms = room.NumberOfRooms;
				Address = room.Address;
				PricePerDay = room.PricePerDay;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}
