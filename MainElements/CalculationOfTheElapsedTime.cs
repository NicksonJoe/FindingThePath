using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BRIO_MRS_testTask
{
    class CalculationOfTheElapsedTime
    {
        private Radiorecievers _radiorecievers;
        private RadioTransmitter _radioTransmitter = new RadioTransmitter();
        private double radioTransmitterSpeed = 1000.0; // Скорость радиопередатчика
        private double kmToM = 1000.0; // Км в метры

        // Расчёт траектории между передатчиками
        public void TrajectoryСalculation(Radiorecievers radiorecievers, List<Time> signalsTime)
        {
            _radiorecievers = radiorecievers;
            _radioTransmitter.Times = signalsTime;

            foreach (var signalTime in _radioTransmitter.Times)
            {
                Junction(
                    GetDistance(signalTime.TimeToRadiorecieverAlfa), 
                    GetDistance(signalTime.TimeToRadiorecieverBeta), 
                    GetDistance(signalTime.TimeToRadiorecieverGamma));
            }

        }
        
        // Место соединения
        private bool Junction(double radiusAlfa, double radiusBeta, double radiusGamma)
        {
            double a, dx, dy, d, h, rx, ry;
            Point point, junctionPoint1, junctionPoint2;

            dx = _radiorecievers.Beta.location.X - _radiorecievers.Alfa.location.X;
            dy = _radiorecievers.Beta.location.Y - _radiorecievers.Alfa.location.Y;
            d = Math.Sqrt(dy * dy + dx * dx);

            if (d > (radiusAlfa + radiusBeta)) return false;
            if (d < Math.Abs(radiusAlfa - radiusBeta)) return false;

            // Расстояние между центром a и point
            a = ((radiusAlfa * radiusAlfa) - (radiusBeta * radiusBeta) + (d * d)) / (2.0 * d);
            point.X = _radiorecievers.Alfa.location.X + (dx * a / d);
            point.Y = _radiorecievers.Alfa.location.Y + (dy * a / d);

            // Расстояние от точки 2 до любой из точек пересечения 
            h = Math.Sqrt(radiusAlfa * radiusAlfa - a * a);

            // смещение от точки 2 до любой из точек пересечения
            rx = -dy * (h / d);
            ry = dx * (h / d);

            // Точки пересечения
            junctionPoint1.X = point.X + rx;
            junctionPoint1.Y = point.Y + ry;

            junctionPoint2.X = point.X - rx;
            junctionPoint2.Y = point.Y - ry;

            // Имеет ли пересечение 3 круг
            dx = junctionPoint1.X - _radiorecievers.Gamma.location.X;
            dy = junctionPoint1.Y - _radiorecievers.Gamma.location.Y;
            double d1 = Math.Sqrt((dy * dy) + (dx * dx));
            dx = junctionPoint2.X - _radiorecievers.Gamma.location.X;
            dy = junctionPoint2.Y - _radiorecievers.Gamma.location.Y;
            double d2 = Math.Sqrt((dy * dy) + (dx * dx));

            if (Math.Abs(d1 - radiusGamma) < 0.1 * radiusGamma)
                _radioTransmitter.Points.Add(new Point(Math.Round(junctionPoint1.X, 8), Math.Round(junctionPoint1.Y, 8)));
            if (Math.Abs(d2 - radiusGamma) < 0.1 * radiusGamma)
                _radioTransmitter.Points.Add(new Point(Math.Round(junctionPoint2.X, 8), Math.Round(junctionPoint2.Y, 8)));
            else
                return false;
            return false;
        }

        // Создание новых точек и расчёт сигналов
        public void AddRadioTransmitterPoint(Point point)
        {
            try
            {
                _radioTransmitter.Points.Add(point);

                var t1 = GetTime(point, _radiorecievers.Alfa.location);
                var t2 = GetTime(point, _radiorecievers.Beta.location);
                var t3 = GetTime(point, _radiorecievers.Gamma.location);
                
                _radioTransmitter.Times.Add(new Time(t1, t2, t3));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Не открыт файл Input");
            }

        }

        // Расчёт времени между радиоприёмниками в метрах
        private double GetDistance(double time)
        {
            // time время сигнала
            return time * radioTransmitterSpeed * kmToM;
        }

        // Расчёт времени для прохождения между точками
        private double GetTime(Point point1, Point point2)
        {
            var interval = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            return interval / (radioTransmitterSpeed * kmToM);
        }
        
        // Расчёт траектории радиопередатчика
        public List<Point> GetRadioTransmitterPoint()
        {
            if (_radioTransmitter.Points != null)
                return _radioTransmitter.Points;
            else
                MessageBox.Show("Пустые координаты для радиопередатчика");
            return null;
        }

        // Расчёт координат радиоприёмника
        public List<Point> GetRadiorecieversPoint()
        {
            return new List<Point> { _radiorecievers.Alfa.location, _radiorecievers.Beta.location, _radiorecievers.Gamma.location };
        }

        // Расчёт расположения и времени для каждого передатчика за время прохождении пути
        public (Radiorecievers radiorecievers, List<Time> times) GetLocationAndTime()
        {
            return (_radiorecievers, _radioTransmitter.Times);
        }
    }
}
