using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using BRIO_MRS_testTask.Controls;

namespace BRIO_MRS_testTask
{
    public partial class RadioTransmitterDetectionSystem : Form
    {
        private Adapter _adapter;
        private readonly CalculationOfTheElapsedTime _calc = new CalculationOfTheElapsedTime();

        #region default values for coordinate system
            private int PosX = 10;
            private int PosY = 10;
            private int NegX = -10;
            private int NegY = -10;
            private int dX, dY;
            private int X0, Y0;
            private int arrowSize = 5;
        #endregion

        public RadioTransmitterDetectionSystem()
        {
            InitializeComponent();
            SecondHandlers();
        }

        // Default Handlers
        private void SecondHandlers()
        {
            #region Hanlders
            this.SetSizeBtn.Click += new System.EventHandler(this.buttonSetSize_Click);
            this.SetDefaultValuesBtn.Click += new System.EventHandler(this.buttonSetDefault_Click);
            this.UploadCoordinateBtn.Click += new System.EventHandler(this.UploadCoordinateBtnFromFile_Click);
            this.SaveCoordinateBtn.Click += new System.EventHandler(this.SaveCoordinateBtnToFile_Click);
            this.CoordinateSystemPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CoordinateSystemPanel_Paint);
            this.CoordinateSystemPanel.Resize += new System.EventHandler(this.CoordinateSystemPanel_Resize);
            this.SetRadioTransmitterLocationBtn.Click += new System.EventHandler(this.SetRadiotransmitterLocationBtn_Click);
            #endregion

            #region Text
            SetPosXtB.Text = PosX.ToString();
            SetPosYtB.Text = PosY.ToString();
            SetNegXtB.Text = NegX.ToString();
            SetNegYtB.Text = NegY.ToString();
            #endregion

            #region FileDialog
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            #endregion
        }
        // Set defaults values in coordinate system
        private void buttonSetDefault_Click(object sender, EventArgs e)
        {
            try
            {
                SetPosXtB.Text = "10";
                SetPosYtB.Text = "10";
                SetNegXtB.Text = "-10";
                SetNegYtB.Text = "-10";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Значения сброшены. \nНеобходимо установить размер");
        }

        private void buttonSetSize_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(SetPosXtB.Text, out PosX)) MessageBox.Show("Некорректное значение X max");
            if (!int.TryParse(SetPosYtB.Text, out PosY)) MessageBox.Show("Некорректное значение Y max");
            if (!int.TryParse(SetNegXtB.Text, out NegX)) MessageBox.Show("Некорректное значение X min");
            if (!int.TryParse(SetNegYtB.Text, out NegY)) MessageBox.Show("Некорректное значение Y min");

            CoordinateSystemPanel.Refresh();
        }

        private string fileName;
        private string fileText;
        // Загрузка координат и размещение их на системе координат
        private void UploadCoordinateBtnFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                fileName = openFileDialog1.FileName;
                fileText = File.ReadAllText(fileName);
                
                _adapter = new Adapter();
                var fileData = _adapter.Parse(fileText);
                _calc.TrajectoryСalculation(fileData.radiorecievers, fileData.times);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetRadioLocation_Click();
        }
        // Сохранение в файл информации о местоположении
        private void SaveCoordinateBtnToFile_Click(object sender, EventArgs e)
        {
            SaveAs formSaveAs = new SaveAs();
            formSaveAs.ShowDialog();
        }

        private void SetRadioLocation_Click()
        {
            CoordinateSystemPanel.Controls.Clear();

            var radiorecieverPoints = _calc.GetRadiorecieversPoint();
            foreach (var rp in radiorecieverPoints)
            {
                var radiorecieverContol = new RadiorecieverControl();
                //CoordinateSystemPanel.Controls.Add(radiorecieverContol);
                radiorecieverContol.Location = new System.Drawing.Point(CoordX(rp.X), CoordY(rp.Y));
                CoordinateSystemPanel.Controls.Add(radiorecieverContol);

            }

            var radiotransmitterPoints = _calc.GetRadioTransmitterPoint();
            foreach (var rt in radiotransmitterPoints)
            {
                var radiotransmitterContol = new RadioTransmitterControl();
                //CoordinateSystemPanel.Controls.Add(radiotransmitterContol);
                radiotransmitterContol.Location = new System.Drawing.Point(CoordX(rt.X), CoordY(rt.Y));
                CoordinateSystemPanel.Controls.Add(radiotransmitterContol);
            }
        }

        public int CoordX(double coord) { return (int)(Math.Round(coord, 1) * 10) + 558/2; }
        public int CoordY(double coord) { return (int)(Math.Round(coord, 1) * -10) + 491/2; }

        private void SetRadiotransmitterLocationBtn_Click(object sender, EventArgs e)
         {
            double x = 0.0, y = 0.0;
            var coordTrans = double.TryParse(SetTransmitterX1tB.Text, out x) && double.TryParse(SetTransmitterY1tB.Text, out y);
            
            if (coordTrans)
            {
                _calc.AddRadioTransmitterPoint(new Point(x, y));
                SetRadioLocation_Click();
            }
            else MessageBox.Show("Некорректное значение координат!");
        }

        // Draw coordinate system
        private void CoordinateSystemPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                dX = CoordinateSystemPanel.Width / (PosX - NegX);
                dY = CoordinateSystemPanel.Height / (PosY - NegY);
                X0 = -dX * NegX;
                Y0 = dY * PosY;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Vertical grid
            for (int x = NegX; x <= PosX; x++)
            {
                e.Graphics.DrawLine(Pens.LightGray, X0 + x * dX, 0, X0 + x * dX, CoordinateSystemPanel.Height);
            }
            // Horizontal grid
            for (int y = NegY; y <= PosY; y++)
            {
                e.Graphics.DrawLine(Pens.LightGray, 0, Y0 - y * dY, CoordinateSystemPanel.Width, Y0 - y * dY);
            }

            // Abscissa axis
            e.Graphics.DrawLine(Pens.Black, 0, Y0, CoordinateSystemPanel.Width, Y0);
            // Y-axis
            e.Graphics.DrawLine(Pens.Black, X0, 0, X0, CoordinateSystemPanel.Height);

            // Arrows
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(CoordinateSystemPanel.Width, Y0), new PointF(CoordinateSystemPanel.Width - arrowSize, Y0 - arrowSize), new PointF(CoordinateSystemPanel.Width - arrowSize, Y0 + arrowSize) });
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(X0, 0), new PointF(X0 - arrowSize, arrowSize), new PointF(X0 + arrowSize, arrowSize) });

            // Sgnatues (X, Y)
            Font f = new Font("Arial", 12);
            e.Graphics.DrawString("Y", f, Brushes.Black, X0 + 10, 0);
            e.Graphics.DrawString("X", f, Brushes.Black, CoordinateSystemPanel.Width - 25, Y0 + 10);
        }

        // Change Size
        private void CoordinateSystemPanel_Resize(object sender, EventArgs e)
        {
            CoordinateSystemPanel.Refresh();
        }
    }
}
