using LowCostHotelMobile.Models;
using LowCostHotelMobile.Views.Rooms;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LowCostHotelMobile.ViewModels.Rooms
{
	public class RoomsListViewModel : BaseViewModel
	{
		private Room selectedRoom;

		public ObservableCollection<Room> Rooms { get; }
		public Command LoadRoomsCommand { get; }
		public Command<Room> RoomTapped { get; }

		public RoomsListViewModel()
		{
			Rooms = new ObservableCollection<Room>();

			LoadRoomsCommand = new Command(async () => await ExecuteLoadRoomsCommand());

			RoomTapped = new Command<Room>(OnRoomSelected);
		}

		async Task ExecuteLoadRoomsCommand()
		{
			IsBusy = true;

			try
			{
				Rooms.Clear();
				var rooms = await RoomService.FindAllAsync();

				foreach (var room in rooms)
				{
					Rooms.Add(room);
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
			SelectedRoom = null;
		}

		public Room SelectedRoom
		{
			get => selectedRoom;
			set
			{
				SetProperty(ref selectedRoom, value);
				OnRoomSelected(value);
			}
		}

		async void OnRoomSelected(Room room)
		{
			if (room == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(RoomDetailPage)}?{nameof(RoomDetailViewModel.RoomId)}={room.Id}");
		}
	}
}
