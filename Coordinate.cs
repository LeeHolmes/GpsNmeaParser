using System;

namespace GPSTracker
{
	/// <summary>
	/// Summary description for Coordinate.
	/// </summary>
	public class Coordinate
	{
		private Latitude latitude;
		private Longitude longitude;
		private double speed;
		private DateTime utcTime;

		public Coordinate(Latitude latitude, Longitude longitude,
			double speed, DateTime utcTime)
		{
			this.latitude = latitude;
			this.longitude = longitude;
			this.speed = speed;
			this.utcTime = utcTime;
		}

		public Latitude Latitude
		{
			get { return latitude; }
		}

		public Longitude Longitude
		{
			get { return longitude; }
		}

		public double Speed
		{
			get { return speed; }
		}

		public DateTime UTCTime
		{
			get { return utcTime; }
		}
	}
}
