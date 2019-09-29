using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Cube_V11
{
    class RectangleCells : AbstractAngle
    {
        //BodyParametrs body;

        private double k; // расстояние между рёбрами тела и сторонами отверстий
        //private int accuracy = 7; // количество знаков после запятой при рисовании и отображении данных

        //Cells
        //private double VCells; // Необходимый объём
        private double VCellsFactical; // Фактический объём
        private double cellWidth; // Ширина
        private double cellLenght; // Длина
        //private double cellHeight; // Высота

        //private int columns; // количество столбцов n
        //private int rows; // количество строк m

        //private List<Complex> rootsList;

        public RectangleCells(BodyParametrs body) : base(body) { angleNumb = 4; }

        public override void Calculation()
        {
            SCells = VCells / cellHeight;
            S1 = SCells / (columns * rows);

            double A, B, C;
            //Вычисляем элементы квадратного уравнения
            //Ax^2 + Bx + C = 0   
            A = (columns + 1) * (rows + 1);
            B = body.GetLenght() * (rows + 1) + body.GetWidth() * (columns + 1); B *= (-1);
            C = body.GetLenght() * body.GetWidth() - S1 * columns * rows;

            if(GetRoot(A, B, C) == 1) { availability = true; }
            else { availability = false; }
        }

        private double GetRoot(double a, double b, double c)
        {
            double D = b * b - 4 * a * c;
            if (D < 0) { return 1; }
            else if (D == 0)
            {
                k = (-1) * b / (2 * a); //x2 = x1;

                cellLenght = (body.GetLenght() - k * (columns + 1)) / columns;
                cellWidth = (body.GetWidth() - k * (rows + 1)) / rows;

                if (Comporation(cellLenght * cellWidth, S1)) { return 1; }
                else { return -1; }
            }
            else
            {
                // x1
                k = ((-1) * b + Math.Sqrt(D)) / (2 * a);
                cellLenght = (body.GetLenght() - k * (columns + 1)) / columns;
                cellWidth = (body.GetWidth() - k * (rows + 1)) / rows;
                if (cellLenght > 0 && cellWidth > 0)
                {
                    if (Comporation(cellLenght * cellWidth, S1)) { return 1; }
                }
                // x2
                k = ((-1) * b - Math.Sqrt(D)) / (2 * a);
                cellLenght = (body.GetLenght() - k * (columns + 1)) / columns;
                cellWidth = (body.GetWidth() - k * (rows + 1)) / rows;
                if (cellLenght > 0 && cellWidth > 0) { if (Comporation(cellLenght * cellWidth, S1)) { return 1; } }
                return -1; 

            }
        }

        /// <summary>
        /// Сравнение 2 чисел при помощи изменения точности
        /// </summary>
        /// <param name="param1">Число 1</param>
        /// <param name="param2">Число 2</param>
        /// <returns>Возвращает true, если числа идентичны при определённой точности</returns>
        private bool Comporation(double param1, double param2)
        {
            for (int i = accuracy; i > 1; i--)
            {
                if (Math.Round(param1, i).CompareTo(Math.Round(param2, i)) == 0) { return true; }
            }
            return false;
        }

        public double GetK() { return Math.Round(k, accuracy); }

        //public void SetAccuracy(int accuracy) { this.accuracy = accuracy; }
        //public int GetAccuracy() { return accuracy; }

        //public void SetCellsV(double V) { VCells = V; }
        //public double GetCellsV() { return VCells; }

        public double GetCellsWidth() { return Math.Round(cellWidth, accuracy); }
        public double GetCellsLenght() { return Math.Round(cellLenght, accuracy); }
        //public double GetCellsHeight() { return Math.Round(cellHeight, accuracy); }

        //public int GetColumnsNumber() { return columns; }
        //public void SetColumnsNumber(int n) { columns = n; }
        //public int GetRowsNumber() { return rows; }
        //public void SetRowsNumber(int m) { rows = m; }

        public double GetVCellsFactical() { return Math.Round(VCellsFactical, accuracy); }
        private void SetVCellsFactical() { VCellsFactical = cellWidth * cellHeight * cellLenght * columns * rows; }

        //public bool isAvailable() { return k > 0 ? true : false; }
    }
}
