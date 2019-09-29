using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11.Entities.Assist
{
    public abstract class ChartViewer
    {
        public LiveCharts.WinForms.CartesianChart GetChart { get; set; }
        public LineSeries GetLineSeries { get; set; }

        virtual public void InitChart()
        {
            if (IsInitialize())
            {
                GetChart.AxisX.Clear();
                GetChart.AxisX.Add(new Axis
                {
                    IsEnabled = true,
                    ShowLabels = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                    },
                    Labels = new List<string>()
                });

                GetChart.AxisY.Clear();

                GetChart.AxisY.Add(new Axis
                {
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                    }
                });

                GetChart.Zoom = ZoomingOptions.X;

                GetChart.LegendLocation = LegendLocation.Top;
            }
        }

        public bool IsInitialize()
        {
            return GetChart.Series.Count == 0;
        }

        public void ClearSeries()
        {
            GetChart.Series.Clear();
        }

        public void ClearValues()
        {
            foreach (Series series in GetChart.Series)
            {
                series.Values.Clear();
            }
        }

        public void ClearValues(int i)
        {
            GetChart.Series[i].Values.Clear();
        }

        public void ClearSeries(int i)
        {
            GetChart.Series.Remove(GetChart.Series[i]);
        }

        public LineSeries AddSerie(string name)
        {
            LineSeries ser = new LineSeries()
            {
                Values = new ChartValues<float>(),
                PointGeometry = null,
                Fill = System.Windows.Media.Brushes.Transparent,
                StrokeThickness = 1.5,
                Title = name
            };

            return ser;
        }
    }
}
