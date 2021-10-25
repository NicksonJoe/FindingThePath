namespace BRIO_MRS_testTask
{
	public class Radioreciever
	{
		internal Point location;

		public Radioreciever(Point point)
		{
			location = point;
		}
	}

	public struct Radiorecievers
	{
		public Radioreciever Alfa;
		public Radioreciever Beta;
		public Radioreciever Gamma;
	}
}