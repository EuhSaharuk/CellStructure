using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube_V11
{
    class NAngleCells : AbstractRelationAngle
    {
        public NAngleCells(BodyParametrs body) : base(body) {  }

        /*   public override void Calculation() {
               if (!trySizeCondition()) { return; }

               SCells = VCells / cellHeight;
               S1 = SCells / (columns * rows);

               double rad = (180 / angleNumb) * Math.PI / 180;
               side = Math.Sqrt(4 * S1 / (angleNumb * (1 / Math.Tan(rad))));
               //text.Text += "Размер стороны - " + side + Environment.NewLine;
               rad = 180 / angleNumb * Math.PI / 180;
               Radius = side / (2 * Math.Sin(rad));
               //text.Text += "Радиус окружности - " + Radius + Environment.NewLine;

               k_x = (body.GetWidth() - (2 * Radius * rows)) / (rows + 1);
               k_y = (body.GetLenght() - (2 * Radius * columns)) / (columns + 1);

               relation = (Math.Pow(Radius, 2) * Math.PI) / (local * local); 
               //Stext.Text += "Отношение площадей окружности к локали - " + buff + Environment.NewLine;
               availability = relation < maxCoef ? true : false;
           }
           */

        public override void Calculation()
        {
            if (!trySizeCondition()) { return; }

            SCells = VCells / cellHeight;
            S1 = SCells / (columns * rows);

            double rad = (180 / angleNumb) * Math.PI / 180;
            side = Math.Sqrt(4 * S1 / (angleNumb * (1 / Math.Tan(rad))));
            //text.Text += "Размер стороны - " + side + Environment.NewLine;
            rad = 180 / angleNumb * Math.PI / 180;
            Radius = side / (2 * Math.Sin(rad));
            //text.Text += "Радиус окружности - " + Radius + Environment.NewLine;

            k_x = (body.GetWidth() - (2 * Radius * rows)) / (rows + 1);
            k_y = (body.GetLenght() - (2 * Radius * columns)) / (columns + 1);

            relation = (Math.Pow(Radius, 2) * Math.PI) / (local * local);
            //Stext.Text += "Отношение площадей окружности к локали - " + buff + Environment.NewLine;
            availability = relation < maxCoef ? true : false;
        }

        public List<Point> Points { get; private set; }
    }
}
