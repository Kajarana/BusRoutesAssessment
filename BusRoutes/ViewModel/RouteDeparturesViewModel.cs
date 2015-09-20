using System;
using System.Collections.ObjectModel;
using BusRoutes.Model;
using BusRoutes.Service;
using System.Linq;
using System.Collections.Generic;

namespace BusRoutes.ViewModel
{
	public class RouteDeparturesViewModel:ViewModelBase
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

		ObservableCollection<Departure> departures;
		public ObservableCollection<Departure> Departures {
			get {
				return departures;
			}
			set {
				departures = value;
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

		public RouteDeparturesViewModel (Route route, DepartureSummary departureSummary)
		{			
			CurrentRoute = route;
			Title = string.Format ("Timetable - {0} - {1}", route.ShortName, departureSummary.DayType);
			if (departureSummary != null)
				Populate (departureSummary);			
		}

		public void Populate( DepartureSummary departureSummary)
		{
			IsLoading = true;
			//Don't need to load from service, get from memory :)
			var resultDeparture = CurrentRoute.Departures.Where(d=>d.DayType==departureSummary.DayType);
			Departures = new ObservableCollection<Departure> (resultDeparture);
			IsLoading = false;
		}
	}
}

