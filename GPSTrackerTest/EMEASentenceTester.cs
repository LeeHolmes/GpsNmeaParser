using System;
using GPSTracker;
using NUnit.Framework;

namespace GPSTrackerTest
{
	[TestFixture]
	public class EMEASentenceTester
	{
		EMEASentence gpsSentence;

		[SetUp]
		public void Setup()
		{
			string testData = "$GPRMC,022409.639,A,4740.2753,N,12206.9193,W,0.18,222.29,050403,,*13";
			gpsSentence = new EMEASentence(testData);
		}

		[Test]
		public void Type()
		{
			Assertion.AssertEquals(EMEASentence.Types.RMC, gpsSentence.Type);
		}

		[Test]
		public void UTCTime()
		{
			DateTime testDate = DateTime.Parse("April 05 2003, 02:24:09");
			Assertion.AssertEquals(testDate, gpsSentence.Coordinate.UTCTime);
		}

		[Test]
		public void Latitude()
		{
			Assertion.AssertEquals(40.2753, gpsSentence.Coordinate.Latitude.Minutes);
		}

		[Test]
		public void Longitude()
		{
			Assertion.AssertEquals(6.9193, gpsSentence.Coordinate.Longitude.Minutes);
		}

		[Test]
		public void Speed()
		{
			Assertion.AssertEquals(0.18, gpsSentence.Coordinate.Speed);
		}
	}
}
