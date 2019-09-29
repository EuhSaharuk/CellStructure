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
    public partial class NAngleForm : Form
    {
        AbstractAngle cells;

        AbstractNAngleDrawer drawer;
        TriangleCellsDrawer triangleDrawer;

        public NAngleForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            resultBox.Clear();

            if (FreeClass.body == null)
            {
                MessageBox.Show("Тело не было задано. Невозможно произвести вычисления");
                return;
            }

            int start, end, step;
            if (loopBuildRadioButton.Checked){
                start = Convert.ToInt16(GetStartPoint());
                end = Convert.ToInt16(GetEndPoint());
                step = Convert.ToInt16(GetStep());
            } else {
                start = end = Convert.ToInt16(GetStartPoint());
                step = 1;
            }

            for (int i = start; i <= end; i = i + step)
            {
                if(Convert.ToInt16(textBox5.Text) == 3)
                {
                    cells = new TriangleCells(FreeClass.body);
                }
                else if (Convert.ToInt16(textBox5.Text) >= 91) {
                    cells = new CircleCells(FreeClass.body);
                } else {
                    cells = new NAngleCells(FreeClass.body);
                    cells.SetAnglesN(Convert.ToInt16(textBox5.Text));
                }

                cellsCalculate(cells, i);

                //resultBox.Text += cells.GetType();
                if(cells is TriangleCells) { resultBox.Text += writeResults((TriangleCells)cells); }
                else { resultBox.Text += writeResults((AbstractRelationAngle)cells);}
                resultBox.Text += Environment.NewLine; resultBox.Text += Environment.NewLine;
            }
        }

        private void cellsCalculate(AbstractAngle c, int columns) {
            c.SetColumnsNumber(columns);
            c.SetRowsNumber(columns);
            c.SetCellsHeight(Convert.ToDouble(textBox2.Text.Replace('.', ',')));

            c.SetAccuracy(Convert.ToInt16(textBox4.Text));
            c.SetCellsV(FreeClass.body.GetV() * Convert.ToDouble(textBox3.Text.Replace('.', ',')) / 100);
            c.Calculation();
        }

        private string writeResults(TriangleCells triangle) {
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

        private string writeResults(AbstractRelationAngle dataCells) {
            string result = "";
            result += "Степень матрицы - " + dataCells.GetColumnsNumber(); result += Environment.NewLine;
            result += "Обьём тела - " + FreeClass.body.GetV(); ; result += Environment.NewLine;
            result += "Обьём структуры - " + dataCells.GetCellsV(); result += Environment.NewLine;
            result += "Площадь структуры - " + dataCells.GetSCells(); result += Environment.NewLine;
            result += "Площадь 1 ячейки - " + dataCells.GetS1(); result += Environment.NewLine;
            result += "Локаль - " + dataCells.GetLocal(); result += Environment.NewLine;
            result += "Радиус вписаной в локаль окружности - " + dataCells.GetRadius(); result += Environment.NewLine;
            result += "Сторона вписанного в окружность многоулольника - " + dataCells.GetSide(); result += Environment.NewLine;
            result += "Коэффицент соотношения площадей - " + dataCells.GetRelations(); result += Environment.NewLine;
            result += "Максимальное соотношение - " + AbstractRelationAngle.maxCoef; result += Environment.NewLine;
            result += "Доступность построения - " + dataCells.isAvailable(); result += Environment.NewLine;
            return result;
        }


        private void drawButton_Click(object sender, EventArgs e)
        {
            if (cells == null){
                MessageBox.Show("Расчёты не были произведены. Невозможно построить ячеистую структуру");
                return;
            }

            if (FreeClass.bodyDrawer == null) {
                MessageBox.Show("Тело не было построенно. Невозможно построить ячеистую структуру");
                return;
            }

            if (!cells.isAvailable()) {
                MessageBox.Show("Невозможно построить структуру. Проверьте вычисления");
                return;
            }

            if (loopBuildRadioButton.Checked) {
                DialogResult dialogResult = MessageBox.Show("Выбрано циклическое построение. Будет выполненно только одно " +
                    "построение (самое последнее). Продолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) { return; }
            }

            int angel = Convert.ToInt16(textBox6.Text);

            if (cells is CircleCells){
                drawer = new CircleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, angel);
                drawer.SetCells((AbstractRelationAngle)cells);
            } else if(cells is TriangleCells){
                triangleDrawer = new TriangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
                triangleDrawer.SetCells((TriangleCells)cells);
            }
            else {
                drawer = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, angel);
                drawer.SetCells((AbstractRelationAngle)cells);
            }

            if (drawer != null){ FreeClass.cells = drawer; drawer.drawCells(); }
            else { FreeClass.cells = triangleDrawer; triangleDrawer.drawCells(); }
            //FreeClass.cells = drawer;
            //drawer.SetCells(cells); drawer.drawCells();
        }

        //private void triangleDraw()
        //{
        //    /*if (triangleCells == null)
        //    {
        //        MessageBox.Show("Расчёты не были произведены. Невозможно построить ячеистую структуру");
        //        return;
        //    }

        //    if (FreeClass.bodyDrawer == null)
        //    {
        //        MessageBox.Show("Тело не было построенно. Невозможно построить ячеистую структуру");
        //        return;
        //    }

        //    if (!triangleCells.isAvailable())
        //    {
        //        MessageBox.Show("Невозможно построить структуру. Проверьте вычисления");
        //        return;
        //    }*/

        //    if (loopBuildRadioButton.Checked)
        //    {
        //        DialogResult dialogResult = MessageBox.Show("Выбрано циклическое построение. Будет выполненно только одно " +
        //            "построение (самое последнее). Продолжить?",
        //            "Предупреждение", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.No) { return; }
        //    }
        //    triangleDrawer = new TriangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
        //    FreeClass.cells = triangleDrawer;
        //    //triangleDrawer.SetCells(triangleCells); triangleDrawer.drawCells();
        //}

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try { FreeClass.cells.deleteCells(); }
            catch { }
            drawer = null; FreeClass.cells = null; triangleDrawer = null;
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
            ResearchNAngleForm form = new ResearchNAngleForm();
            // Для обращения дочерней формы к методам материнской(передача данных)
            form.Owner = this;
            form.Show();
        }

        public bool CheckLoop() { return loopBuildRadioButton.Checked; }
        public string GetVolume() { return textBox3.Text; }
        public string GetAccuracy() { return textBox4.Text; }
        public string GetStartPoint() { return textBox1.Text; }
        public string GetEndPoint() { return textBox7.Text; }
        public string GetStep() { return stepTextBox.Text; }
        public int GetAngles() { return Convert.ToInt16(textBox5.Text); }
        public double GetHeight() { return Convert.ToDouble(textBox2.Text.Replace('.', ',')); }
        public int GetDeflection() { return Convert.ToInt16(textBox6.Text); }

    }
}
