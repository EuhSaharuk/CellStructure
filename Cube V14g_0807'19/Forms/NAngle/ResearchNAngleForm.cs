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
    public partial class ResearchNAngleForm : Form
    {
        Research research;
        AbstractRelationAngle cells;
        AbstractNAngleDrawer cellsDraw;

        TriangleCells triangleCells;
        TriangleCellsDrawer triangleDrawer;

        List<object[]> action;

        public ResearchNAngleForm()
        {
            InitializeComponent();
            fixRadioButton4_CheckedChanged(null, null);
        }

        ////////////////// Создание исследования //////////////////
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
        }
        ////////////////// Конец создания исследования //////////////////

        ////////////////// Наложение действий //////////////////
        private void bodyPartsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            research.BodyParts_Select(bodyPartsComboBox.SelectedIndex);
        }

        private void acceptButton4_Click(object sender, EventArgs e)
        {
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
                }
                else if (act[0].Equals("force"))
                {
                    logTextBox.Text += "На сторону " + act[1] + " будет приложена " + act[2].ToString() + " сила";
                    logTextBox.Text += Environment.NewLine;
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
            }
        }

        private void clearAllActions_Click(object sender, EventArgs e)
        {
            action = null; action = new List<object[]>();
            logTextBox.Clear();
        }
        ////////////////// Конец наложения действий //////////////////

        ////////////////// Исследование //////////////////
        private void startResearch4_Click(object sender, EventArgs e)
        {
            NAngleForm owner;
            try { owner = (NAngleForm)this.Owner; }
            catch { MessageBox.Show("Ошибка получения матеинской формы"); return; }

            FreeClass.sldManager.swModel.ClearSelection2(true);

            try { FreeClass.cells.deleteCells(); }
            catch { }

            if (!owner.CheckLoop())
            {
                MessageBox.Show("Ошибка: На материнской форме не выбрана функция циклического построения");
                return;
            }

            int angle = owner.GetDeflection();

            if ((owner.GetAngles() == 3)) { triangleResearch(owner); return; }
            else if (owner.GetAngles() >= 91)
            {
                cellsDraw = new CircleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, angle);
            }
            else
            {
                cellsDraw = new NAngleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, angle);
            }
            dataGridView1.RowCount = 2; withoutIterationResearch();

            int start, end, step;
            start = Convert.ToInt16(owner.GetStartPoint());
            end = Convert.ToInt16(owner.GetEndPoint());
            step = Convert.ToInt16(owner.GetStep());
            double partOfVolume = Convert.ToDouble(owner.GetVolume());

            for (int i = start, j = 2; i <= end; i = i + step, j++)
            {
                dataGridView1.RowCount = j;

                //рисуем ячейки
                if (owner.GetAngles() >= 91)
                {
                    cells = new CircleCells(FreeClass.body);
                }
                else
                {
                    cells = new NAngleCells(FreeClass.body);
                    cells.SetAnglesN(owner.GetAngles());
                }

                cells.SetAccuracy(Convert.ToInt16(owner.GetAccuracy()));
                cells.SetColumnsNumber(i); cells.SetRowsNumber(i);
                cells.SetCellsHeight(owner.GetHeight());
                cells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                cells.Calculation();

                if (!cells.isAvailable())
                {
                    string reason = "Степень - " + i + " " + writeResults();
                    DialogResult dialogResult = MessageBox.Show("Не было найдено решение для условий - " + reason +
                        Environment.NewLine + "Попробовать следущий шаг? (В противном случае, вычисления будут приостановлены)",
                        "Предупреждение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) { continue; }
                    else if (dialogResult == DialogResult.No) { break; }
                }

                dataGridView1.Rows[j - 1].Cells[0].Value = cells.GetRowsNumber() * cells.GetColumnsNumber();

                try
                {
                    ResearchActions(cellsDraw, i, j);
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно построить сетку");
                    return;
                }


                dataGridView1.Rows[j - 1].Cells[3].Value = Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[1].Value) -
                     Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value); // Напряжение
                dataGridView1.Rows[j - 1].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value) * 100 /
                    Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[1].Value); // %

                dataGridView1.Rows[j - 1].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[2].Value) -
                    Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value); // Деформация
                dataGridView1.Rows[j - 1].Cells[6].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value) * 100 /
                    Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[2].Value); // %
            }

            //На случай, если нужно будет поменять условия циклического построения
            //чтобы приложение не обращалось по нулевой ссылке
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
        }

        private void ResearchActions(AbstractNAngleDrawer cellsDraw, int i, int j)
        {
            //создаём исследование
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();

            cellsDraw.SetCells(cells); cellsDraw.drawCells();

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

            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();

            research.CreateMesh();

            research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();

            dataGridView1.Rows[j - 1].Cells[1].Value = stress; // Деформация
            dataGridView1.Rows[j - 1].Cells[2].Value = displacement; // Смещение

            logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Итерация: " + i.ToString(); logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Напряжение(ksi): " + stress.ToString(); logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Смещение(mk): " + displacement.ToString(); logTextBox.Text += Environment.NewLine;

            // задержка
            //Thread.Sleep(2500);

            // Очищаем
            research.deleteStudy(); research = null;
            FreeClass.sldManager.swModel.ClearSelection2(true);

            cellsDraw.deleteCells();
        }

        private void triangleResearch(NAngleForm owner)
        {
            triangleDrawer = new TriangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);

            dataGridView1.RowCount = 2;
            withoutIterationResearch();

            int start, end, step;
            start = Convert.ToInt16(owner.GetStartPoint());
            end = Convert.ToInt16(owner.GetEndPoint());
            step = Convert.ToInt16(owner.GetStep());
            double partOfVolume = Convert.ToDouble(owner.GetVolume());

            for (int i = start, j = 2; i <= end; i = i + step, j++)
            {
                dataGridView1.RowCount = j;
                triangleCells = new TriangleCells(FreeClass.body);

                triangleCells.SetAccuracy(Convert.ToInt16(owner.GetAccuracy()));
                triangleCells.SetColumnsNumber(i); triangleCells.SetRowsNumber(i);
                triangleCells.SetCellsHeight(owner.GetHeight());
                triangleCells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                triangleCells.Calculation();

                if (!triangleCells.isAvailable())
                {
                    string reason = "Степень - " + i + " " + writeResults(triangleCells);
                    DialogResult dialogResult = MessageBox.Show("Не было найдено решение для условий - " + reason +
                        Environment.NewLine + "Попробовать следущий шаг? (В противном случае, вычисления будут приостановлены)",
                        "Предупреждение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) { continue; }
                    else if (dialogResult == DialogResult.No) { break; }
                }

                dataGridView1.Rows[j - 1].Cells[0].Value = triangleCells.GetRowsNumber() * triangleCells.GetColumnsNumber();

                try { ResearchActions(triangleDrawer, i, j); }
                catch (Exception) { MessageBox.Show("Невозможно построить сетку"); return; }

                dataGridView1.Rows[j - 1].Cells[3].Value = Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[1].Value) -
                    Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value); // Напряжение
                dataGridView1.Rows[j - 1].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value) * 100 /
                    Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[1].Value); // %

                dataGridView1.Rows[j - 1].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[2].Value) -
                    Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value); // Деформация
                dataGridView1.Rows[j - 1].Cells[6].Value = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value) * 100 /
                    Convert.ToDouble(dataGridView1.Rows[j - 1].Cells[2].Value); // %
            }

            //На случай, если нужно будет поменять условия циклического построения
            //чтобы приложение не обращалось по нулевой ссылке
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
        }

        private void ResearchActions(TriangleCellsDrawer cellsDraw, int i, int j)
        {
            //создаём исследование
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();

            cellsDraw.SetCells(triangleCells); cellsDraw.drawCells();

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

            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();

            research.CreateMesh(); research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();

            dataGridView1.Rows[j - 1].Cells[1].Value = stress; // Деформация
            dataGridView1.Rows[j - 1].Cells[2].Value = displacement; // Смещение

            logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Итерация: " + i.ToString(); logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Напряжение(ksi): " + stress.ToString(); logTextBox.Text += Environment.NewLine;
            logTextBox.Text += "Смещение(mk): " + displacement.ToString(); logTextBox.Text += Environment.NewLine;

            // задержка
            //Thread.Sleep(2500);

            // Очищаем
            research.deleteStudy(); research = null;
            FreeClass.sldManager.swModel.ClearSelection2(true);

            cellsDraw.deleteCells();
        }

        private void withoutIterationResearch()
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

            research.CreateMesh(); research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();
            dataGridView1.Rows[0].Cells[0].Value = 0;
            dataGridView1.Rows[0].Cells[1].Value = stress; // Деформация
            dataGridView1.Rows[0].Cells[2].Value = displacement; // Смещение

            object[] buff1 = new object[2]; //[кол-во ячеек, напряжение]
            buff1[0] = 0; buff1[1] = stress;
            //dataStress.Add(buff1);

            object[] buff2 = new object[2]; //[кол-во ячеек, перемещение]
            buff2[0] = 0; buff2[1] = displacement;

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
            result += "Коэффицент соотношения площадей - " + cells.GetRelations(); result += Environment.NewLine;
            result += "Максимальное соотношение - " + NAngleCells.maxCoef; result += Environment.NewLine;
            result += "Доступность построения - " + cells.isAvailable(); result += Environment.NewLine;
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
    }
}