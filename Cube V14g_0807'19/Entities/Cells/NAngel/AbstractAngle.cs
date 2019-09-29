using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11
{
    abstract class AbstractAngle
    {
        protected BodyParametrs body;

        protected int accuracy = 7; // количество знаков после запятой при рисовании и отображении данных
        protected int columns; // количество столбцов n
        protected int rows; // количество строк m

        protected double side = 0; // размер стороны n-угольника
        protected int angleNumb = 0; // количество углов n-угольника
        protected double cellHeight; // Высота ячейки
        protected double local; // сторона локали (локаль - квадрат, в котором будет размещаться одна ячейка)

        protected double SCells; // площадь всех ячеек
        protected double S1; // площадь 1 ячейки
        protected double Radius; // радиус окружности, в которую впишется n-угольник

        protected bool availability = false;

        protected double VCells; // Необходимый объём

        protected AbstractAngle(BodyParametrs body) { this.body = body; }

        public virtual void Calculation() { }

        public virtual bool trySizeCondition()
        {
            local = body.GetWidth() / columns;
            double buff = body.GetLenght() / rows;
            return local == buff ? true : false;
        }

        public double GetRadius() { return Radius; }
        public double GetSide() { return side; }
        public double GetSCells() { return SCells; }
        public double GetS1() { return S1; }

        public double GetLocal() { return local; }
        public void SetCellsV(double V) { VCells = V; }
        public double GetCellsV() { return VCells; }

        public int GetColumnsNumber() { return columns; }
        public void SetColumnsNumber(int n) { columns = n; }
        public int GetRowsNumber() { return rows; }
        public void SetRowsNumber(int m) { rows = m; }

        public double GetCellsHeight() { return Math.Round(cellHeight, accuracy); }
        public void SetCellsHeight(double h) { cellHeight = h; }

        public void SetAccuracy(int accuracy) { this.accuracy = accuracy; }
        public int GetAccuracy() { return accuracy; }

        public virtual int GetAnglesN() { return angleNumb; }
        public void SetAnglesN(int n) { angleNumb = n; }

        public bool isAvailable() { return availability; }
    }
}
