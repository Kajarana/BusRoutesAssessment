using System;
using BusRoutes.Model;
using BusRoutes.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace BusRoutes.ViewModel
{
	public class RouteDetailsViewModel:ViewModelBase
	{
		string title;
		public string Title {
			get {
				return title;
			}
			set {
				title = value;
				Notify ();
			}
		}

		Route currentRoute;
		public Route CurrentRoute {
			get {
				return currentRoute;
			}
			set {
				currentRoute = value;
			}
		}

		ObservableCollection<Street> streets;
		public ObservableCollection<Street> Streets {
			get {
				return streets;
			}
			set {
				streets = value;
				Notify ();
			}
		}

		ObservableCollection<DepartureSummary> departureSummaries;
		public ObservableCollection<DepartureSummary> DepartureSummaries {
			get {
				return departureSummaries;
			}
			set {
				departureSummaries = value;
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

		public ObservableCollection<string> DepartureList{ get; set; }

		public RouteDetailsViewModel (Route route)
		{
			CurrentRoute = route;
			Title = string.Format ("{0} - {1}", route.ShortName, route.LongName);
			Populate ();
		}
		public async void Populate()
		{
			IsLoading = true;
			var service = new BusRouteService ();
			var resultDetails = await service.GetRouteDetailsByIdAsync (CurrentRoute.Id);
			CurrentRoute.Streets = resultDetails;
			Streets = new ObservableCollection<Street> (resultDetails);

			var resultDeparture = await service.GetDepartureByRouteIdAsync(CurrentRoute.Id);
			CurrentRoute.Departures = resultDeparture;
			var resultSummary = SummarizeDepartures (resultDeparture);
			DepartureSummaries = new ObservableCollection<DepartureSummary> (resultSummary);

			IsLoading = false;
		}

		private IList<DepartureSummary> SummarizeDepartures(IList<Departure> derpartures)
		{
			List<DepartureSummary> resultSummary = new List<DepartureSummary> ();
			foreach (var calendar in derpartures.Select(d=>d.DayType).Distinct()) {
				string times = "";
				foreach (var time in derpartures.Where(t=>t.DayType == calendar)) {
					times += time.TimeSpan + " ";
				}
				resultSummary.Add (new DepartureSummary (){ DayType = calendar, TimeSpans = times.Trim() });
			};
			return resultSummary;
		}
	}
		
}

