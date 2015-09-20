using System;
using System.Threading.Tasks;
using BusRoutes.Model;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;

namespace BusRoutes.Service
{
	public class BusRouteService
	{
		const string userName = "WKD4N7YMA1uiM8V";
		const string password = "DtdTtzMLQlA0hk2C1Yi5pLyVIlAQ68";
		HttpClient client;

		public BusRouteService ()
		{
			var authData = string.Format ("{0}:{1}", userName, password);
			var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));
			client = new System.Net.Http.HttpClient ();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authHeaderValue);
			client.DefaultRequestHeaders.Add ("X-AppGlu-Environment", "staging");
		}			
			
		public Task<IList<Route>> GetRoutesByStopNameAsync (string stopName) {
			return Task.Run (() => GetRoutesStopName (stopName));	
		}

		private async Task<IList<Route>> GetRoutesStopName (string stopName) {			
			//TODO: build a proper model class to be serialized
			//TODO: Error handling
			var json = "{ \"params\": {\"stopName\":\"%" + stopName + "%\"}}";
			var content = new StringContent (json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync (new Uri ("https://api.appglu.com/v1/queries/findRoutesByStopName/run"), content);

			if (response.IsSuccessStatusCode) {
				var responseContent = await response.Content.ReadAsStringAsync ();
				var jsonSerializerSettings = new JsonSerializerSettings();
				jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
				return (JsonConvert.DeserializeObject <RootRoute> (responseContent, jsonSerializerSettings)).Routes;
			}

			return null;
		}

		public Task<IList<Street>> GetRouteDetailsByIdAsync (int id) {
			return Task.Run (() => GetRouteDetailsById (id));	
		}

		private async Task<IList<Street>> GetRouteDetailsById (int id) {			
			//TODO: build a proper model class to be serialized
			var json = "{ \"params\": {\"routeId\":" + id + "}}";
			var content = new StringContent (json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync (new Uri ("https://api.appglu.com/v1/queries/findStopsByRouteId/run"), content);

			if (response.IsSuccessStatusCode) {
				var responseContent = await response.Content.ReadAsStringAsync ();
				var jsonSerializerSettings = new JsonSerializerSettings();
				jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
				return (JsonConvert.DeserializeObject <RootRouteDetails> (responseContent, jsonSerializerSettings)).Streets;
			}

			return null;

		}

		public Task<IList<Departure>> GetDepartureByRouteIdAsync (int id) {
			return Task.Run (() => GetDepartureByRouteId (id));	
		}

		private async Task<IList<Departure>> GetDepartureByRouteId (int id) {			
			//TODO: build a proper model class to be serialized
			var json = "{ \"params\": {\"routeId\":" + id + "}}";
			var content = new StringContent (json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync (new Uri ("https://api.appglu.com/v1/queries/findDeparturesByRouteId/run"), content);

			if (response.IsSuccessStatusCode) {
				var responseContent = await response.Content.ReadAsStringAsync ();
				var jsonSerializerSettings = new JsonSerializerSettings();
				jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
				return (JsonConvert.DeserializeObject <RootDeparture> (responseContent, jsonSerializerSettings)).Departures;
			}

			return null;

		}
	}
		
}

