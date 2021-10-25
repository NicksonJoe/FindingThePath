namespace BRIO_MRS_testTask
{
	internal struct Time
	{
		internal double TimeToRadiorecieverAlfa, TimeToRadiorecieverBeta, TimeToRadiorecieverGamma;

		public Time(double RadiorecieverTimeAlfa, double RadiorecieverTimeBeta, double RadiorecieverTimeGamma)
		{
			TimeToRadiorecieverAlfa = RadiorecieverTimeAlfa;
			TimeToRadiorecieverBeta = RadiorecieverTimeBeta;
			TimeToRadiorecieverGamma = RadiorecieverTimeGamma;
		}
	}
}