using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BusRoutes.ViewModel;
using BusRoutes.Model;

namespace BusRoutes.View
{
	public partial class ListRoutes : ContentPage
	{
		public ListRoutes ()
		{
			InitializeComponent ();
			this.BindingContext = new ListRouteViewModel ();
		}

		private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Navigation.PushAsync(new RouteDetails((Route) RoutesListView.SelectedItem));
		}
	}
}

