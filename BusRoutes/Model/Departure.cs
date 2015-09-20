using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusRoutes.Model
{
	public class Departure
	{
		[JsonProperty("calendar")]
		public string DayType{ get; set;}

		[JsonProperty("time")]
		public string TimeSpan{ get; set;}

		public Departure ()
		{
		}
	}

	public class RootDeparture
	{
		[JsonProperty("rows")]
		public IList<Departure> Departures { get; set; }
	}
}

