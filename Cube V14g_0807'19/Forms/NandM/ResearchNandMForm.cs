using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Cube_V11
{
    public partial class ResearchNandMFForm : Form
    {
        Research research;
        NandMRectangleCells cells;
        NandMRectangleCellsDrawer cellsDraw;

        List<object[]> action;

        public ResearchNandMFForm()
        {
            InitializeComponent();
            fixRadioButton4_CheckedChanged(null, null);
            //this.cells = cells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FreeClass.sldManager == null) {
                MessageBox.Show("Ошибка: SolidWorks не был подключен");
                return;
            }
        
            if(FreeClass.bodyDrawer == null)
            {
                MessageBox.Show("Ошибка: тело не было создано");
                return;
            }

            try { research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
                //research.CreateStudy();
            } catch {
                MessageBox.Show("Ошибка: модуль исследования не подключен");
                return;
            }
            bodyPartsComboBox.Items.Clear();
            action = new List<object[]>();

            for (int i = 0; i < FreeClass.bodyDrawer.GetFacesArray().Length; i++){
                bodyPartsComboBox.Items.Add(String.Join(", ", FreeClass.bodyDrawer.GetFacesArray().GetValue(i).ToString()));
            }

            groupBox1.Visible = true;
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
                    " будет зафиксирована";
                logTextBox.Text += Environment.NewLine;

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

        private void clearAllActions_Click(object sender, EventArgs e)
        {
            action = null; action = new List<object[]>();
            logTextBox.Clear();
        }

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

        private void bodyPartsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            research.BodyParts_Select(bodyPartsComboBox.SelectedIndex);
        }

        private void startResearch4_Click(object sender, EventArgs e)
        {
            NandMForm owner;
            try { owner = (NandMForm)this.Owner; }
            catch { MessageBox.Show("Ошибка получения матеинской формы"); return; }

            //if (true) { return; }

            FreeClass.sldManager.swModel.ClearSelection2(true);

            try { FreeClass.cells.deleteCells(); }
            catch { }

            if (!owner.CheckLoop()) {
                MessageBox.Show("Ошибка: На материнской форме не выбрана функция циклического построения");
                return;
            }

            cellsDraw = new 
                NandMRectangleCellsDrawer(FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer);

            /*
            switch (answer) {
                case "2n": {  break; }
                case "maxtrix": break;
                case "free": break;
                default: break;
            }*/

            dataGridView1.RowCount = 1;

            if (owner.GetMethod() == "matrix"){
                int start, end, step;
                start = Convert.ToInt16(owner.GetStartPoint());
                end = Convert.ToInt16(owner.GetEndPoint());
                step = Convert.ToInt16(owner.GetStep());
                double partOfVolume = Convert.ToDouble(owner.GetVolume());

                //withoutIterationResearch();

                for (int i = start, j = 1; i <= end; i = i + step, j++)
                {
                    dataGridView1.RowCount = j;

                    //рисуем ячейки
                    cells = new NandMRectangleCells(FreeClass.body);

                    cells.SetAccuracy(Convert.ToInt16(owner.GetAccuracy()));
                    cells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                    cells.SetColumnsNumber(i); cells.SetRowsNumber(i);
                    dataGridView1.Rows[j-1].Cells[0].Value = cells.GetRowsNumber()*cells.GetColumnsNumber();

                    ResearchActions(cellsDraw, i, j);
                }
            }
            else if (owner.GetMethod() == "2n")
            {
                int start, end, step;
                start = Convert.ToInt16(owner.GetStartPoint());
                end = Convert.ToInt16(owner.GetEndPoint());
                step = Convert.ToInt16(owner.GetStep());
                double partOfVolume = Convert.ToDouble(owner.GetVolume());

                //withoutIterationResearch();

                for (int i = start, j = 1; i <= end; i = i + step, j++)
                {
                    dataGridView1.RowCount = j;

                    //рисуем ячейки
                    cells = new NandMRectangleCells(FreeClass.body);

                    cells.SetAccuracy(Convert.ToInt16(owner.GetAccuracy()));
                    cells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                    if (i % 2 == 0) {
                        double buff = Math.Sqrt(Math.Pow(2, i));
                        cells.SetColumnsNumber(Convert.ToInt16(buff));
                        cells.SetRowsNumber(Convert.ToInt16(buff));
                    } else {
                        double buff = Math.Sqrt(Math.Pow(2, i - 1));
                        cells.SetColumnsNumber(Convert.ToInt16(buff) * 2);
                        cells.SetRowsNumber(Convert.ToInt16(buff));
                    }

                    dataGridView1.Rows[j - 1].Cells[0].Value = cells.GetRowsNumber() * cells.GetColumnsNumber();

                    ResearchActions(cellsDraw, i, j);
                }
            }
            else if (owner.GetMethod() == "free")
            {
                int start1, start2, end, step;
                start1 = Convert.ToInt16(owner.GetStartPoint());
                start2 = Convert.ToInt16(owner.GetEndPoint());
                end = Convert.ToInt16(owner.GetMiddlePoint());
                step = Convert.ToInt16(owner.GetStep());
                double partOfVolume = Convert.ToDouble(owner.GetVolume());

                //withoutIterationResearch();

                for (int i = start1, j = 1; i <= end; i = i + step, j++, start2 = start2 + step) 
                {
                    dataGridView1.RowCount = j;

                    //рисуем ячейки
                    cells = new NandMRectangleCells(FreeClass.body);

                    cells.SetAccuracy(6);
                    cells.SetCellsV(FreeClass.body.GetV() * partOfVolume / 100);

                    cells.SetColumnsNumber(i); cells.SetRowsNumber(start2);
                    dataGridView1.Rows[j - 1].Cells[0].Value = cells.GetRowsNumber() * cells.GetColumnsNumber();

                    ResearchActions(cellsDraw, i, j);
                }
            }



            //На случай, если нужно будет поменять условия циклического построения
            //чтобы приложение не обращалось по нулевой ссылке
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
        }

        private void ResearchActions(NandMRectangleCellsDrawer cellsDraw, int i, int j)
        {
            //создаём исследование
            research = new Research(FreeClass.sldManager, FreeClass.bodyDrawer.GetFacesArray());
            research.CreateStudy();

            cells.Calculation();
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

            research.CreateMesh(); research.MaterialSet();
            research.RunAnalysis();

            double stress = research.GetStress(), displacement = research.GetDisplacement();

            dataGridView1.Rows[j-1].Cells[1].Value = Math.Round(stress, cells.GetAccuracy()); // Деформация равномерное
            dataGridView1.Rows[j-1].Cells[2].Value = Math.Round(displacement, cells.GetAccuracy()) + 5; // Смещение равномерное
            
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

        private void deleteResearch4_Click(object sender, EventArgs e)
        {
            if (research != null)
            {
                try { research.deleteStudy(); }
                catch { } research = null;
            }

            try { cellsDraw.deleteCells(); }
            catch { }
        }
    }
}
