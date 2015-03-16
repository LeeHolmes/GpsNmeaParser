using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GPSTracker
{
	/// <summary>
	/// Graphs your GPS journey
	/// </summary>
	public class GPSTracker : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private GPSGraph gpsGraph;

		public GPSTracker(string filename)
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if(filename.Length > 0)
				gpsGraph = new GPSGraph(filename);

			this.Paint += new PaintEventHandler(OnPaint);
		}

		public void OnPaint(Object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Pen p = new Pen(Color.Blue, 3);
			Brush b = new SolidBrush(Color.Red);

			if(gpsGraph != null)
			{
				double mapWidth = gpsGraph.MaxLongitude - gpsGraph.MinLongitude;
				double mapHeight = gpsGraph.MaxLatitude - gpsGraph.MinLatitude;


				Point last = new Point();

				foreach(Coordinate c in gpsGraph.Coordinates)
				{
					int x = (int) ((c.Longitude.ConvertToDouble - gpsGraph.MinLongitude) 
						/ mapWidth * (this.Width - 60)) + 30;
					int y = (int) ((c.Latitude.ConvertToDouble - gpsGraph.MinLatitude) 
						/ mapHeight * (this.Height - 60));

					// Flip y coord
					y = (this.Height - y) - 45;

					if(c.Speed < 1)
						g.FillEllipse(b, x - 2, y - 2, 5, 5);

					if(last.IsEmpty)
					{
						last = new Point(x, y);
					}
					else
					{
						Point now = new Point(x, y);
						g.DrawLine(p, last, now);
						last = now;
					}
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// GPSTracker
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(552, 430);
			this.Name = "GPSTracker";
			this.Text = "GPS Track Log Viewer";
			this.TransparencyKey = System.Drawing.SystemColors.ControlLightLight;

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			string filename = "";
			
			if((args.Length > 0) && (System.IO.File.Exists(args[0])))
				filename = args[0];

			Application.Run(new GPSTracker(filename));
		}
	}
}
