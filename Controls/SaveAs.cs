using System;
using System.Windows.Forms;

namespace BRIO_MRS_testTask.Controls
{
	public partial class SaveAs : Form
	{
		private readonly CalculationOfTheElapsedTime _calc = new CalculationOfTheElapsedTime();
		private Adapter _adapter;

		public SaveAs()
		{
			InitializeComponent();

			saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		}

		private string fileName;

		private void InputSaveBtn_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				fileName = saveFileDialog1.FileName;
				var data = _calc.GetLocationAndTime();
				_adapter.SaveData(data.radiorecievers, data.times, fileName);
			}
		}

		private void OutputSaveBtn_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				fileName = saveFileDialog1.FileName;
				var data = _calc.GetLocationAndTime();
				_adapter.SaveData(_calc.GetRadioTransmitterPoint(), fileName);
			}
		}
	}
}