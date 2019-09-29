using Cube_V11.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube_V11
{
    public partial class Form2 : Form
    {
        Research research;
        AbstractAngle cells;
        AbstractNAngleDrawer cellsDraw;

        CircleCellsDrawer circleDrawer;
        TriangleCellsDrawer triangleDrawer;
        RectangleCellsDrawer rectDrawer;

        List<object[]> stressLists = new List<object[]>();
        List<object[]> strainLists = new List<object[]>();
        List<object[]> nodeList;

        List<object[]> action;
        int accuracy;

        bool fix = false;
        bool att = false;

        public Form2()
        {
            InitializeComponent();
            fixRadioButton4_CheckedChanged(null, null);
            button4.Enabled = false;
            statusStrip1.Visible = false;
            CreateResearch();

            bodyPartsComboBox.SelectedIndex = 0;
            acceptButton4_Click(this, EventArgs.Empty);

            strenghtRadioButton4.Checked = true;
            textBox13.Text = "2000";
            bodyPartsComboBox.SelectedIndex = 2;
            acceptButton4_Click(this, EventArgs.Empty);
        }

        ////////////////// Создание исследования //////////////////
        private void CreateResearch()
        {
            if (FreeClass.sldManager == null)
            {
                MessageBox.Show("Ошибка: SolidWorks не был подключен");
                return;
            }

            if (FreeClass.bodyDrawer == null)
            {
                MessageBox.Show("Ошибка: тело не было создано");
                return;
            }

            try
            {
                research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
                //research.CreateStudy();
            }
            catch
            {
                MessageBox.Show("Ошибка: модуль исследования не подключен");
                return;
            }
            textBox1.Text = Research.el.ToString();
            textBox2.Text = Research.tl.ToString();

            bodyPartsComboBox.Items.Clear();
            action = new List<object[]>();

            for (int i = 0; i < FreeClass.bodyDrawer.GetFacesArray().Length; i++)
            {
                bodyPartsComboBox.Items.Add(String.Join(", ", FreeClass.bodyDrawer.GetFacesArray().GetValue(i).ToString()));
            }

            groupBox1.Visible = true;
            statusStrip1.Visible = true;
            toolStripStatusLabel1.Text = "Исследование №  ";

            textBox1.Text = Research.el.ToString();
            textBox2.Text = Research.tl.ToString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (FreeClass.sldManager == null)
            {
                MessageBox.Show("Ошибка: SolidWorks не был подключен");
                return;
            }

            if (FreeClass.bodyDrawer == null)
            {
                MessageBox.Show("Ошибка: тело не было создано");
                return;
            }

            try
            {
                research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
                //research.CreateStudy();
            }
            catch
            {
                MessageBox.Show("Ошибка: модуль исследования не подключен");
                return;
            }
            textBox1.Text = Research.el.ToString();
            textBox2.Text = Research.tl.ToString();

            bodyPartsComboBox.Items.Clear();
            action = new List<object[]>();

            for (int i = 0; i < FreeClass.bodyDrawer.GetFacesArray().Length; i++)
            {
                bodyPartsComboBox.Items.Add(String.Join(", ", FreeClass.bodyDrawer.GetFacesArray().GetValue(i).ToString()));
            }

            groupBox1.Visible = true;
            statusStrip1.Visible = true;
            toolStripStatusLabel1.Text = "Исследование №  ";

            textBox1.Text = Research.el.ToString();
            textBox2.Text = Research.tl.ToString();

        }
        ////////////////// Конец создания исследования //////////////////

        ////////////////// Наложение действий //////////////////
        private void bodyPartsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (research == null)
            {
                research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            }
            research.BodyParts_Select(bodyPartsComboBox.SelectedIndex);
        }

        private void acceptButton4_Click(object sender, EventArgs e)
        {
            if (research == null) {
                research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            }

            research.BodyParts_Select(bodyPartsComboBox.SelectedIndex);

            if (fixRadioButton4.Checked)
            {
                object[] buff = new object[3];
                buff[0] = "fix"; //действие
                buff[1] = bodyPartsComboBox.SelectedIndex; //сторона
                buff[2] = null; //сила

                logTextBox.Text += "Сторона " + bodyPartsComboBox.SelectedIndex.ToString() +
                    " будет зафиксирована" + Environment.NewLine;
                action.Add(buff);

                fix = true;
            }
            else
            {
                object[] buff = new object[3];
                buff[0] = "force"; //действие
                buff[1] = bodyPartsComboBox.SelectedIndex; //сторона
                buff[2] = Convert.ToDouble(textBox13.Text); //сила

                logTextBox.Text += "На сторону " + bodyPartsComboBox.SelectedIndex.ToString() +
                    " будет приложена " + textBox13.Text + " сила";
                logTextBox.Text += Environment.NewLine;

                action.Add(buff);

                att = true;
            }

            if (fix && att)
            {
                startResearch4.Enabled = true;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            action.Remove(action.Last());
            logTextBox.Clear();

            foreach (object[] act in action)
            {
                if (act[0].Equals("fix"))
                {
                    logTextBox.Text += "Сторона " + act[1].ToString() + " будет зафиксирована";
                    logTextBox.Text += Environment.NewLine;
                    fix = false;
                }
                else if (act[0].Equals("force"))
                {
                    logTextBox.Text += "На сторону " + act[1] + " будет приложена " + act[2].ToString() + " сила";
                    logTextBox.Text += Environment.NewLine;
                    att = false;
                }
            }
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
            if (action != null)
            {
                foreach (object[] act in action)
                {
                    if (act[0].Equals("fix"))
                    {
                        logTextBox.Text += "Сторона " + act[1].ToString() +
                    " будет зафиксирована";
                        logTextBox.Text += Environment.NewLine;
                    }
                    else if (act[0].Equals("force"))
                    {
                        logTextBox.Text += "На сторону " + act[1].ToString() +
                    " будет приложена " + act[2].ToString() + " сила";
                        logTextBox.Text += Environment.NewLine;
                    }
                }

                startResearch4.Enabled = false;
            }
        }

        private void clearAllActions_Click(object sender, EventArgs e)
        {
            action = null; action = new List<object[]>();
            fix = false;
            att = false;
            startResearch4.Enabled = false;
            logTextBox.Clear();
        }
        ////////////////// Конец наложения действий //////////////////

        ////////////////// Исследование //////////////////
        private void startResearch4_Click(object sender, EventArgs e)
        {
            NAngleEmprovedForm owner;
            try { owner = (NAngleEmprovedForm)this.Owner; }
            catch { MessageBox.Show("Ошибка получения матеинской формы"); return; }

            // Проверка, приложена ли на тело сила и закреплено тело
            string actions_Check = Check_Actions();
            if(actions_Check != "") { MessageBox.Show(actions_Check); return; }

            FreeClass.sldManager.swModel.ClearSelection2(true);

            try { FreeClass.cells.deleteCells(); }
            catch { }

            if (!owner.CheckLoop()) {
                MessageBox.Show("Ошибка: На материнской форме не выбрана функция циклического построения");
                return;
            }

            dataGridView1.RowCount = 1;
            
            int start, end, step;

            start = Convert.ToInt16(owner.GetStartPoint());
            end = Convert.ToInt16(owner.GetEndPoint());
            step = Convert.ToInt16(owner.GetStep());

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = end + 1;

            toolStripStatusLabel1.Text = String.Format("Исследование №{0}", stressLists.Count);
            toolStripProgressBar1.Increment(1);

            withoutIterationResearch(); // 0-вая итерация

            // размер матрицы
            // количество углов
            // изменение объёма
            // изменение угла наклона

            try
            {
                if (start > end && step < 0)
                {
                    for (int i = start; i >= end; i = i + step)
                    {
                        loopAngleNum(i, owner);
                    }
                }
                else if (start <= end && step > 0)
                {
                    for (int i = start; i <= end; i = i + step)
                    {
                        loopAngleNum(i, owner);
                    }
                }
                else if (step == 0)
                {
                    loopAngleNum(start, owner);
                }
                else { MessageBox.Show("Неверно указаны данные по заданию степени матрицы"); }
            }
            catch (ApplicationException) { MessageBox.Show("Выполнение было остановленно"); }
            catch (Exception){ MessageBox.Show("Ошибка в задании одного из набора параметров"); }

            toolStripStatusLabel1.Text = "Готово";
            button4.Enabled = true;

            //nodeList = research.nodeLists;
        }

        /// <summary>
        /// Цикл по изменению количества углов
        /// </summary>
        /// <param name="matrixGrade">Степень матрицы</param>
        private void loopAngleNum(int matrixGrade, NAngleEmprovedForm owner)
        {
            int angleStart = owner.getAngleStart();
            int angeEnd = owner.getAngleEnd();
            int angleStep = owner.getAngleStep();

            /*cells = new NAngleCells(FreeClass.body);
            cells.SetColumnsNumber(matrixGrade);
            cells.SetRowsNumber(matrixGrade);*/

            if (angleStart > angeEnd && angleStep < 0)
            {
                for (int i = angleStart; i >= angeEnd; i = i + angleStep)
                {
                    if (i == 2) {
                        cells = new CircleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else if (i == 3) {
                        cells = new TriangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else if (i == 4) {
                        cells = new RectangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else {
                        cells = new NAngleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                        cells.SetAnglesN(i);
                    }
                    loopVolume(owner);
                }
            }
            else if (angleStart <= angeEnd && angleStep > 0)
            {
                for (int i = angleStart; i <= angeEnd; i = i + angleStep) {
                    if (i == 2) {
                        cells = new CircleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else if (i == 3) {
                        cells = new TriangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else if (i == 4) {
                        cells = new RectangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else {
                        cells = new NAngleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                        cells.SetAnglesN(i);
                    }
                    loopVolume(owner);
                }
            }
            else if (angleStep == 0) {
                if (angleStart == 2) {
                    cells = new CircleCells(FreeClass.body);
                    cells.SetColumnsNumber(matrixGrade);
                    cells.SetRowsNumber(matrixGrade);
                } else if (angleStart == 3) {
                    cells = new TriangleCells(FreeClass.body);
                    cells.SetColumnsNumber(matrixGrade);
                    cells.SetRowsNumber(matrixGrade);
                } else if (angleStart == 4) {
                    cells = new RectangleCells(FreeClass.body);
                    cells.SetColumnsNumber(matrixGrade);
                    cells.SetRowsNumber(matrixGrade);
                } else {
                    cells = new NAngleCells(FreeClass.body);
                    cells.SetColumnsNumber(matrixGrade);
                    cells.SetRowsNumber(matrixGrade);
                    cells.SetAnglesN(angleStart);
                } 
                loopVolume(owner); }
            else { throw new Exception(); }
            //ApplicationException
        }

        private void loopVolume(NAngleEmprovedForm owner) {
            double volumeStart = owner.getvolumeStart();
            double volumeEnd = owner.getvolumeEnd();
            double volumeStep = owner.getvolumeStep();

            if (volumeStart > volumeEnd && volumeStep < 0)
            {
                for (double i = volumeStart; i >= volumeEnd; i = i + volumeStep)
                {
                    cells.SetCellsV((FreeClass.body.GetV() * i) / 100);
                    loopDifflection(owner);
                }
            }
            else if (volumeStart <= volumeEnd && volumeStep > 0)
            {
                for (double i = volumeStart; i <= volumeEnd; i = i + volumeStep)
                {
                    cells.SetCellsV((FreeClass.body.GetV() * i) / 100);
                    loopDifflection(owner);
                }
            }
            else if (volumeStep == 0)
            {
                cells.SetCellsV((FreeClass.body.GetV() * volumeStart) / 100);
                loopDifflection(owner);
            }
            else { throw new Exception(); }
        }

        private void loopDifflection(NAngleEmprovedForm owner)
        {
            if (owner.getAngleStart() == 2 || owner.getAngleStart() == 3 || owner.getAngleStart() == 4 ||
                owner.getAngleEnd() == 2 || owner.getAngleEnd() == 3 || owner.getAngleEnd() == 4)
            {
                if (cells is CircleCells)
                {
                    circleDrawer = new CircleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, 0);
                }
                if (cells is RectangleCells)
                {
                    rectDrawer = new RectangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                }
                else if (cells is TriangleCells)
                {
                    triangleDrawer = new TriangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                }
                else
                {
                    cellsDraw = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, 0);
                }

                calculation(owner);
            }
            else
            {

                double DeflectionStart = owner.getDeflectionStart();
                double DeflectionEnd = owner.getDeflectionEnd();
                double DeflectionStep = owner.getDeflectionStep();

                if (DeflectionStart > DeflectionEnd && DeflectionStep < 0)
                {
                    for (double i = DeflectionStart; i >= DeflectionEnd; i = i + DeflectionStep)
                    {
                        cellsDraw = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, i);
                        //cells.SetCellsV((FreeClass.body.GetV() * i) / 100);
                        calculation(owner);
                    }
                }
                else if (DeflectionStart <= DeflectionEnd && DeflectionStep > 0)
                {
                    for (double i = DeflectionStart; i <= DeflectionEnd; i = i + DeflectionStep)
                    {
                        cellsDraw = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, i);
                        //cells.SetCellsV((FreeClass.body.GetV() * i) / 100);
                        calculation(owner);
                    }
                }
                else if (DeflectionStep == 0)
                {
                    cellsDraw = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, DeflectionStart);
                    //cells.SetCellsV((FreeClass.body.GetV() * DeflectionStart) / 100);
                    calculation(owner);
                }
                else { throw new Exception(); }
                //angle
                //calculation(owner);
            }
        }

        private void calculation(NAngleEmprovedForm owner)
        {
            dataGridView1.RowCount = dataGridView1.RowCount+1;
            accuracy = Convert.ToInt16(owner.GetAccuracy());

            cells.SetCellsHeight(owner.GetHeight());
            cells.SetAccuracy(accuracy);
            cells.Calculation();

            if (!cells.isAvailable())
            {
                string reason = "Степень - " + (dataGridView1.RowCount-1) + " " + writeResults();
                DialogResult dialogResult = MessageBox.Show("Не было найдено решение для условий - " + reason +
                    Environment.NewLine + "Попробовать следущий шаг? (В противном случае, вычисления будут приостановлены)",
                    "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) { return; }
                else if (dialogResult == DialogResult.No) { throw new ApplicationException(); }
            }

            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = cells.GetRowsNumber() * cells.GetColumnsNumber(); // количество ячеек

            try { ResearchActions(); }
            catch (Exception)
            {
                MessageBox.Show("Невозможно построить сетку");
                return;
            }

            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[3].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value) -
                 Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value); // Напряжение
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value) * 100 /
                Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value);  // %

            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value) -
                Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value); // Деформация
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[6].Value = Convert.ToDouble(dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value) * 100 /
                Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value); // %
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[7].Value = cells.GetAnglesN(); // Количество углов

            if (owner.getAngleStart() == 3 || owner.getAngleStart() == 4 ||
                owner.getAngleEnd() == 3 || owner.getAngleEnd() == 4) {
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[8].Value = 0; // Угол отклонения
            } else {
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[8].Value = cellsDraw.GetDifflection(); // Угол отклонения
            }

            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[9].Value = 
                (cells.GetCellsV() * 100) / FreeClass.body.GetV(); // Часть от объёма
        }

        private void ResearchActions()
        {
            double stress, displacement;

            toolStripStatusLabel1.Text = String.Format("Исследование №{0}", stressLists.Count);
            toolStripProgressBar1.Increment(1);

            if (cells is CircleCells)
            {
                circleDrawer.SetCells((CircleCells)cells);
                FreeClass.cells = circleDrawer; circleDrawer.drawCells();
            }
            else if (cells is RectangleCells) {
                rectDrawer.SetCells((RectangleCells)cells);
                FreeClass.cells = rectDrawer; rectDrawer.drawCells();
            } else if (cells is TriangleCells) {
                triangleDrawer.SetCells((TriangleCells)cells);
                FreeClass.cells = triangleDrawer; triangleDrawer.drawCells();
            }
            else
            { cellsDraw.SetCells((AbstractRelationAngle)cells);
                FreeClass.cells = cellsDraw;
                cellsDraw.drawCells();
            }

            while (true)
            {
                //создаём исследование
                research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
                research.CreateStudy();

                //прикладываем силы или фиксируем грани
                foreach (object[] act in action)
                {
                    if (act[0].Equals("fix"))
                    {
                        research.BodyParts_Select((int)act[1]);
                        research.FixFace();
                    }
                    else if (act[0].Equals("force"))
                    {
                        research.BodyParts_Select((int)act[1]);
                        research.CreateLoad((double)act[2]);
                    }
                }

                //research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
                //research.CreateStudy();

                research.webDensity = Convert.ToDouble(textBox1.Text);
                research.tlCurrent = Convert.ToDouble(textBox2.Text);
                research.CreateMesh();

                research.MaterialSet();
                research.RunAnalysis();
                
                nodeList = research.nodeLists;

                stress = research.GetStress();
                displacement = research.GetDisplacement();

                if (stress != Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value))
                {
                    break;
                }
                else
                {
                    research.deleteStudy(); research = null;
                    FreeClass.sldManager.swModel.ClearSelection2(true);
                    textBox1.Text = (Convert.ToDouble(textBox1.Text) / 2).ToString();
                    textBox2.Text = (Convert.ToDouble(textBox2.Text) / 2).ToString();
                }
            }

            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = stress; // Деформация
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value = displacement; // Смещение

            logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Итерация: " + (dataGridView1.RowCount-1).ToString(); logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Напряжение(ksi): " + stress.ToString(); logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Смещение(mk): " + displacement.ToString(); logTextBox.Text += Environment.NewLine;

            // задержка
            //Thread.Sleep(2500);

            textBox1.Text = research.webDensity.ToString();
            textBox2.Text = research.tlCurrent.ToString();

            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[10].Value = research.webDensity; // плотность сетки
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[11].Value = research.tlCurrent; // tl

            //statusStrip1.pro
            FillingStressStrainMass();

            // Очищаем
            research.deleteStudy();
            research = null;
            FreeClass.sldManager.swModel.ClearSelection2(true);

            FreeClass.cells.deleteCells();
        }

        private void withoutIterationResearch()
        {
            //создаём исследование
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();
            research.webDensity = Convert.ToDouble(textBox1.Text);
            research.tlCurrent = Convert.ToDouble(textBox2.Text);
            //прикладываем силы или фиксируем грани
            foreach (object[] act in action)
            {
                if (act[0].Equals("fix"))
                {
                    research.BodyParts_Select((int)act[1]);
                    research.FixFace();
                }
                else if (act[0].Equals("force"))
                {
                    research.BodyParts_Select((int)act[1]);
                    research.CreateLoad((double)act[2]);
                }
            }

            research.CreateMesh();
            research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();
            dataGridView1.Rows[0].Cells[0].Value = 0;
            dataGridView1.Rows[0].Cells[1].Value = stress; // Деформация
            dataGridView1.Rows[0].Cells[2].Value = displacement; // Смещение
            dataGridView1.Rows[0].Cells[10].Value = research.webDensity; // плотность сетки
            dataGridView1.Rows[0].Cells[11].Value = research.tlCurrent; // tl

            //object[] buff1 = new object[2]; //[кол-во ячеек, напряжение]
            //buff1[0] = 0; buff1[1] = stress;
            //dataStress.Add(buff1);

            //object[] buff2 = new object[2]; //[кол-во ячеек, перемещение]
            //buff2[0] = 0; buff2[1] = displacement;

            FillingStressStrainMass();

            // Очищаем
            research.deleteStudy(); research = null;
            FreeClass.sldManager.swModel.ClearSelection2(true);
        }

        private void deleteResearch4_Click(object sender, EventArgs e)
        {
            if (research != null)
            {
                try { research.deleteStudy(); } catch { }
                research = null;
                fix = false;
                att = false;
                startResearch4.Enabled = false;
            }

            try { cellsDraw.deleteCells(); } catch { }
        }
        ////////////////// Конец Исследования //////////////////


        private void fixRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            acceptButton4.Text = "Зафиксировать";
            label19.Visible = false; textBox13.Visible = false;
        }

        private void strenghtRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            acceptButton4.Text = "Приложить силу";
            label19.Visible = true; textBox13.Visible = true;
        }

        private string writeResults()
        {
            string result = "";
            result += "Степень матрицы - " + cells.GetColumnsNumber(); result += Environment.NewLine;
            result += "Обьём тела - " + FreeClass.body.GetV(); result += Environment.NewLine;
            result += "Обьём структуры - " + cells.GetCellsV(); result += Environment.NewLine;
            result += "Площадь структуры - " + cells.GetSCells(); result += Environment.NewLine;
            result += "Площадь 1 ячейки - " + cells.GetS1(); result += Environment.NewLine;
            result += "Локаль - " + cells.GetLocal(); result += Environment.NewLine;
            result += "Радиус вписаной в локаль окружности - " + cells.GetRadius(); result += Environment.NewLine;
            result += "Сторона вписанного в окружность многоулольника - " + cells.GetSide(); result += Environment.NewLine;
            //result += "Коэффицент соотношения площадей - " + cells.GetRelations(); result += Environment.NewLine;
            result += "Максимальное соотношение - " + NAngleCells.maxCoef; result += Environment.NewLine;
            result += "Доступность построения - " + cells.isAvailable(); result += Environment.NewLine;
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Поиск Минимума
            double min = double.MaxValue; // Максимальная плотность сетки
            double mint1 = double.MaxValue;
            for(int i = 0; i< dataGridView1.RowCount; i++) {
                if(Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value) < min) {
                    min = Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                    mint1 = Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value);
                }
            }
            // Заполнение второй таблицы
            FillSecondTable();

            // Исправление значений, отличных от минимума
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (Convert.ToDouble(dataGridView2.Rows[i].Cells[10].Value) != min)
                {
                    if (Convert.ToInt16(dataGridView2.Rows[i].Cells[0].Value) == 0)
                    {
                        withoutIterationReResearch(min, mint1);
                        for (int f = 1; f < dataGridView2.RowCount; f++) {
                            dataGridView2.Rows[f].Cells[3].Value = Convert.ToDouble(dataGridView2.Rows[f].Cells[1].Value) -
                                Convert.ToDouble(dataGridView2.Rows[0].Cells[1].Value); // Разность напряжения
                            dataGridView2.Rows[f].Cells[4].Value = Convert.ToDouble(dataGridView2.Rows[f].Cells[1].Value) * 100 /
                                Convert.ToDouble(dataGridView2.Rows[0].Cells[1].Value); // %

                            dataGridView2.Rows[f].Cells[5].Value = Convert.ToDouble(dataGridView2.Rows[f].Cells[2].Value) -
                                Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value); // Разность деформации
                            dataGridView2.Rows[f].Cells[6].Value = Convert.ToDouble(dataGridView2.Rows[f].Cells[2].Value) * 100 /
                                Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value); // %
                        }
                        continue;
                    }
                    reResearch(i, min, mint1);
                }

            }
        }

        private void FillSecondTable()
        {
            dataGridView2.RowCount = dataGridView1.RowCount;

            for (int i = 0; i < dataGridView1.RowCount; i++) {
                for (int j = 0; j<dataGridView1.ColumnCount; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
        }

        private void reResearch(int dataRow, double webDensity, double tlCurrent)
        {
            NAngleEmprovedForm owner;
            try { owner = (NAngleEmprovedForm)this.Owner; }
            catch { MessageBox.Show("Ошибка получения материнской формы"); return; }

            int angles = Convert.ToInt16(dataGridView1.Rows[dataRow].Cells[7].Value);

            if (angles == 3) { cells = new TriangleCells(FreeClass.body); }
            else if (angles == 4) { cells = new RectangleCells(FreeClass.body); }
            else {
                cells = new NAngleCells(FreeClass.body);
                cells.SetAnglesN(Convert.ToInt16(dataGridView1.Rows[dataRow].Cells[7].Value));
            }
            cells.SetAccuracy(accuracy);

            int cellsNum = Convert.ToInt16(Math.Sqrt(Convert.ToInt16(dataGridView1.Rows[dataRow].Cells[0].Value)));

            cells.SetColumnsNumber(cellsNum); cells.SetRowsNumber(cellsNum);
            cells.SetCellsHeight(owner.GetHeight());
            cells.SetCellsV(FreeClass.body.GetV() * Convert.ToDouble(owner.GetVolume()) / 100);

            cells.Calculation();

            //создаём исследование
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();

            if (cells is RectangleCells){
                rectDrawer = new RectangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                rectDrawer.SetCells((RectangleCells)cells);
                FreeClass.cells = rectDrawer; rectDrawer.drawCells();
            }else if (cells is TriangleCells){
                triangleDrawer = new TriangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                triangleDrawer.SetCells((TriangleCells)cells);
                FreeClass.cells = triangleDrawer; triangleDrawer.drawCells();
            } else {
                cellsDraw = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, 0);
                cellsDraw.SetCells((AbstractRelationAngle)cells);
                FreeClass.cells = cellsDraw; cellsDraw.drawCells();
            }

            // прикладываем силы или фиксируем грани
            foreach (object[] act in action)
            {
                if (act[0].Equals("fix"))
                {
                    research.BodyParts_Select((int)act[1]);
                    research.FixFace();
                }
                else if (act[0].Equals("force"))
                {
                    research.BodyParts_Select((int)act[1]);
                    research.CreateLoad((double)act[2]);
                }
            }

            //research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            //research.CreateStudy();

            research.webDensity = webDensity;
            research.tlCurrent = tlCurrent;

            research.CreateMesh(); research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();

            dataGridView2.Rows[dataRow].Cells[1].Value = stress; // Деформация
            dataGridView2.Rows[dataRow].Cells[2].Value = displacement; // Смещение

            dataGridView2.Rows[dataRow].Cells[3].Value = Convert.ToDouble(dataGridView2.Rows[dataRow].Cells[1].Value) -
                Convert.ToDouble(dataGridView2.Rows[0].Cells[1].Value); // Разность напряжения
            dataGridView2.Rows[dataRow].Cells[4].Value = Convert.ToDouble(dataGridView2.Rows[dataRow].Cells[1].Value) * 100 /
                Convert.ToDouble(dataGridView2.Rows[0].Cells[1].Value); // %

            dataGridView2.Rows[dataRow].Cells[5].Value = Convert.ToDouble(dataGridView2.Rows[dataRow].Cells[2].Value) -
                Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value); // Разность деформации
            dataGridView2.Rows[dataRow].Cells[6].Value = Convert.ToDouble(dataGridView2.Rows[dataRow].Cells[2].Value) * 100 /
                Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value); // %

            dataGridView2.Rows[dataRow].Cells[10].Value = research.webDensity; // плотность сетки
            dataGridView2.Rows[dataRow].Cells[11].Value = research.tlCurrent; // tl

            // Очищаем
            research.deleteStudy(); research = null;
            FreeClass.sldManager.swModel.ClearSelection2(true);

            FreeClass.cells.deleteCells();
        }

        private void withoutIterationReResearch(double webDensity, double tlCurrent)
        {
            //создаём исследование
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();
            research.webDensity = webDensity;
            research.tlCurrent = tlCurrent;
            //прикладываем силы или фиксируем грани
            foreach (object[] act in action)
            {
                if (act[0].Equals("fix"))
                {
                    research.BodyParts_Select((int)act[1]);
                    research.FixFace();
                }
                else if (act[0].Equals("force"))
                {
                    research.BodyParts_Select((int)act[1]);
                    research.CreateLoad((double)act[2]);
                }
            }

            research.CreateMesh();
            research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();
            dataGridView2.Rows[0].Cells[0].Value = 0;
            dataGridView2.Rows[0].Cells[1].Value = stress; // Деформация
            dataGridView2.Rows[0].Cells[2].Value = displacement; // Смещение4

            dataGridView2.Rows[0].Cells[10].Value = research.webDensity; // плотность сетки
            dataGridView2.Rows[0].Cells[11].Value = research.tlCurrent; // tl

            //object[] buff1 = new object[2]; //[кол-во ячеек, напряжение]
            //buff1[0] = 0; buff1[1] = stress;
            //dataStress.Add(buff1);

            //object[] buff2 = new object[2]; //[кол-во ячеек, перемещение]
            //buff2[0] = 0; buff2[1] = displacement;

            FillingStressStrainMass();

            // Очищаем
            research.deleteStudy(); research = null;
            FreeClass.sldManager.swModel.ClearSelection2(true);
        }

        private string Check_Actions()
        {
            string error = "";
            bool is_force = false, is_fix = false;
            List<int> force_edge = new List<int>();
            List<int> fix_edge = new List<int>();
            //int force_edge = -1, fix_edge = -1;

            foreach (object[] act in action)
            {
                if (act[0].Equals("fix"))
                {
                    is_fix = true;
                    fix_edge.Add((int)act[1]);
                    //research.BodyParts_Select((int)act[1]);
                    //research.FixFace();
                }
                else if (act[0].Equals("force"))
                {
                    is_force = true;
                    force_edge.Add((int)act[1]);
                    //research.BodyParts_Select((int)act[1]);
                    //research.CreateLoad((double)act[2]);
                }
            }

            if (is_fix && is_force) {
                error = "Сила и крепление НЕ ДОЛЖНЫ БЫТЬ приложенны к одной стороне";
                // Если в списке действий есть хотя бы пара несовпадающих действий,
                // приложенных к разным граням 
                for (int i = 0; i < fix_edge.Count; i++)
                {
                    for (int j = 0; j < force_edge.Count; j++)
                    { if (fix_edge[i] != force_edge[j]) { return ""; } }
                }
            }else if (is_fix) { error = "На тело не была применена нагрузка"; }
            else if (is_force) { error = "Тело не было закреплено"; }
            else { error = "На тело не применено никаких действий"; }

            return error;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillSecondTable();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 0;
            dataGridView2.RowCount = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawingStatistic drawing = new DrawingStatistic(stressLists, strainLists, nodeList);
            drawing.ShowDialog();
        }

        private void FillingStressStrainMass()
        {
            stressLists.Add(research.GetStressObjectMass());
            strainLists.Add(research.GetStrainObjectMass());
        }
    }
}
