using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;

namespace Cube_V11
{
    public class NandMRectangleCells
    {
        BodyParametrs body;

        private double k; // расстояние между рёбрами тела и сторонами отверстий
        private int accuracy = 7; // количество знаков после запятой при рисовании и отображении данных

        //Cells
        private double VCells; // Необходимый объём
        private double VCellsFactical; // Фактический объём
        private double cellWidth; // Ширина
        private double cellLenght; // Длина
        private double cellHeight; // Высота

        private int columns; // количество столбцов n
        private int rows; // количество строк m

        private List<Complex> rootsList;

        public NandMRectangleCells(BodyParametrs body)
        {
            this.body = body;
        }

        public void Calculation()
        {
            double A, B, C;
            //Вычисляем элементы кубического уравнения
            //x^3 + Ax^2 + Bx + C = 0   
            A = body.GetWidth() * (columns + 1) + body.GetLenght() * (rows + 1) + body.GetHeight() * (columns + 1) * (rows + 1);
            A /= (columns + 1) * (rows + 1); A *= (-1);
            B = body.GetWidth() * body.GetLenght() + body.GetWidth() * body.GetHeight() * (rows + 1) + body.GetLenght() * body.GetHeight() * (columns + 1);
            B /= (columns + 1) * (rows + 1);
            C = VCells - body.GetV(); C /= (columns + 1) * (rows + 1);

            //Получаем корни уравнения
            rootsList = GetRoots(A, B, C);
            k = -1.0;

            foreach (Complex element in rootsList)
            {
                //MessageBox.Show(element.Real.ToString());
                if (element.Real < 0)
                {
                    continue;
                }
                if (element.Real == -1.0)
                {
                    k = -1.0;
                    break;
                }

                k = element.Real;
                double buff1, buff2, buff3;

                //Вычисляем предположительные значения сторон отверстия
                SetCellsWidth(); SetCellsHeight(); SetCellsLenght();
                if (cellWidth < 0 || cellHeight < 0 || cellLenght < 0)
                {
                    continue;
                }
                buff1 = columns * cellWidth + (columns + 1) * k;
                buff2 = rows * cellLenght + (rows + 1) * k;
                buff3 = k + cellHeight;

                if (Comporation(buff1, body.GetWidth()) && Comporation(buff2, body.GetHeight())
                    && Comporation(buff3, body.GetLenght()))
                {
                    SetVCellsFactical();
                    return;
                }
                else { k = -1.0; }

            }

        }

        /// <summary>
        /// Находит корни кубического уравнения
        /// </summary>
        /// <param name="a">Значение при x^2</param>
        /// <param name="b">Значение при x</param>
        /// <param name="c">Свободный член</param>
        /// <returns>Спиок найденных корней</returns>
        private /*void*/ List<Complex> GetRoots(double a, double b, double c)
        {
            var q = (Math.Pow(a, 2) - 3 * b) / 9;
            var r = (2 * Math.Pow(a, 3) - 9 * a * b + 27 * c) / 54;

            if (Math.Pow(r, 2) < Math.Pow(q, 3))
            {
                var t = Math.Acos(r / Math.Sqrt(Math.Pow(q, 3))) / 3;
                var x1 = -2 * Math.Sqrt(q) * Math.Cos(t) - a / 3;
                var x2 = -2 * Math.Sqrt(q) * Math.Cos(t + (2 * Math.PI / 3)) - a / 3;
                var x3 = -2 * Math.Sqrt(q) * Math.Cos(t - (2 * Math.PI / 3)) - a / 3;
                return new List<Complex> { x1, x2, x3 };
            }
            else
            {
                var A = -Math.Sign(r) * Math.Pow(Math.Abs(r) + Math.Sqrt(Math.Pow(r, 2) - Math.Pow(q, 3)), (1.0 / 3.0));
                var B = (A == 0) ? 0.0 : q / A;

                var x1 = (A + B) - a / 3;
                return new List<Complex> { x1 };
            }
        }

        private void SetCellsWidth()
        {
            cellWidth = body.GetWidth() - (columns + 1) * k;
            cellWidth /= columns;
        }

        private void SetCellsLenght()
        {
            cellLenght = body.GetLenght() - (rows + 1) * k;
            cellLenght /= rows;
        }

        private void SetCellsHeight()
        {                        
            cellHeight = body.GetHeight() - k;
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

        public void SetAccuracy(int accuracy) { this.accuracy = accuracy; }
        public int GetAccuracy() { return accuracy; }

        public void SetCellsV(double V) { VCells = V; }
        public double GetCellsV() { return VCells; }

        public double GetCellsWidth() { return Math.Round(cellWidth, accuracy); }
        public double GetCellsLenght() { return Math.Round(cellLenght, accuracy); }
        public double GetCellsHeight() { return Math.Round(cellHeight, accuracy); }

        public int GetColumnsNumber() { return columns; }
        public void SetColumnsNumber(int n) { columns  = n; }
        public int GetRowsNumber() { return rows; }
        public void SetRowsNumber(int m) { rows = m; }

        public double GetVCellsFactical() { return Math.Round(VCellsFactical, accuracy); }
        private void SetVCellsFactical() { VCellsFactical = cellWidth * cellHeight * cellLenght * columns * rows; }

        public bool isAvailable() { return k > 0 ? true : false; }
    }
}
