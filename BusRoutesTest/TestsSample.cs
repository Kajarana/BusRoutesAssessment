using System;
using NUnit.Framework;

namespace BusRoutesTest
{
	[TestFixture]
	public class TestsSample
	{
		
		[SetUp]
		public void Setup ()
		{
		}

		
		[TearDown]
		public void Tear ()
		{
		}

		[Test]
		public async void Pass ()
		{
			BusRoutes.Service.BusRouteService myService = new BusRoutes.Service.BusRouteService ();

			var result = await myService.GetRoutesAsync("");

			Assert.IsTrue (result.Count > 0);


		}
	}
}

