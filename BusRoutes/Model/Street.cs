using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BusRoutes.Model
{
	public class Street
	{
		string name;
		public string Name {
			set {
				name = value;
			}
			get {
				return name;
			}
		}
		public Street ()
		{
		}
	}

	public class RootRouteDetails
	{
		[JsonProperty("rows")]
		public IList<Street> Streets { get; set; }
	}
}

