using System;
using SolidWorks.Interop.sldworks;

namespace Cube_V11
{
    class RectangleCellsDrawer : CellsDrawer
    {
        private SketchManager swSketchManager;
        private SelectionMgr swSelMgr;

        RectangleCells cellObj;
        BodyParametrs body;
        BodyDrawer bodyDrawer;
        Array faces; // Список граней тела

        public RectangleCellsDrawer(SLDManager app, BodyParametrs body, BodyDrawer bodyDrawer)
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
            //Определяем положение центра верхней левой ячейки относительно центра плоскости (0, 0, 0)
            double x_current = (-body.GetWidth()) / 2.0 + (cellObj.GetK() + cellObj.GetCellsWidth() / 2.0);
            double y_current = (body.GetLenght() / 2.0) - (cellObj.GetK() + (cellObj.GetCellsLenght() / 2.0));
            //Определяем положение правого нижнего угла ячейки
            double x_end = ((-body.GetWidth()) / 2.0) + (cellObj.GetK() + cellObj.GetCellsWidth());
            double y_end = (body.GetLenght() / 2.0) - (cellObj.GetK() + cellObj.GetCellsLenght());

            //Запоминаем позицию для дальнейшего использования
            double leftHoleCenterX = x_current, leftHoleCenterY = y_current;

            //Сдвиг, расстояние от центра одной ячейки до центра другой по координате Х
            double delta = cellObj.GetCellsWidth() + cellObj.GetK();

            //Определяем количество ячеек в зависимости от итерации
            int row = cellObj.GetRowsNumber(), column = cellObj.GetColumnsNumber();

            for (int i = 0; i < row; i++)
            {
                //Рисуем первую в ряду ячейку
                application.swModel.SketchManager.CreateCenterRectangle(x_current, y_current, 0, x_end, y_end, 0);
                //Рисуем остальные
                for (int j = 1; j < column; j++)
                {
                    x_current = x_current + delta;
                    x_end = x_end + delta;
                    application.swModel.SketchManager.CreateCenterRectangle(x_current, y_current, 0, x_end, y_end, 0);
                }
                //Возвращаемся к первой ячейке
                x_current = leftHoleCenterX;
                //Сдвигаемся по координате Y
                y_current = leftHoleCenterY - (cellObj.GetK() + cellObj.GetCellsLenght());
                //Запоминаем координаты
                leftHoleCenterX = x_current; leftHoleCenterY = y_current;
                //Определяем положение правого нижнего угла ячейки
                x_end = x_current + (cellObj.GetCellsWidth() / 2.0);
                y_end = y_current + (cellObj.GetCellsLenght() / 2.0);
            }

            //Получаем объект "вырез"
            cut = featureCut(cellObj.GetCellsHeight());
            application.swModel.ClearSelection();
        }

        public void SetCells(RectangleCells cells) { cellObj = cells; }


    }
}
