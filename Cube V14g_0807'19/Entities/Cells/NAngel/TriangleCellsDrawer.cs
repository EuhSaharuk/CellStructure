using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;

namespace Cube_V11
{
    class TriangleCellsDrawer : CellsDrawer {
        protected SketchManager swSketchManager;
        protected SelectionMgr swSelMgr;

        protected TriangleCells cells;
        protected BodyParametrs body;
        protected BodyDrawer bodyDrawer;
        protected Array faces; // Список граней тела

        public TriangleCellsDrawer(SLDManager app, BodyParametrs body, BodyDrawer bodyDrawer)
        {
            application = app;
            this.body = body;
            this.bodyDrawer = bodyDrawer;
            // Получает ISketchManager объект, который позволяет получить доступ к процедурам эскиза
            swSketchManager = application.swModel.SketchManager;
            // Получает ISelectionMgr объект для данного документа, что делает выбранный объект доступным
            swSelMgr = (SelectionMgr)application.swModel.SelectionManager;
        }

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
            double x_current = ((-body.GetWidth()) / 2.0) + (cells.GetKX() + (cells.GetSide() / 2));
            double y_current = (body.GetLenght() / 2.0) - (cells.GetKY() + cells.GetRadius());// - (cells.GetKY() + cells.GetTriangleHeight());

            // Определяем положение самого верхнего угла ячейки
            double x_end = x_current;
            double y_end = y_current + cells.GetRadius(); 
            //MessageBox.Show(x_end + " " + y_end);
            //Запоминаем позицию для дальнейшего использования
            double leftHoleCenterX = x_current, leftHoleCenterY = y_current;

            //Сдвиг, расстояние от центра одной ячейки до центра другой по координате Х
            double delta = cells.GetSide() + cells.GetKX();

            //Определяем количество ячеек в зависимости от итерации
            int row = cells.GetRowsNumber(), collumn = cells.GetColumnsNumber();

            for (int i = 0; i < row; i++)
            {
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
                y_current = leftHoleCenterY - (cells.GetTriangleHeight() + cells.GetKY());
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

        public void SetCells(TriangleCells cells) { this.cells = cells; }


    }
}
