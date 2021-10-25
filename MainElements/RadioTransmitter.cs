using System.Collections.Generic;

namespace BRIO_MRS_testTask
{
	internal class RadioTransmitter
	{
		internal List<Time> Times { get; set; }
		internal List<Point> Points;

		public RadioTransmitter()
		{
			Times = new List<Time>();
			Points = new List<Point>();
		}
	}
}