using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11
{
    class TriangleCells : AbstractAngle
    {
        private double triangleHeight;

        private double k_x;
        private double k_y;

        public TriangleCells(BodyParametrs body) : base(body) { angleNumb = 3; }

        public override void Calculation()
        {
            if (!trySizeCondition()) { return; }

            SCells = VCells / cellHeight;
            S1 = SCells / (columns * rows);
            side = Math.Sqrt(S1 * 4 / Math.Sqrt(3));

            if(side > local) { availability = false; return; }
            triangleHeight = side * Math.Sqrt(3) / 2;
            Radius = side * Math.Sqrt(3) / 3;

            k_x = (body.GetWidth() - (side * rows)) / (rows + 1);
            k_y = (body.GetLenght() - (triangleHeight * columns)) / (columns + 1);

            if((side * rows) + ((rows+1) * k_x) <= body.GetWidth() &&
                (triangleHeight * columns) + ((columns + 1) * k_y) <= body.GetLenght())
            {
                availability = true;
            } else { availability = false; }
        }

        public double GetKX() { return k_x; }
        public double GetKY() { return k_y; }

        public double GetTriangleHeight() { return triangleHeight; }

        public override int GetAnglesN() { return 3; }

    }
}
