using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusRoutes.Model
{
	public class Route
	{
		int id;

		[JsonProperty("id")]
		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		string shortName;
		[JsonProperty("shortName")]
		public string ShortName {
			get {
				return shortName;
			}
			set {
				shortName = value;
			}
		}

		string longName;
		[JsonProperty("longName")]
		public string LongName {
			get {
				return longName;
			}
			set {
				longName = value;
			}
		}

		IList<Street> streets;
		public IList<Street> Streets {
			get {
				return streets;
			}
			set {
				streets = value;
			}
		}

		IList<Departure> departures;
		public IList<Departure> Departures {
			get {
				return departures;
			}
			set {
				departures = value;
			}
		}

		public Route ()
		{
		}
	}

	public class RootRoute
	{
		[JsonProperty("rows")]
		public IList<Route> Routes { get; set; }
	}		
}

