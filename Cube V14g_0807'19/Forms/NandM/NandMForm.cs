using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube_V11
{
    public partial class NandMForm : Form
    {
        NandMRectangleCells cells;
        NandMRectangleCellsDrawer drawer;

        public NandMForm()
        {
            InitializeComponent();
        }

        private void NandMForm_Load(object sender, EventArgs e)
        {
            singleRadioBurron_CheckedChanged(null, null);
            FreeRadioButton_CheckedChanged(null, null);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (FreeClass.body == null) {
                MessageBox.Show("Тело не было задано. Невозможно произвести вычисления");
                return;
            }

            if (singleBuildRadioButton.Checked)
            {
                cells = new NandMRectangleCells(FreeClass.body);
                cells.SetAccuracy(Convert.ToInt16(textBox4.Text));
                cells.SetCellsV(FreeClass.body.GetV() * Convert.ToDouble(textBox3.Text.Replace('.', ',')) / 100);
                if (TwoInNRadioButton.Checked)
                {
                    double buff = Convert.ToInt16(textBox1.Text);
                    if (buff % 2 == 0)
                    {
                        buff = Math.Sqrt(Math.Pow(2, buff));
                        cells.SetColumnsNumber(Convert.ToInt16(buff));
                        cells.SetRowsNumber(Convert.ToInt16(buff));
                    }
                    else
                    {
                        buff = Math.Sqrt(Math.Pow(2, buff - 1));
                        cells.SetColumnsNumber(Convert.ToInt16(buff) * 2);
                        cells.SetRowsNumber(Convert.ToInt16(buff));
                    }
                }
                else if (SquareMatrixRadioButton.Checked)
                {
                    cells.SetColumnsNumber(Convert.ToInt16(textBox1.Text));
                    cells.SetRowsNumber(Convert.ToInt16(textBox1.Text));
                }
                else
                {
                    cells.SetColumnsNumber(Convert.ToInt16(textBox1.Text));
                    cells.SetRowsNumber(Convert.ToInt16(textBox2.Text));
                }

                cells.Calculation();

                if (!cells.isAvailable()) { MessageBox.Show("Решение не было найдено"); return; }

                resultBox.Clear();
                resultBox.Text += "Обьём цельного тела" + FreeClass.body.GetV(); resultBox.Text += Environment.NewLine;
                textResultsCellsRectangelNaM(resultBox);

            }
            else if (loopBuildRadioButton.Checked)
            {
                resultBox.Clear();
                resultBox.Text += "Обьём цельного тела" + FreeClass.body.GetV(); resultBox.Text += Environment.NewLine;
                if (SquareMatrixRadioButton.Checked)
                {
                    matrixLoopCalculation();
                }
                else if (TwoInNRadioButton.Checked)
                {
                    int start, end, step;
                    start = Convert.ToInt16(GetStartPoint());
                    end = Convert.ToInt16(GetEndPoint());
                    step = Convert.ToInt16(GetStep());
                    double partOfVolume = Convert.ToDouble(GetVolume());

                    for (int i = start, j = 1; i <= end; i = i + step, j++)
                    {
                        cells = new NandMRectangleCells(FreeClass.body);
                        cells.SetAccuracy(Convert.ToInt16(GetAccuracy()));
                        cells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                        if (i % 2 == 0)
                        {
                            double buff = Math.Sqrt(Math.Pow(2, i));
                            cells.SetColumnsNumber(Convert.ToInt16(buff));
                            cells.SetRowsNumber(Convert.ToInt16(buff));
                        }
                        else
                        {
                            double buff = Math.Sqrt(Math.Pow(2, i - 1));
                            cells.SetColumnsNumber(Convert.ToInt16(buff) * 2);
                            cells.SetRowsNumber(Convert.ToInt16(buff));
                        }

                        cells.Calculation();
                        if (!cells.isAvailable())
                        {
                            DialogResult dialogResult = MessageBox.Show("Не удалось решить структуру при определённых условиях." +
                                " запустить следующий набор данных?",
                             "Предупреждение", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes) { continue; }
                            else if (dialogResult == DialogResult.No) { return; }
                        }

                        textResultsCellsRectangelNaM(resultBox);

                    }

                }
                else
                {
                    int start1, start2, end, step;
                    start1 = Convert.ToInt16(GetStartPoint());
                    start2 = Convert.ToInt16(GetEndPoint());
                    end = Convert.ToInt16(GetMiddlePoint());
                    step = Convert.ToInt16(GetStep());
                    double partOfVolume = Convert.ToDouble(GetVolume());

                    //withoutIterationResearch();

                    for (int i = start1, j = 1; i <= end; i = i + step, j++, start2 = start2 + step)
                    {
                        cells = new NandMRectangleCells(FreeClass.body);

                        cells.SetAccuracy(Convert.ToInt16(GetAccuracy()));
                        cells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                        cells.SetColumnsNumber(i); cells.SetRowsNumber(start2);

                        cells.Calculation();
                        if (!cells.isAvailable())
                        {
                            DialogResult dialogResult = MessageBox.Show("Не удалось решить структуру при определённых условиях." +
                                " запустить следующий набор данных?",
                             "Предупреждение", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes) { continue; }
                            else if (dialogResult == DialogResult.No) { return; }
                        }

                        textResultsCellsRectangelNaM(resultBox);
                    }

                }
            }
        }

        private void matrixLoopCalculation()
        {
            int start, end, step;
            start = Convert.ToInt16(GetStartPoint());
            end = Convert.ToInt16(GetEndPoint());
            step = Convert.ToInt16(GetStep());
            double partOfVolume = Convert.ToDouble(GetVolume());

            for (int i = start; i <= end; i = i + step)
            {
                cells = new NandMRectangleCells(FreeClass.body);
                cells.SetAccuracy(Convert.ToInt16(GetAccuracy()));
                cells.SetCellsV(FreeClass.body.GetV() * Convert.ToDouble(textBox3.Text.Replace('.', ',')) / 100);
                cells.SetColumnsNumber(i); cells.SetRowsNumber(i);
                cells.Calculation();
                //рисуем ячейки
                if (!cells.isAvailable())
                {
                    DialogResult dialogResult = MessageBox.Show("Не удалось решить структуру при определённых условиях." +
                        " запустить следующий набор данных?",
                     "Предупреждение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) { continue; }
                    else if (dialogResult == DialogResult.No) { return; }
                }

                textResultsCellsRectangelNaM(resultBox);
                resultBox.Text += Environment.NewLine;
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if(cells == null){
                MessageBox.Show("Расчёты не были произведены. Невозможно построить ячеистую структуру");
                return;
            }

            if(FreeClass.bodyDrawer == null)
            {
                MessageBox.Show("Тело не было построенно. Невозможно построить ячеистую структуру");
                return;
            }

            if (loopBuildRadioButton.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Выбрано циклическое построение. Будет выполненно только одно " + 
                    "построение (самое последнее). Продолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) { return; }
            }

            // Если ячейки уже существуют
            if (FreeClass.cells != null)
            {
                DialogResult dialogResult = MessageBox.Show("На объекте уже есть ячеистая структура. Удалить её?", 
                    "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {  deleteButton_Click(null, null); }
                else if (dialogResult == DialogResult.No){ return; }
            }

            drawer = new NandMRectangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);
            FreeClass.cells = drawer;
            drawer.SetCells(cells); drawer.drawCells();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try { FreeClass.cells.deleteCells(); }
            catch { }
            FreeClass.cells = null; drawer = null;
        }

        private void textResultsCellsRectangelNaM(TextBox box)
        {
            //box.Text += "Номер итерации - " + cellsRectangelNaM.GetIterationNumber().ToString();
            //box.Text += Environment.NewLine;
            box.Text += "Количество ячеек - " + (cells.GetColumnsNumber() * cells.GetRowsNumber()).ToString();
            box.Text += Environment.NewLine;
            box.Text += "Часть объёма, занимаемая ячеками - " + cells.GetCellsV().ToString();
            box.Text += Environment.NewLine;
            box.Text += "ФАКТИЧЕСКАЯ часть объёма, занимаемая ячеками - " + cells.GetVCellsFactical().ToString();
            box.Text += Environment.NewLine;
            box.Text += "K - " + cells.GetK().ToString();
            box.Text += Environment.NewLine;
            box.Text += "Ширина 1 ячейки - " + cells.GetCellsWidth().ToString();
            box.Text += Environment.NewLine;
            box.Text += "Длинна 1 ячейки - " + cells.GetCellsLenght().ToString();
            box.Text += Environment.NewLine;
            box.Text += "Высота 1 ячейки - " + cells.GetCellsHeight().ToString();
            box.Text += Environment.NewLine;
            box.Text += Environment.NewLine;
        }

        private void singleRadioBurron_CheckedChanged(object sender, EventArgs e)
        {
            if (FreeRadioButton.Checked) { FreeRadioButton_CheckedChanged(null, null); }
            else if (TwoInNRadioButton.Checked) { TwoInNRadioButton_CheckedChanged(null, null); }
            else { SquareMatrixRadioButton_CheckedChanged(null, null); }

            button1.Visible = false;
            label5.Visible = false; stepTextBox.Visible = false;
            label7.Visible = false;
        }

        private void loopRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FreeRadioButton.Checked) {  FreeRadioButton_CheckedChanged(null, null); }
            else if (TwoInNRadioButton.Checked){ TwoInNRadioButton_CheckedChanged(null, null); }
            else { SquareMatrixRadioButton_CheckedChanged(null, null); }

            button1.Visible = true;
            label5.Visible = true; stepTextBox.Visible = true;
            label7.Visible = true;
        }

        private void FreeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (singleBuildRadioButton.Checked)
            {
                label1.Text = "Количество столбцов";
                label2.Visible = true; label2.Text = "Количество строк"; textBox2.Visible = true;
                label5.Visible = false; stepTextBox.Visible = false;
                label6.Visible = false; textBox5.Visible = false;
            }
            else
            {
                label1.Text = "Начальный столбец";
                label2.Visible = true; label2.Text = "Начальная строка"; textBox2.Visible = true;
                label6.Visible = true; label6.Text = "Конечный столбец"; textBox5.Visible = true;
                label5.Visible = true; stepTextBox.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResearchNandMFForm form = new ResearchNandMFForm();
            // Для обращения дочерней формы к методам материнской(передача данных)
            form.Owner = this;
            form.Show();
        }

        private void TwoInNRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (singleBuildRadioButton.Checked)
            {
                label1.Text = "Степень";
                label2.Visible = false; textBox2.Visible = false;
                label6.Visible = false; textBox5.Visible = false;
                label5.Visible = false; stepTextBox.Visible = false;
            }
            else
            {
                label1.Text = "Начальная степень";
                label2.Visible = true; label2.Text = "Конечная степень"; textBox2.Visible = true;
                label6.Visible = false; textBox5.Visible = false;
                label5.Visible = true; stepTextBox.Visible = true;
            }
        }

        private void SquareMatrixRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (singleBuildRadioButton.Checked)
            {
                label1.Text = "Порядок матрицы";
                label2.Visible = false; textBox2.Visible = false;
                label6.Visible = false; textBox5.Visible = false;
                label5.Visible = false; stepTextBox.Visible = false;
            }
            else
            {
                label1.Text = "Начальный порядок";
                label2.Visible = true; label2.Text = "Конечный порядок"; textBox2.Visible = true;
                label6.Visible = false; textBox5.Visible = false;
                label5.Visible = true; stepTextBox.Visible = true;
            }
        }

        public bool CheckLoop() { return loopBuildRadioButton.Checked; }
        public string GetStartPoint() { return textBox1.Text; }
        public string GetMiddlePoint() { return textBox5.Text; }
        public string GetEndPoint() { return textBox2.Text; }
        public string GetStep() { return stepTextBox.Text; }
        public string GetVolume() { return textBox3.Text; }
        public string GetAccuracy() { return textBox4.Text; }

        public string GetMethod() {
            if (FreeRadioButton.Checked) { return "free"; }
            else if (TwoInNRadioButton.Checked) { return "2n"; }
            else { return "matrix"; }
        }
    }
}
