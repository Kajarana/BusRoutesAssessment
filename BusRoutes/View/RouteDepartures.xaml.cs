using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BusRoutes.ViewModel;
using BusRoutes.Model;

namespace BusRoutes.View
{
	public partial class RouteDepartures : ContentPage
	{
		public RouteDepartures (Route route, DepartureSummary departure)
		{
			InitializeComponent ();
			this.BindingContext = new RouteDeparturesViewModel (route, departure);
		}


	}
}

