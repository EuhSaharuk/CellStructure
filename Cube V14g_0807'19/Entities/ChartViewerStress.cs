using Cube_V11.Entities.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11.Entities
{
    class ChartViewerStress : ChartViewer
    {
        public List<List<TotalStressModel>> TotalStressModels { get; set; }

        public ChartViewerStress(LiveCharts.WinForms.CartesianChart chart)
        {
            GetChart = chart;
            GetChart.Series.Clear();
        }

        public void FillingStressChart(int id, int ser, string serName)
        {
            ClearValues(ser);
            GetChart.AxisX[0].Labels.Clear();

            foreach (TotalStressModel totalStrain in TotalStressModels[id])
            {
                switch (serName)
                {
                    case "XY":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.XY);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "XZ":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.XZ);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "YZ":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.YZ);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "VON":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.VON);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "P1":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.P1);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "P2":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.P2);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "P3":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.P3);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "INT":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.INT);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "SX":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SX);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "SY":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SY);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                    case "SZ":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SZ);
                            GetChart.AxisX[0].Labels.Add(totalStrain.NodeId.ToString());
                            break;
                        }
                }
            }
        }

        public void FillingChartPart(int mass, int start, int id, int ser, string serName)
        {
            ClearValues(ser);
            GetChart.AxisX[0].Labels.Clear();

            int end = start + mass;

            if (end > TotalStressModels[id].Count)
            {
                end = TotalStressModels[id].Count;
            }

            for (int startP = start; startP < end; startP++)
            {
                switch (serName)
                {
                    case "XY":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].XY);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "XZ":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].XZ);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "YZ":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].YZ);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "VON":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].VON);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "P1":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].P1);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "P2":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].P2);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "P3":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].P3);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "INT":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].INT);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SX":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].SX);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SY":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].SY);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SZ":
                        {
                            GetChart.Series[ser].Values.Add(TotalStressModels[id][startP].SZ);
                            GetChart.AxisX[0].Labels.Add(TotalStressModels[id][startP].NodeId.ToString());
                            break;
                        }
                }
            }
        }
    }
}
