using System;
using GPSTracker;
using NUnit.Framework;

namespace GPSTrackerTest
{
	[TestFixture]
	public class LatitudeTester
	{
		Latitude lat;

		[SetUp]
		public void Setup()
		{
			lat = new Latitude("4740.2753", "N");
		}

		[Test]
		public void Degrees()
		{
			Assertion.AssertEquals(47, lat.Degrees);
		}

		[Test]
		public void Minutes()
		{
			Assertion.AssertEquals(40.2753, lat.Minutes);
		}

		[Test]
		public void ConvertToMinutes()
		{
			Assertion.AssertEquals(2860.2753, lat.ConvertToDouble);
		}

		[Test]
		public void Direction()
		{
			Assertion.AssertEquals(CoordinateElement.Directions.N, lat.Direction);
		}
	}
}
