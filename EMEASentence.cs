using System;

namespace GPSTracker
{
	// Spec at http://www.eoss.org/pubs/nmeafaq.htm
	public class EMEASentence
	{
		private Types sentenceType;
		private DateTime utcTime;
		private Latitude latitude;
		private Longitude longitude;
		private double speed;

		public enum Types
		{
			RMC,
			GSV,
			GSA,
			Unknown
		}

		public EMEASentence(string input)
		{
			string[] entries = input.Split(',');

			sentenceType = ParseSentenceType(entries[0]);

			if(Type == Types.RMC)
			{
				utcTime = ParseUTCTime(entries[1], entries[9]);
				latitude = new Latitude(entries[3], entries[4]);
				longitude = new Longitude(entries[5], entries[6]);
				
				try { speed = Double.Parse(entries[7]); }
				catch { speed = 0; }
			}
		}

		public Types Type
		{
			get { return sentenceType; }
		}

		public Coordinate Coordinate
		{
			get
			{
				return new Coordinate(latitude, longitude, speed, utcTime);
			}
		}
		
		private Types ParseSentenceType(string entryString)
		{
			if(entryString == null)
				return Types.Unknown;

			if(entryString.ToUpper().IndexOf("RMC") >= 0)
				return Types.RMC;
			else if(entryString.ToUpper().IndexOf("GSV") >= 0)
				return Types.GSV;
			else if(entryString.ToUpper().IndexOf("GSA") >= 0)
				return Types.GSA;
			else
				return Types.Unknown;
		}

		private DateTime ParseUTCTime(string inputTime, string inputDate)
		{
			try
			{
				string day = inputDate.Substring(0, 2);
				string month = inputDate.Substring(2, 2);
				string year = inputDate.Substring(4,2);
				string hour = inputTime.Substring(0, 2);
				string minute = inputTime.Substring(2, 2);
				string second = inputTime.Substring(4, 2);

				string combinedDate = 
						String.Format("{0}/{1}/{2} {3}:{4}:{5}",
							month, day, year, hour, minute, second);
				
				return DateTime.Parse(combinedDate);
			}
			catch { return DateTime.MinValue; }
		}
	}
}
