using Cube_V11.Forms;
using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bodyParametrsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BodyConfigForm form = new BodyConfigForm();
            form.MdiParent = this;
            form.Show();
        }

        private void rowColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matrixConstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NandMForm form = new NandMForm();
            form.MdiParent = this;
            form.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NAngleForm form = new NAngleForm();
            form.MdiParent = this;
            form.Show();
        }

        private void nугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NAngleEmprovedForm form = new NAngleEmprovedForm();
            form.MdiParent = this;
            form.Show();
        }

        private void ромбоподобныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RhombusForm();
            form.MdiParent = this;
            form.Show();
        }

        private void pythomToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (FreeClass.body == null)
            {
                MessageBox.Show("Тело не было задано. Невозможно произвести вычисления");
                return;
            }
            string parameters = FreeClass.body.GetWidth().ToString() + " " + FreeClass.body.GetLenght().ToString() + " " + FreeClass.body.GetHeight().ToString();
            //Process p = Process.Start("123.py", "/C one 2 3");
            //System.Diagnostics.Process.Start("cmd.exe", "/")
            Process p = Process.Start("..\\..\\..\\application.exe", parameters);
            //Process p = Process.Start("cmd.exe", "/C python ..\\..\\..\\application.py " + parameters);
            //System.Diagnostics.Process.Start("edge.exe", "tut.by");
            //Process p = Process.Start(startInfo);
            //System.Diagnostics.Process.Start("123.py", "1 2 3");
            Thread.Sleep(500);
            SetParent(p.MainWindowHandle, this.Handle);
            
            
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}
