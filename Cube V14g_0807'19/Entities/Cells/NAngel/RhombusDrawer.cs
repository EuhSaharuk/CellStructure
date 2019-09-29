using System;
using System.Collections.Generic;
using System.Linq;
using SolidWorks.Interop.sldworks;
using System.Windows.Forms;

namespace Cube_V11
{
    class RhombusDrawer : AbstractNAngleDrawer
    {
        readonly double h;
        readonly double w;
        readonly double cols;
        public RhombusDrawer(double h, double w, double cols, SLDManager app, BodyParametrs body, BodyDrawer bodyDrawer, double angle)
            : base(app, body, bodyDrawer, angle)
        {
            this.h = h;
            this.w = w;
            this.cols = cols;
        }

        public override void drawCells()
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
            FreeClass.sldManager.swModel.SetAddToDB(true);
            FreeClass.sldManager.swModel.SetDisplayWhenAdded(false);

            double side = body.Length / cols;
        
            for (double i = 0; i < cols; i++)
            {
                for (double j = 0; j < cols; j++)
                {
                    Sketch(new Point {
                        X = side / 2 - body.Length / 2 + side * i,
                        Y = side / 2 - body.Length / 2 + side * j
                    }, side / 2.0);
                }
            }
         
            //Получаем объект "вырез"
            cut = featureCut(body.GetHeight() * 0.3);
            application.swModel.ClearSelection();
            FreeClass.sldManager.swModel.SetAddToDB(false);
            FreeClass.sldManager.swModel.SetDisplayWhenAdded(true);
        }

        private void Sketch(Point center, double a)
        {
            var stepper = new PointStepper();
            stepper.Points = Rhombus(center, a, h, w, cols);
            stepper.ParallelStep(
                (f, t) => application.swModel.SketchManager.CreateLine(f.X, f.Y, 0, t.X, t.Y, 0)
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center"></param>
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static List<Point> Rhombus(Point center, double a, double h, double w, double cols)
        {
            return new List<Point> {
                // верх ромба
                    new Point { X = center.X + a * w, Y = center.Y },
                    new Point { X = center.X + a * w * h, Y = center.Y + a * (1-  h) },
                    new Point { X = center.X - a * w * h, Y = center.Y + a * (1-  h) },
                    new Point { X = center.X - a * w, Y = center.Y },
                // низ ромба
                    new Point { X = center.X - a * w * h, Y = center.Y - a * (1-  h) },
                    new Point { X = center.X + a * w * h, Y = center.Y - a * (1-  h) },
                    new Point { X = center.X + a * w, Y = center.Y },
            };
        }
    }
}
