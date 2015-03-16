using System;
using System.Text.RegularExpressions;

namespace GPSTracker
{
	/// <summary>
	/// A world coordinate that contains
	/// degrees, minutes, and direction
	/// as parsed from GPS emea standards
	/// </summary>
	public class CoordinateElement
	{
		private int degrees;
		private double minutes;
		private Hemispheres hemisphere;

		public enum Hemispheres
		{
			N,
			S,
			E,
			W,
			Unknown
		}

		// EMEA input example: 
		// 12206.9192, W
		public CoordinateElement(string numberValue, string hemisphere)
		{
			Regex re = new Regex(@"(.*)(..)\.(.*)");
			Match m = re.Match(numberValue);

			try { degrees = Int32.Parse(m.Groups[1].Value); }
			catch { degrees = 0; }

			try { minutes = Double.Parse(m.Groups[2] + "." + m.Groups[3]); }
			catch { minutes = 0; }

			this.hemisphere = ParseHemisphere(hemisphere);
		}

		public int Degrees
		{
			get { return degrees; }
		}

		public double Minutes
		{
			get { return minutes; }
		}

		public Hemispheres Hemisphere
		{
			get { return hemisphere; }
		}

		public double ConvertToDouble
		{
			get 
			{
				double rawCoordinate = (60 * Degrees) + Minutes;
				if((Hemisphere == Hemispheres.S) ||
					(Hemisphere == Hemispheres.W))
					rawCoordinate *= -1;

				return rawCoordinate;
			}
		}

		public override string ToString()
		{
			string returnString = String.Format("{0}{1}'{2}\"",
				Hemisphere.ToString(), Degrees, Minutes);
			return returnString;
		}

		private Hemispheres ParseHemisphere(string direction)
		{
			switch(direction.ToUpper())
			{
				case "N" : return Hemispheres.N;
				case "S" : return Hemispheres.S;
				case "E" : return Hemispheres.E;
				case "W" : return Hemispheres.W;
				default: return Hemispheres.Unknown;
			}
		}
	}
}
