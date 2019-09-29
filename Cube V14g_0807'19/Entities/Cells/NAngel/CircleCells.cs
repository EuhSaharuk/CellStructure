using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11
{
    class CircleCells : AbstractRelationAngle {
        public CircleCells(BodyParametrs body) : base(body) { angleNumb = 0; }

        public override void Calculation()
        {
            if (!trySizeCondition()) { return; }

            SCells = VCells / cellHeight;
            S1 = SCells / (columns * rows);

            Radius = Math.Sqrt((S1/Math.PI));
            //text.Text += "Радиус окружности - " + Radius + Environment.NewLine;

            relation = (Math.Pow(Radius, 2) * Math.PI) / (local * local);
            //Stext.Text += "Отношение площадей окружности к локали - " + buff + Environment.NewLine;
            availability = relation < maxCoef ? true : false;

            k_x = (body.GetWidth() - (Radius*2 * rows)) / (rows + 1);
            k_y = (body.GetLenght() - (Radius*2 * columns)) / (columns + 1);
        }

    }
}
