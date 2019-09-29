using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube_V11.Forms
{
    public partial class RhombusForm : Form
    {
        public RhombusForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = double.Parse(textBox1.Text);
            double w = double.Parse(textBox2.Text);
            double cols = double.Parse(textBox3.Text);

            new RhombusDrawer(
                h, w, cols,
                FreeClass.sldManager, FreeClass.body, FreeClass.bodyDrawer, 0
            ).drawCells();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double h = double.Parse(textBox1.Text);
            double w = double.Parse(textBox2.Text);
            double cols = double.Parse(textBox3.Text);

            
            using (Graphics g = pictureBox1.CreateGraphics()) // Use the CreateGraphics method to create a graphic and draw on the picture box. Use using in order to free the graphics resources.
            {
                g.Clear(SystemColors.Control);
                g.Clip = new Region(new Rectangle(10, 10, 150, 150));
               
                var stepper = new PointStepper();
                stepper.Points = RhombusDrawer.Rhombus(
                    new Point
                    {
                        X = g.ClipBounds.Height / 2,
                        Y = g.ClipBounds.Height / 2
                    },
                    g.ClipBounds.Height / 2, h, w, cols);
                ;
                Pen selPen = new Pen(Color.Black, 1);
                stepper.Step((f, t) => g.DrawLine(selPen, (float)f.X, (float)f.Y, (float)t.X, (float)t.Y));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
