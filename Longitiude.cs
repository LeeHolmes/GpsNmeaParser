using System;

namespace GPSTracker
{
	/// <summary>
	/// Holds information about a latitude, which is
	/// really just a coordinate
	/// </summary>
	public class Longitude : CoordinateElement
	{
		public Longitude(string numberValue, string direction) :	
			base(numberValue, direction) {}
	}
}
