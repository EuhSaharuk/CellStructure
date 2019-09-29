using System;
using System.Collections.Generic;
using System.Linq;
using SolidWorks.Interop.sldworks;
using System.Windows.Forms;

namespace Cube_V11
{
    class NAngleCellsDrawer : AbstractNAngleDrawer
    {
        public NAngleCellsDrawer(SLDManager app, BodyParametrs body, BodyDrawer bodyDrawer, double angle)
            : base(app, body, bodyDrawer, angle) { }

        /*override*/
        override public void drawCells()
        {
            //получить грани бобышки
            faces = bodyDrawer.GetFacesArray();
            //выбрать вторую (вверх бобышки)
            var ent = faces.GetValue(1) as Entity;
            //выбрать верхнюю грань
            ent.Select(true);
            //добавить на неё эскиз
            swSketchManager.InsertSketch(false);

            // Получаем объект эскиза, на котором будем рисовать
            activeSketch = application.swModel.GetActiveSketch2();

            //cells
            // Определяем положение центра верхней левой ячейки относительно центра плоскости (0, 0, 0)
            double x_current = ((-body.GetWidth()) / 2.0) + (cells.GetKX() + cells.GetRadius());
            double y_current = (body.GetLenght() / 2.0) - (cells.GetKY() + cells.GetRadius());
            // Определяем положение самого верхнего угла ячейки
            double x_end = x_current; //((-body.GetWidth()) / 2.0) + (cellObj.GetK() + cellObj.GetCellsWidth());
            double y_end = y_current + cells.GetRadius(); //(body.GetHeight() / 2.0) - (cellObj.GetK() + cellObj.GetCellsLenght());
            //MessageBox.Show(x_end + " " + y_end);
            //Запоминаем позицию для дальнейшего использования
            double leftHoleCenterX = x_current, leftHoleCenterY = y_current;

            //Сдвиг, расстояние от центра одной ячейки до центра другой по координате Х
            double delta = cells.GetRadius() * 2 + cells.GetKX();

            // Вычисляем угловой сдвиг (наклон) (на сколько нужно сдвинуть конечные координаты 
            // чтобы фигура была под определённым углом относительно верхнего угла)
            double angle_y = cells.GetRadius() - (cells.GetRadius() * Math.Cos(deflection_Angle));
            double angle_x = cells.GetRadius() * Math.Sin(deflection_Angle);

            //Определяем количество ячеек в зависимости от итерации
            int row = cells.GetRowsNumber(), collumn = cells.GetColumnsNumber();

            for (int i = 0; i < row; i++)
            {
                y_end -= angle_y; x_end += angle_x;
                //Рисуем первую в ряду ячейку
                application.swModel.SketchManager.CreatePolygon(x_current, y_current, 0, x_end, y_end, 0, cells.GetAnglesN(), false);
                //Рисуем остальные
                for (int j = 1; j < collumn; j++)
                {
                    x_current = x_current + delta;
                    x_end = x_end + delta;
                    application.swModel.SketchManager.CreatePolygon(x_current, y_current, 0, x_end, y_end, 0, cells.GetAnglesN(), false);
                }
                //Возвращаемся к первой ячейке
                x_current = leftHoleCenterX;
                //Сдвигаемся по координате Y
                y_current = leftHoleCenterY - (cells.GetRadius() * 2 + cells.GetKY());
                //Запоминаем координаты
                leftHoleCenterX = x_current; leftHoleCenterY = y_current;
                //Определяем положение правого нижнего угла ячейки
                x_end = x_current;
                y_end = y_current + cells.GetRadius();
            }

            //Получаем объект "вырез"
            cut = featureCut(cells.GetCellsHeight());
            application.swModel.ClearSelection();
        }
    }
}
