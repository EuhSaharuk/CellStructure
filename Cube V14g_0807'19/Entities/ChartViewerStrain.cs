using Cube_V11.Entities.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cube_V11.Entities
{
    class ChartViewerStrain : ChartViewer
    {
        public List<List<TotalStrainModel>> TotalStrainModels { get; set; }

        public ChartViewerStrain(LiveCharts.WinForms.CartesianChart chart)
        {
            GetChart = chart;
            GetChart.Series.Clear();
        }

        public void FillingStrainChart(int id, int ser, string serName)
        {
            ClearValues(ser);

            foreach (TotalStrainModel totalStrain in TotalStrainModels[id])
            {
                switch (serName)
                {
                    case "XY":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.XY);
                            break;
                        }
                    case "XZ":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.XZ);
                            break;
                        }
                    case "YZ":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.YZ);
                            break;
                        }
                    case "ENERGY":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.ENERGY);
                            break;
                        }
                    case "ESTRN":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.ESTRN);
                            break;
                        }
                    case "SEDENS":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SEDENS);
                            break;
                        }
                    case "SX":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SX);
                            break;
                        }
                    case "SY":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SY);
                            break;
                        }
                    case "SZ":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.SZ);
                            break;
                        }
                    case "E1":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.E1);
                            break;
                        }
                    case "E2":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.E2);
                            break;
                        }
                    case "E3":
                        {
                            GetChart.Series[ser].Values.Add(totalStrain.E3);
                            break;
                        }
                    case "ID":
                        {
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

            if (end > TotalStrainModels[id].Count)
            {
                end = TotalStrainModels[id].Count;
            }

            for (int startP = start; startP < end; startP++)
            {
                switch (serName)
                {
                    case "XY":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].XY);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "XZ":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].XZ);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "YZ":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].YZ);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "ENERGY":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].ENERGY);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "ESTRN":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].ESTRN);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SEDENS":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].SEDENS);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SX":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].SX);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SY":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].SY);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "SZ":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].SZ);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "E1":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].E1);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "E2":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].E2);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                    case "E3":
                        {
                            GetChart.Series[ser].Values.Add(TotalStrainModels[id][startP].E3);
                            GetChart.AxisX[0].Labels.Add(TotalStrainModels[id][startP].NodeId.ToString());
                            break;
                        }
                }
            }
        }
    }
}
