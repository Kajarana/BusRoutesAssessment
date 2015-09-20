using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BusRoutes.Model;
using BusRoutes.ViewModel;

namespace BusRoutes.View
{
	public partial class RouteDetails : ContentPage
	{
		public RouteDetails (Route route)
		{
			InitializeComponent ();
			this.BindingContext = new RouteDetailsViewModel (route);
		}

		private void StreetListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			StreetListView.SelectedItem = null;
		}

		private void TimetableListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{			
			Navigation.PushAsync(new RouteDepartures(((RouteDetailsViewModel)this.BindingContext).CurrentRoute, (DepartureSummary)TimetableListView.SelectedItem ));
		}

		private void BusStopButton_OnClick(object sender, EventArgs e)
		{			
			StreetListView.IsVisible = !StreetListView.IsVisible;
		}

		private void TimetableButton_OnClick(object sender, EventArgs e)
		{			
			TimetableListView.IsVisible = !TimetableListView.IsVisible;
		}
	}
}

