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
    public partial class NAngleEmprovedForm : Form
    {
        AbstractAngle cells;
        AbstractNAngleDrawer drawer;

        CircleCellsDrawer circleDrawer;
        TriangleCellsDrawer triangleDrawer;
        RectangleCellsDrawer rectDrawer;

        //TriangleCells triangleCells;

        public NAngleEmprovedForm()
        {
            InitializeComponent();
            loopBuildRadioButton.Checked = true;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            resultBox.Clear();

            if (FreeClass.body == null)
            {
                MessageBox.Show("Тело не было задано. Невозможно произвести вычисления");
                return;
            }

            if (FreeClass.body.GetHeight() < Convert.ToDouble(textBox2.Text.Replace('.', ',')))
            {
                MessageBox.Show("Высота ячейки не может быть больше высоты тела");
                return;
            }
            
            // характеристики цикличного постороения
            int start, end, step;
            if (loopBuildRadioButton.Checked)
            {
                start = Convert.ToInt16(GetStartPoint());
                end = Convert.ToInt16(GetEndPoint());
                step = Convert.ToInt16(GetStep());
            }
            else
            {
                start = end = Convert.ToInt16(GetStartPoint());
                step = 1;
            }

            // размер матрицы
            // количество углов
            // изменение объёма
            // изменение угла наклона

            try
            {
                if (start > end && step < 0)
                {
                    for (int i = start; i >= end; i = i + step) { loopAngleNum(i); }
                }
                else if (start <= end && step > 0)
                {
                    for (int i = start; i <= end; i = i + step) { loopAngleNum(i); }
                }
                else if (step == 0) { loopAngleNum(start); }
                else { MessageBox.Show("Неверно указаны данные по заданию степени матрицы"); }
            }
            catch { MessageBox.Show("Ошибка в задании одного из набора параметров"); }
        }

        /// <summary>
        /// Цикл по изменению количества углов
        /// </summary>
        /// <param name="matrixGrade">Степень матрицы</param>
        private void loopAngleNum(int matrixGrade)
        {
            int angleStart = Convert.ToInt16(angleNumStartTextBox.Text);
            int angeEnd = Convert.ToInt16(angleEndTextBox.Text);
            int angleStep = Convert.ToInt16(angleStepTextBox.Text);

            if (angleStart > angeEnd && angleStep < 0)
            {
                for (int i = angleStart; i >= angeEnd; i = i + angleStep)
                { 
                    if(i == 2)
                    {
                        cells = new CircleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    }
                    else if(i == 3)
                    {
                        cells = new TriangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    }
                    else if (i == 4) {
                        cells = new RectangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else {
                        cells = new NAngleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                        cells.SetAnglesN(i);
                    }
                    loopVolume(i);
                }
            }
            else if (angleStart <= angeEnd && angleStep > 0)
            {
                for (int i = angleStart; i <= angeEnd; i = i + angleStep) {
                    if (i == 2)
                    {
                        cells = new CircleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else if (i == 3) {
                        cells = new TriangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else if (i == 4){
                        cells = new RectangleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                    } else {
                        cells = new NAngleCells(FreeClass.body);
                        cells.SetColumnsNumber(matrixGrade);
                        cells.SetRowsNumber(matrixGrade);
                        cells.SetAnglesN(i);
                    }
                    loopVolume(i);
                }
            }
            else if (angleStep == 0) {
                if (angleStart == 2)
                {
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
                loopVolume(angleStart); }
            else { throw new Exception(); }
        }

        private void loopVolume(int angles)
        {
            double volumeStart = Convert.ToDouble(volumeStartTextBox.Text.Replace('.', ','));
            double volumeEnd = Convert.ToDouble(volumeEndTextBox.Text.Replace('.', ','));
            double volumeStep = Convert.ToDouble(textBox6.Text.Replace('.', ','));

            if (volumeStart > volumeEnd && volumeStep < 0)
            {
                for (double i = volumeStart; i >= volumeEnd; i = i + volumeStep)
                {
                    cells.SetCellsV((FreeClass.body.GetV() * i) / 100);
                    calculation(angles);
                }
            }
            else if (volumeStart <= volumeEnd && volumeStep > 0)
            {
                for (double i = volumeStart; i <= volumeEnd; i = i + volumeStep)
                {
                    cells.SetCellsV((FreeClass.body.GetV() * i) / 100);
                    calculation(angles);
                }
            }
            else if (volumeStep == 0)
            {
                cells.SetCellsV((FreeClass.body.GetV() * volumeStart) / 100);
                //cells.SetCellsV((FreeClass.body.GetV() * volumeStart) / 100);
                calculation(angles);
            }
            else { throw new Exception(); }
        }

        private void calculation(int angles)
        {
            if (angles == 4) {
                cells.SetCellsHeight(Convert.ToDouble(textBox2.Text.Replace('.', ',')));
                cells.SetAccuracy(Convert.ToInt16(textBox4.Text));
                cells.Calculation();
                //textResultsCellsRectangelNaM(resultBox);
                resultBox.Text += writeResults((RectangleCells)cells);
                resultBox.Text += Environment.NewLine; resultBox.Text += Environment.NewLine;

                if(cells.isAvailable() == false)
                {
                    MessageBox.Show("Ошибка вычислений:"+Environment.NewLine + writeResults((RectangleCells)cells));
                }
            }
            else
            {
                cells.SetCellsHeight(Convert.ToDouble(textBox2.Text.Replace('.', ',')));
                cells.SetAccuracy(Convert.ToInt16(textBox4.Text));
                cells.Calculation();
                if (cells is AbstractRelationAngle) {
                    resultBox.Text += writeResults((AbstractRelationAngle)cells);
                    if (cells.isAvailable() == false)
                    {
                        MessageBox.Show("Ошибка вычислений:" + Environment.NewLine + writeResults((AbstractRelationAngle)cells));
                    }
                }
                else {
                    resultBox.Text += writeResults((TriangleCells)cells);
                    if (cells.isAvailable() == false)
                    {
                        MessageBox.Show("Ошибка вычислений:" + Environment.NewLine + writeResults((TriangleCells)cells));
                    }
                }

                resultBox.Text += Environment.NewLine; resultBox.Text += Environment.NewLine;
            }
        }

        private string writeResults(AbstractRelationAngle dataCells)//круг и многоугольник
        {
            string result = "";
            result += "Степень матрицы - " + dataCells.GetColumnsNumber(); result += Environment.NewLine;
            result += "Количество углов - " + dataCells.GetAnglesN(); result += Environment.NewLine;
            result += "Обьём тела - " + FreeClass.body.GetV(); ; result += Environment.NewLine;
            result += "Обьём структуры - " + dataCells.GetCellsV(); result += Environment.NewLine;
            result += "Часть от объёма - " + (dataCells.GetCellsV() * 100) / FreeClass.body.GetV(); result += Environment.NewLine;
            result += "Площадь структуры - " + dataCells.GetSCells(); result += Environment.NewLine;
            result += "Площадь 1 ячейки - " + dataCells.GetS1(); result += Environment.NewLine;

            result += "Локаль - " + dataCells.GetLocal(); result += Environment.NewLine;
            result += "Радиус вписаной в локаль окружности - " + dataCells.GetRadius(); result += Environment.NewLine;
            result += "Сторона вписанного в окружность многоулольника - " + dataCells.GetSide(); result += Environment.NewLine;
            result += "K_x = " + dataCells.GetKX(); result += Environment.NewLine;
            result += "K_y = " + dataCells.GetKY(); result += Environment.NewLine;

            result += "Коэффицент соотношения площадей - " + dataCells.GetRelations(); result += Environment.NewLine;
            result += "Максимальное соотношение - " + AbstractRelationAngle.maxCoef; result += Environment.NewLine;

            result += "Доступность построения - " + dataCells.isAvailable(); result += Environment.NewLine;
            return result;
        }

        private string writeResults(RectangleCells dataCells)
        {
            string result = "";
            result += "Степень матрицы - " + dataCells.GetColumnsNumber(); result += Environment.NewLine;
            result += "Количество углов - " + dataCells.GetAnglesN(); result += Environment.NewLine;
            result += "Обьём тела - " + FreeClass.body.GetV(); ; result += Environment.NewLine;
            result += "Обьём структуры - " + dataCells.GetCellsV(); result += Environment.NewLine;
            result += "Часть от объёма - " + (dataCells.GetCellsV() * 100) / FreeClass.body.GetV(); result += Environment.NewLine;
            result += "Площадь структуры - " + dataCells.GetSCells(); result += Environment.NewLine;
            result += "Площадь 1 ячейки - " + dataCells.GetS1(); result += Environment.NewLine;

            result += "Ширина 1 ячейки - " + dataCells.GetCellsWidth(); result += Environment.NewLine;
            result += "Длинна 1 ячейки - " + dataCells.GetCellsLenght(); result += Environment.NewLine;
            //result += "Локаль - " + dataCells.GetLocal(); result += Environment.NewLine;
            //result += "Радиус вписаной в локаль окружности - " + dataCells.GetRadius(); result += Environment.NewLine;
            //result += "Сторона вписанного в окружность многоулольника - " + dataCells.GetSide(); result += Environment.NewLine;
            result += "K = " + dataCells.GetK(); result += Environment.NewLine;
            result += "Максимальное соотношение - " + AbstractRelationAngle.maxCoef; result += Environment.NewLine;

            result += "Доступность построения - " + dataCells.isAvailable(); result += Environment.NewLine;
            return result;
        }

        private string writeResults(TriangleCells triangle)
        {
            string result = "";
            result += "Степень матрицы - " + triangle.GetColumnsNumber(); result += Environment.NewLine;
            result += "Обьём тела - " + FreeClass.body.GetV(); ; result += Environment.NewLine;
            result += "Обьём структуры - " + triangle.GetCellsV(); result += Environment.NewLine;
            result += "Площадь структуры - " + triangle.GetSCells(); result += Environment.NewLine;
            result += "Площадь 1 ячейки - " + triangle.GetS1(); result += Environment.NewLine;

            result += "Локаль - " + triangle.GetLocal(); result += Environment.NewLine;
            result += "Радиус вписаной в локаль окружности - " + triangle.GetRadius(); result += Environment.NewLine;
            result += "Сторона вписанного в окружность треугольника - " + triangle.GetSide(); result += Environment.NewLine;
            result += "K_x = " + triangle.GetKX(); result += Environment.NewLine;
            result += "K_y = " + triangle.GetKY(); result += Environment.NewLine;

            result += "Доступность построения - " + triangle.isAvailable(); result += Environment.NewLine;
            return result;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (cells == null)
            {
                MessageBox.Show("Расчёты не были произведены. Невозможно построить ячеистую структуру");
                return;
            }

            if (FreeClass.bodyDrawer == null)
            {
                MessageBox.Show("Тело не было построенно. Невозможно построить ячеистую структуру");
                return;
            }

            if (!cells.isAvailable())
            {
                MessageBox.Show("Невозможно построить структуру. Проверьте вычисления");
                return;
            }

            if (loopBuildRadioButton.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Выбрано циклическое построение. Будет выполненно только одно " +
                    "построение (самое последнее). Продолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) { return; }
            }

            int angel = Convert.ToInt16(difflectAngleStartTextBox.Text);

            if(cells is CircleCells)
            {
                circleDrawer = new CircleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, 0);
                circleDrawer.SetCells((CircleCells)cells);
                FreeClass.cells = circleDrawer; circleDrawer.drawCells();
            }
            else if (cells is RectangleCells) {
                rectDrawer = new RectangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                rectDrawer.SetCells((RectangleCells)cells);
                FreeClass.cells = rectDrawer; rectDrawer.drawCells();
            }
            else if (cells is TriangleCells)
            {
                triangleDrawer = new TriangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                triangleDrawer.SetCells((TriangleCells)cells);
                FreeClass.cells = triangleDrawer; triangleDrawer.drawCells();
            }
            else
            {
                drawer = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, angel);
                drawer.SetCells((AbstractRelationAngle)cells);
                FreeClass.cells = drawer; drawer.drawCells();
            }

            /*if (drawer != null) { FreeClass.cells = drawer; drawer.drawCells(); }
            else { FreeClass.cells = triangleDrawer; triangleDrawer.drawCells(); }
            /*drawer = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, angel);
            drawer.SetCells((AbstractRelationAngle)cells);*/

            //FreeClass.cells = drawer; drawer.drawCells();

            //FreeClass.cells = drawer;
            //drawer.SetCells(cells); drawer.drawCells();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try { FreeClass.cells.deleteCells(); }
            catch { }
            drawer = null; FreeClass.cells = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Степень";
            label7.Visible = false; textBox7.Visible = false;
            label8.Visible = false; stepTextBox.Visible = false;
            button1.Visible = false;
        }

        private void loopBuildRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Начальная степень";
            label7.Visible = true; textBox7.Visible = true;
            label8.Visible = true; stepTextBox.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            // Для обращения дочерней формы к методам материнской(передача данных)
            form.Owner = this;
            form.Show();
        }

        public bool CheckLoop() { return loopBuildRadioButton.Checked; }
        public string GetVolume() { return volumeStartTextBox.Text; }
        public string GetAccuracy() { return textBox4.Text; }
        public string GetStartPoint() { return textBox1.Text; }
        public string GetEndPoint() { return textBox7.Text; }
        public string GetStep() { return stepTextBox.Text; }
        public int GetAngles() { return Convert.ToInt16(angleNumStartTextBox.Text); }
        public double GetHeight() { return Convert.ToDouble(textBox2.Text.Replace('.', ',')); }
        //public int GetDeflection() { return Convert.ToInt16(difflectAngleStartTextBox.Text); }

        public int getAngleStart() { return Convert.ToInt32(angleNumStartTextBox.Text); }
        public int getAngleEnd() { return Convert.ToInt16(angleEndTextBox.Text); }
        public int getAngleStep() { return Convert.ToInt16(angleStepTextBox.Text); }

        public double getvolumeStart() { return Convert.ToDouble(volumeStartTextBox.Text.Replace('.', ',')); }
        public double getvolumeEnd() { return Convert.ToDouble(volumeEndTextBox.Text.Replace('.', ',')); }
        public double getvolumeStep() { return Convert.ToDouble(textBox6.Text.Replace('.', ','));}

        public double getDeflectionStart() { return Convert.ToDouble(difflectAngleStartTextBox.Text.Replace('.', ',')); }
        public double getDeflectionEnd() { return Convert.ToDouble(difflectAngleEndTextBox.Text.Replace('.', ',')); }
        public double getDeflectionStep() { return Convert.ToDouble(difflectionStepTextBox.Text.Replace('.', ',')); }

        private void angleNumStartTextBox_TextChanged(object sender, EventArgs e)
        {
            if (angleNumStartTextBox.Text == "" || angleEndTextBox.Text == "") { return; }
            int angle = Convert.ToInt32(angleNumStartTextBox.Text);
            int angle2 = Convert.ToInt32(angleEndTextBox.Text);
            if (angle == 2 || angle == 3 || angle == 4 
                || angle2 == 2 || angle2 == 3 || angle2 == 4)
            {
                difflectAngleStartTextBox.Enabled = false;
                difflectAngleEndTextBox.Enabled = false;
                difflectionStepTextBox.Enabled = false;
            } else {
                difflectAngleStartTextBox.Enabled = true;
                difflectAngleEndTextBox.Enabled = true;
                difflectionStepTextBox.Enabled = true;
            }
        }

        private void angleEndTextBox_TextChanged(object sender, EventArgs e) {
            if (angleNumStartTextBox.Text == "" || angleEndTextBox.Text == "") { return; }
            int angle = Convert.ToInt32(angleNumStartTextBox.Text);
            int angle2 = Convert.ToInt32(angleEndTextBox.Text);
            if (angle == 2 || angle == 3 || angle == 4
                || angle2 == 2 || angle2 == 3 || angle2 == 4)
            {
                difflectAngleStartTextBox.Enabled = false;
                difflectAngleEndTextBox.Enabled = false;
                difflectionStepTextBox.Enabled = false;
            }
            else
            {
                difflectAngleStartTextBox.Enabled = true;
                difflectAngleEndTextBox.Enabled = true;
                difflectionStepTextBox.Enabled = true;
            }
        }
    }
}
