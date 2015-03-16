using System;
using System.IO;
using System.Collections;

namespace GPSTracker
{
	/// <summary>
	/// Holds the data for a graph of GPS information.
	/// </summary>
	public class GPSGraph
	{
		private ArrayList coordinates;
		private double minLatitude;
		private double maxLatitude;
		private double minLongitude;
		private double maxLongitude;

		public GPSGraph(string filename)
		{
			minLatitude = Double.MaxValue;
			maxLatitude = Double.MinValue;
			minLongitude = Double.MaxValue;
			maxLongitude = Double.MinValue;
			coordinates = GetCoordinates(filename);
		}

		public ArrayList Coordinates
		{
			get { return coordinates; }
		}

		public double MinLatitude
		{
			get { return minLatitude; }
		}

		public double MaxLatitude
		{
			get { return maxLatitude; }
		}

		public double MinLongitude
		{
			get { return minLongitude; }
		}

		public double MaxLongitude
		{
			get { return maxLongitude; }
		}

		private ArrayList GetCoordinates(string filename)
		{
			ArrayList returnCoordinates = new ArrayList();
			string currentLine = "";

			TextReader tr = new StreamReader(filename);
			currentLine = tr.ReadLine();

			while(currentLine != null)
			{
				EMEASentence ems = new EMEASentence(currentLine);
				
				if(ems.Type == EMEASentence.Types.RMC)
				{
					returnCoordinates.Add(ems.Coordinate);
					if(ems.Coordinate.Latitude.ConvertToDouble < minLatitude)
						minLatitude = ems.Coordinate.Latitude.ConvertToDouble;
					if(ems.Coordinate.Latitude.ConvertToDouble > maxLatitude)
						maxLatitude = ems.Coordinate.Latitude.ConvertToDouble;
					if(ems.Coordinate.Longitude.ConvertToDouble < minLongitude)
						minLongitude = ems.Coordinate.Longitude.ConvertToDouble;
					if(ems.Coordinate.Longitude.ConvertToDouble > maxLongitude)
						maxLongitude = ems.Coordinate.Longitude.ConvertToDouble;
				}

				currentLine = tr.ReadLine();
			}

			tr.Close();
			return returnCoordinates;
		}
	}
}
