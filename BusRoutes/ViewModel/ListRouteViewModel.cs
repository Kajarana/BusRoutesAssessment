using System;
using System.Collections.ObjectModel;
using BusRoutes.Model;
using BusRoutes.Service;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusRoutes.ViewModel
{
	public class ListRouteViewModel : ViewModelBase
	{
		ObservableCollection<Route> routes;
		public ObservableCollection<Route> Routes {
			get {
				return routes;
			}
			set {
				routes = value;
				Notify ();
			}
		}
		bool isLoading;
		public bool IsLoading {
			get {
				return isLoading;
			}
			set {
				isLoading = value;
				Notify ();
			}
		}

		public ListRouteViewModel ()
		{		
			this.SearchCommand = new Command (Search);
		}

		string street;
		public string Street {
			get {
				return street;
			}
			set {
				street = value;
			}
		}

		ICommand searchCommand;
		public ICommand SearchCommand {
			get {
				return searchCommand;
			}
			set {
				searchCommand = value;
			}
		}

		public async void Populate(string stopName)
		{
			IsLoading = true;
			var service = new BusRouteService ();
			var result = await service.GetRoutesByStopNameAsync (stopName);		

			Routes = new ObservableCollection<Route> (result);
			IsLoading = false;
		}

		public void Search()
		{			
			Populate (this.Street);
		}
	}
}

