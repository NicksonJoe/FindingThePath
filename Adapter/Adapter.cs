using System;
using System.Collections.Generic;
using System.Text;

namespace BRIO_MRS_testTask
{
	internal class Adapter
	{
		public (Radiorecievers radiorecievers, List<Time> times) Parse(string input)
		{
			Radiorecievers radiorecievers;
			List<Time> times = new List<Time>();

			var coordinates = input.Split("\r\n,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			double[] coordinatesArray = new double[coordinates.Length];

			for (int i = 0; i < coordinates.Length; i++)
			{
				Double.TryParse(coordinates[i].ToString().Replace('.', ','), out coordinatesArray[i]);
			}

			radiorecievers.Alfa = new Radioreciever(new Point(coordinatesArray[0], coordinatesArray[1]));
			radiorecievers.Beta = new Radioreciever(new Point(coordinatesArray[2], coordinatesArray[3]));
			radiorecievers.Gamma = new Radioreciever(new Point(coordinatesArray[4], coordinatesArray[5]));

			for (int i = 6; i < coordinatesArray.Length - 2; i += 3)
			{
				Time time = new Time(coordinatesArray[i], coordinatesArray[i + 1], coordinatesArray[i + 2]);
				times.Add(time);
			}
			return (radiorecievers, times);
		}

		// Сохранение координат и времени
		public void SaveData(Radiorecievers radiorecievers, List<Time> times, string fileName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(
				$"{radiorecievers.Alfa.location.X.ToString()},{radiorecievers.Alfa.location.Y.ToString()}," +
				$"{radiorecievers.Beta.location.X.ToString()},{radiorecievers.Beta.location.Y.ToString()}," +
				$"{radiorecievers.Gamma.location.X.ToString()},{radiorecievers.Gamma.location.Y.ToString()}," + Environment.NewLine);

			foreach (var time in times)
			{
				stringBuilder.AppendFormat(
					$"{((decimal)time.TimeToRadiorecieverAlfa).ToString()}," +
					$"{((decimal)time.TimeToRadiorecieverBeta).ToString()}," +
					$"{((decimal)time.TimeToRadiorecieverGamma).ToString()}," + Environment.NewLine);
			}
			System.IO.File.WriteAllText(stringBuilder.ToString(), fileName);
		}

		// Сохранение траектории
		public void SaveData(List<Point> points, string fileName)
		{
			StringBuilder stringBuilder = new StringBuilder();

			foreach (var point in points)
				stringBuilder.AppendFormat($"{point.X.ToString()}, {point.Y.ToString()}," + Environment.NewLine);
			System.IO.File.WriteAllText(stringBuilder.ToString(), fileName);
		}
	}
}