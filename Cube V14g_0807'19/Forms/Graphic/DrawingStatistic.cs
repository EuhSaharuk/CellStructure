using Cube_V11.Entities;
using Cube_V11.Entities.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube_V11.Forms
{
    public partial class DrawingStatistic : Form
    {
        public List<object[]> listStrain;
        public List<object[]> listStress;
        private List<object[]> listNode;

        public int indexStress = 0;
        public int indexStrain = 0;

        public int Mass { get; set; }

        List<List<TotalStrainModel>> totalStrainModels = new List<List<TotalStrainModel>>();
        List<List<TotalStressModel>> totalStressModels = new List<List<TotalStressModel>>();

        public DataGridView data1;
        public DataGridView data2;

        ChartViewerStrain view1;
        ChartViewerStress view2;

        List<SeriesClass> seriesStrainClasses = new List<SeriesClass>();
        List<SeriesClass> seriesStressClasses = new List<SeriesClass>();

        List<CheckBox> checkBoxes = new List<CheckBox>();
        string fileName = "Setup.ini";

        public DrawingStatistic(List<object[]> stress, List<object[]> strain, List<object[]> node)
        {
            InitializeComponent();

            data1 = dataGridView1;
            data2 = dataGridView2;

            Mass = 50;

            listStrain = strain;
            listStress = stress;
            listNode = node;
            
            FillingStressList();
            FillingStrainList();

            if (!File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(File.Create(fileName));
                sr.Close();
            }

            FillingCheckList();

            button5.Visible = false;
            button6.Visible = false;

            tabControl1.Visible = false;

            if (listNode != null && listStrain != null && listStress != null)
            {
                button1_Click_1(this, EventArgs.Empty);

                textBox3.Text = Mass.ToString();
                textBox5.Text = Mass.ToString();
            }
        }

        private void FillingCheckList()
        {
            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
            checkBoxes.Add(checkBox4);
            checkBoxes.Add(checkBox5);
            checkBoxes.Add(checkBox6);
            checkBoxes.Add(checkBox7);
            checkBoxes.Add(checkBox8);
            checkBoxes.Add(checkBox9);
            checkBoxes.Add(checkBox10);
            checkBoxes.Add(checkBox11);
            checkBoxes.Add(checkBox12);
            checkBoxes.Add(checkBox13);
            checkBoxes.Add(checkBox14);
            checkBoxes.Add(checkBox15);
            checkBoxes.Add(checkBox16);
            checkBoxes.Add(checkBox17);
            checkBoxes.Add(checkBox18);
            checkBoxes.Add(checkBox19);
            checkBoxes.Add(checkBox20);
            checkBoxes.Add(checkBox21);
            checkBoxes.Add(checkBox22);
            checkBoxes.Add(checkBox23);
        }

        private void FillingStressList()
        {
            foreach (var obj in listStress)
            {
                FillingTotalStressList(obj);
            }
        }

        private void FillingStrainList()
        {
            foreach (var obj in listStrain)
            {
                FillingTotalStrainList(obj);
            }
        }

        private void FillingTotalStressList(object[] obj)
        {
            int i;

            List<TotalStressModel> stressList = new List<TotalStressModel>();
            for (i = 0; i < obj.Length; i += 12)
            {
                stressList.Add(new TotalStressModel
                {
                    NodeId = (int)obj[i],
                    SX = (float)obj[i + 1],
                    SY = (float)obj[i + 2],
                    SZ = (float)obj[i + 3],
                    XY = (float)obj[i + 4],
                    XZ = (float)obj[i + 5],
                    YZ = (float)obj[i + 6],
                    P1 = (float)obj[i + 7],
                    P2 = (float)obj[i + 8],
                    P3 = (float)obj[i + 9],
                    VON = (float)obj[i + 10],
                    INT = (float)obj[i + 11]
                });
            }

            totalStressModels.Add(stressList);
        }

        private void FillingTotalStrainList(object[] obj)
        {
            int i;

            List<TotalStrainModel> strainList = new List<TotalStrainModel>();
            for (i = 0; i < obj.Length; i += 13)
            {
                strainList.Add(new TotalStrainModel
                {
                    NodeId = (int)obj[i],
                    SX = (float)obj[i + 1],
                    SY = (float)obj[i + 2],
                    SZ = (float)obj[i + 3],
                    XY = (float)obj[i + 4],
                    XZ = (float)obj[i + 5],
                    YZ = (float)obj[i + 6],
                    ESTRN = (float)obj[i + 7],
                    SEDENS = (float)obj[i + 8],
                    ENERGY = (float)obj[i + 9],
                    E1 = (float)obj[i + 10],
                    E2 = (float)obj[i + 11],
                    E3 = (float)obj[i + 12]
                });
            }

            totalStrainModels.Add(strainList);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SwitchForm();
        }

        private void SwitchForm()
        {            
            button1.Visible = false;
            
            button5.Visible = true;
            button6.Visible = true;

            tabControl1.Visible = true;

            label1.Text = String.Format("Исследование №{0}", indexStrain);
            label2.Text = String.Format("Исследование №{0}", indexStress);
            
            view1 = new ChartViewerStrain(cartesianChart1);
            view1.InitChart();

            view2 = new ChartViewerStress(cartesianChart2);
            view2.InitChart();

            view1.TotalStrainModels = totalStrainModels;
            view2.TotalStressModels = totalStressModels;

            data1.DataSource = totalStrainModels[indexStrain];
            data2.DataSource = totalStressModels[indexStress];

            hScrollBar1.Maximum = (int)Math.Ceiling((double)view1.TotalStrainModels[indexStrain].Count / Mass) + 8;
            hScrollBar2.Maximum = (int)Math.Ceiling((double)view2.TotalStressModels[indexStress].Count / Mass) + 8;

            SetupCheckBox();
        }

        private void SetupCheckBox()
        {
            int id;
            StreamReader sr = new StreamReader(File.OpenRead(fileName));
           
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                if(Int32.TryParse(s, out id))
                {
                    checkBoxes[id].Checked = true;
                }
            }

            sr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                indexStrain++;

                if (indexStrain == totalStrainModels.Count)
                {
                    indexStrain = 0;
                }

                if (hScrollBar1.Value == 0)
                {
                    DrawingStrain();
                }
                else
                {
                    hScrollBar1.Value = 0;
                }

                label1.Text = String.Format("Исследование №{0}", indexStrain);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                indexStress++;

                if (indexStress == totalStressModels.Count)
                {
                    indexStress = 0;
                }
                
                if (hScrollBar2.Value == 0)
                {
                    DrawingStress();
                }
                else
                {
                    hScrollBar2.Value = 0;
                }

                label2.Text = String.Format("Исследование №{0}", indexStress);
            }

            hScrollBar1.Maximum = (int)Math.Ceiling((double)view1.TotalStrainModels[indexStrain].Count / Mass) + 8;
            hScrollBar2.Maximum = (int)Math.Ceiling((double)view2.TotalStressModels[indexStress].Count / Mass) + 8;
            data1.DataSource = totalStrainModels[indexStrain];
            data2.DataSource = totalStressModels[indexStress];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                indexStrain--;

                if (indexStrain < 0)
                {
                    indexStrain = totalStrainModels.Count - 1;
                }


                if (hScrollBar1.Value == 0)
                {
                    DrawingStrain();
                }
                else
                {
                    hScrollBar1.Value = 0;
                }

                label1.Text = String.Format("Исследование №{0}", indexStrain);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                indexStress--;

                if (indexStress < 0)
                {
                    indexStress = totalStressModels.Count - 1;
                }


                if (hScrollBar2.Value == 0)
                {
                    DrawingStress();
                }
                else
                {
                    hScrollBar2.Value = 0;
                }

                label2.Text = String.Format("Исследование №{0}", indexStress);
            }

            hScrollBar1.Maximum = (int)Math.Ceiling((double)view1.TotalStrainModels[indexStrain].Count / Mass) + 8;
            hScrollBar2.Maximum = (int)Math.Ceiling((double)view2.TotalStressModels[indexStress].Count / Mass) + 8;
            data1.DataSource = totalStrainModels[indexStrain];
            data2.DataSource = totalStressModels[indexStress];
        }

        private void hScrollBar1_OnValueChange(object sender, EventArgs e)
        {
            DrawingStrain();
        }

        private void hScrollBar2_OnValueChange(object sender, EventArgs e)
        {
            DrawingStress();
        }

        private List<Node> FillingNodeList(int index)
        {
            List<Node> nodes = new List<Node>();

            for (int i = 0; i < listNode[index].Length; i += 4)
            {
                nodes.Add(new Node
                {
                    Id = (int)listNode[index][i],
                    X = (float)listNode[index][i + 1],
                    Y = (float)listNode[index][i + 2],
                    Z = (float)listNode[index][i + 3]
                });
            }

            return nodes;
        }

        private int FindArr(int i)
        {
            int prev = 0, next, index = 0;

            bool flag = true;

            while (flag)
            {
                next = prev + Mass;
                if (prev <= i &&  i <= next)
                {
                    flag = false;
                }
                else
                {
                    index++;
                }
                prev = next;
            }

            return index;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int min, max, i, mass;

            if (textBox3.Text != Mass.ToString())
            {
                if (Int32.TryParse(textBox3.Text, out mass) && textBox3.Text != "")
                {
                    if (10 > mass || mass > 200)
                    {
                        MessageBox.Show("Масштаб должен быть от 10 до 200");
                        return;
                    }
                    Mass = mass;

                    hScrollBar1.Maximum = (int)Math.Ceiling((double)view1.TotalStrainModels[indexStrain].Count / Mass) + 8;
                    hScrollBar2.Maximum = (int)Math.Ceiling((double)view2.TotalStressModels[indexStress].Count / Mass) + 8;

                    hScrollBar1.Value = 0;

                    DrawingStrain();

                    textBox3.Text = Mass.ToString();
                    textBox5.Text = Mass.ToString();
                }
                else if (textBox3.Text == "")
                {
                    Mass = totalStrainModels[indexStrain].Capacity;
                    DrawingStrain();
                }
                else
                {
                    MessageBox.Show("Масштаб должен быть числом");
                    return;
                }
            }

            if (Int32.TryParse(textBox4.Text, out i) && textBox4.Text != "")
            {
                if (i < 1 || i > totalStrainModels[indexStrain].Count)
                {
                    MessageBox.Show("Узел не может быть отрицательным и превышать количество точек");
                    return;
                }
                hScrollBar1.Value = FindArr(i);
                FindInTab(i);
            }
            else if (textBox4.Text == "")
            {
                return;
            }
            else
            {
                MessageBox.Show("Узел должен быть числом");
                return;
            }

            if (Int32.TryParse(textBox7.Text, out min) && textBox7.Text != "")
            {
                if (i < 1 || i > totalStrainModels[indexStrain].Count - Mass)
                {
                    MessageBox.Show("Минимальное значение не может быть отрицательным и превышать количество точек");
                    return;
                }
            }
            else if (textBox7.Text == "")
            {

                return;
            }
            else
            {
                MessageBox.Show("Значение должено быть числом");
                return;
            }

            if (Int32.TryParse(textBox8.Text, out min) && textBox8.Text != "")
            {
                if (i < 1 || i > totalStrainModels[indexStrain].Count)
                {
                    MessageBox.Show("Максимальное значение не может быть отрицательным и превышать количество точек");
                    return;
                }
            }
            else if (textBox8.Text == "")
            {

                return;
            }
            else
            {
                MessageBox.Show("Значение должено быть числом");
                return;
            }


        }

        private void FindInTab(int val)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                data1.CurrentCell = data1.Rows[val - 1].Cells[0];
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                data2.CurrentCell = data2.Rows[val - 1].Cells[0];
            }
        }

        private int FindSeriesStrainID(string serT)
        {
            int i;

            for (i = 0; i < seriesStrainClasses.Count; i++)
            {
                if (seriesStrainClasses[i].Title.Equals(serT))
                {
                    return i;
                }
            }

            return -1;
        }

        private void AddRemSeriesStrain(CheckBox checkBox ,string title)
        {
            if (!checkBox.Checked)
            {
                view1.ClearSeries(FindSeriesStrainID(title));
                seriesStrainClasses.Remove(seriesStrainClasses[FindSeriesStrainID(title)]);
            }
            else
            {
                seriesStrainClasses.Add(new SeriesClass(title));
                view1.GetChart.Series.Add(view1.AddSerie(title));
                int start = Mass * hScrollBar1.Value;
                view1.FillingChartPart(Mass, start, indexStrain, FindSeriesStrainID(title), title);
            }
        }

        private void AddRemSeriesStress(CheckBox checkBox, string title)
        {
            if (!checkBox.Checked)
            {
                view2.ClearSeries(FindSeriesStressID(title));
                seriesStressClasses.Remove(seriesStressClasses[FindSeriesStressID(title)]);
            }
            else
            {
                seriesStressClasses.Add(new SeriesClass(title));
                view2.GetChart.Series.Add(view2.AddSerie(title));
                int start = Mass * hScrollBar2.Value;
                view2.FillingChartPart(Mass, start, indexStress, FindSeriesStressID(title), title);
            }
        }

        private int FindSeriesStressID(string serT)
        {
            int i;

            for (i = 0; i < seriesStressClasses.Count; i++)
            {
                if (seriesStressClasses[i].Title.Equals(serT))
                {
                    return i;
                }
            }

            return -1;
        }

        private void DrawingStrain()
        {
            if (checkBox12.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("SX"), "SX");
            }
            if (checkBox13.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("SY"), "SY");
            }
            if (checkBox14.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("SZ"), "SZ");
            }
            if (checkBox15.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("XY"), "XY");
            }
            if (checkBox16.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("XZ"), "XZ");
            }
            if (checkBox17.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("YZ"), "YZ");
            }
            if (checkBox18.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("ESTRN"), "ESTRN");
            }
            if (checkBox19.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("SEDENS"), "SEDENS");
            }
            if (checkBox20.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("ENERGY"), "ENERGY");
            }
            if (checkBox21.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("E1"), "E1");
            }
            if (checkBox22.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("E2"), "E2");
            }
            if (checkBox23.Checked)
            {
                view1.FillingChartPart(Mass, Mass * hScrollBar1.Value, indexStrain, FindSeriesStrainID("E3"), "E3");
            }
        }

        private void DrawingStress()
        {
            if (checkBox1.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("SX"), "SX");
            }
            if (checkBox2.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("SY"), "SY");
            }
            if (checkBox3.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("SZ"), "SZ");
            }
            if (checkBox4.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("XY"), "XY");
            }
            if (checkBox5.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("XZ"), "XZ");
            }
            if (checkBox6.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("YZ"), "YZ");
            }
            if (checkBox7.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("P1"), "P1");
            }
            if (checkBox8.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("P2"), "P2");
            }
            if (checkBox9.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("P3"), "P3");
            }
            if (checkBox10.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("VON"), "VON");
            }
            if (checkBox11.Checked)
            {
                view2.FillingChartPart(Mass, Mass * hScrollBar2.Value, indexStress, FindSeriesStressID("INT"), "INT");
            }
        }

       
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox12, "SX");
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox13, "SY");
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox14, "SZ");
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox15, "XY");
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox16, "XZ");
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox17, "YZ");
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox18, "ESTRN");
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox19, "SEDENS");
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox20, "ENERGY");
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox21, "E1");
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox22, "E2");
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStrain(checkBox23, "E3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i, mass;

            if (textBox5.Text != Mass.ToString())
            {
                if (Int32.TryParse(textBox5.Text, out mass) && textBox5.Text != "")
                {
                    if (10 > mass || mass > 200)
                    {
                        MessageBox.Show("Масштаб должен быть от 10 до 200");
                        return;
                    }
                    Mass = mass;

                    hScrollBar1.Maximum = (int)Math.Ceiling((double)view1.TotalStrainModels[indexStrain].Count / Mass) + 8;
                    hScrollBar2.Maximum = (int)Math.Ceiling((double)view2.TotalStressModels[indexStress].Count / Mass) + 8;

                    textBox3.Text = Mass.ToString();
                    textBox5.Text = Mass.ToString();

                    DrawingStress();

                    hScrollBar2.Value = 0;
                }
                else if (textBox5.Text == "")
                {
                    Mass = totalStressModels[indexStress].Capacity;
                    DrawingStress();
                }
                else
                {
                    MessageBox.Show("Масштаб должен быть числом");
                    return;
                }
            }

            if (Int32.TryParse(textBox6.Text, out i) && textBox6.Text != "")
            {
                if (1 > i || i > totalStressModels[indexStress].Count)
                {
                    MessageBox.Show("Узел не может быть отрицательным и превышать количество точек");
                    return;
                }
                hScrollBar2.Value = FindArr(i);
                FindInTab(i);
            }
            else if (textBox6.Text == "")
            {
                return;
            }
            else
            {
                MessageBox.Show("Точка должена быть числом");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox1, "SX");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox2, "SY");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox3, "SZ");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox4, "XY");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox5, "XZ");
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox6, "YZ");
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox7, "P1");
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox8, "P2");
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox9, "P3");
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox10, "VON");
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            AddRemSeriesStress(checkBox11, "INT");
        }

        private void DrawingStatistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkBoxes.Clear();
            FillingCheckList();
            StreamWriter sw = new StreamWriter(File.OpenWrite(fileName));

            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    sw.WriteLine(i);
                }
            }

            sw.Close();
        }
    }
}
