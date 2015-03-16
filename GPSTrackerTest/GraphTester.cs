using System;
using GPSTracker;
using NUnit.Framework;

namespace GPSTrackerTest
{
	/// <summary>
	/// Summary description for GraphTester.
	/// </summary>
	[TestFixture]
	public class GraphTester
	{
		GPSGraph gpsGraph;

		[SetUp]
		public void Setup()
		{
			gpsGraph = new GPSGraph(@"..\..\testData.gps");
		}

		[Test]
		public void CoordinateCount()
		{
			Assertion.Assert(gpsGraph.Coordinates.Count > 0);
		}

		[Test]
		public void ElementHasData()
		{
			Coordinate coord = (Coordinate) gpsGraph.Coordinates[1];
			Assertion.Assert(coord.Latitude.Degrees > 0);
		}

		[Test]
		public void MinLatitude()
		{
			Assertion.AssertEquals((47 * 60) + 38.6203, gpsGraph.MinLatitude);
		}

		[Test]
		public void MaxLatitude()
		{
			Assertion.AssertEquals((47 * 60) + 40.3147, gpsGraph.MaxLatitude);
		}

		[Test]
		public void MinLongitude()
		{
			Assertion.AssertEquals(-((122 * 60) + 8.2925), gpsGraph.MinLongitude);
		}

		[Test]
		public void MaxLongitude()
		{
			Assertion.AssertEquals(-((122 * 60) + 6.5158), gpsGraph.MaxLongitude);
		}

	}
}
