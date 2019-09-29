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
    public partial class BodyConfigForm : Form
    {
        public BodyConfigForm()
        {
            InitializeComponent();
        }

        private void BodyConfigForm_Load(object sender, EventArgs e)
        {
            cubeRadioButton_CheckedChanged(null, null);
        }

        private void cubeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bodyHeightText.Visible = false; label2.Visible = false;
            bodyLenghtText.Visible = false; label3.Visible = false;
            label4.Visible = false;
        }

        private void paralRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bodyHeightText.Visible = true; label2.Visible = true;
            bodyLenghtText.Visible = true; label3.Visible = true;
            label4.Visible = true;
        }

        private void buildBody_Click(object sender, EventArgs e)
        {
            //рисование тела
            double bodyWidth, bodyHeight, bodyLenght;

            if (cubeRadioButton.Checked)
            {
                bodyWidth = Convert.ToDouble(bodyWidthText.Text.Replace('.', ','));
                bodyHeight = bodyWidth; bodyLenght = bodyWidth;
            }
            else
            {
                bodyWidth = Convert.ToDouble(bodyWidthText.Text.Replace('.', ','));
                bodyHeight = Convert.ToDouble(bodyHeightText.Text.Replace('.', ','));
                bodyLenght = Convert.ToDouble(bodyLenghtText.Text.Replace('.', ','));
            }

            FreeClass.body = new BodyParametrs(bodyWidth, bodyHeight, bodyLenght);
            
            if (checkBox1.Checked)
            {
                FreeClass.sldManager = new SLDManager();
                // Проверка, включен ли Solid
                if (FreeClass.sldManager.GetSolidworks())
                {
                    FreeClass.bodyDrawer = new BodyDrawer(FreeClass.sldManager, FreeClass.body);
                    FreeClass.bodyDrawer.drawBody();
                }
            }
        }

        private void rebuildBody_Click(object sender, EventArgs e)
        {
            deleteBody_Click(null, null);
            buildBody_Click(null, null);
        }

        private void deleteBody_Click(object sender, EventArgs e)
        {
            if (FreeClass.cells != null) {
                FreeClass.cells.deleteCells();
                FreeClass.cells = null;
            }

            //удаление тела
            try{ FreeClass.bodyDrawer.deleteBody(); }
            catch { }
            FreeClass.bodyDrawer = null; FreeClass.body = null;
        }

        
    }
}
