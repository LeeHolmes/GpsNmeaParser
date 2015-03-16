using System;

namespace GPSTracker
{
	/// <summary>
	/// Holds information about a latitude, which is
	/// really just a coordinate
	/// </summary>
	public class Latitude : CoordinateElement
	{
		public Latitude(string numberValue, string direction) :	
			base(numberValue, direction) {}
	}
}
