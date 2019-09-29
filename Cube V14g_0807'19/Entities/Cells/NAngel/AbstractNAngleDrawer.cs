using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;

namespace Cube_V11
{
    abstract class AbstractNAngleDrawer : CellsDrawer
    {
        protected SketchManager swSketchManager;
        protected SelectionMgr swSelMgr;

        protected AbstractRelationAngle cells;
        protected BodyParametrs body;
        protected BodyDrawer bodyDrawer;
        protected Array faces; // Список граней тела
        protected double deflection_Angle;

        public AbstractNAngleDrawer(SLDManager app, BodyParametrs body, BodyDrawer bodyDrawer, double angle)
        {
            application = app;
            this.body = body;
            this.bodyDrawer = bodyDrawer;
            deflection_Angle = angle * Math.PI / 180;
            // Получает ISketchManager объект, который позволяет получить доступ к процедурам эскиза
            swSketchManager = application.swModel.SketchManager;
            // Получает ISelectionMgr объект для данного документа, что делает выбранный объект доступным
            swSelMgr = (SelectionMgr)application.swModel.SelectionManager;
        }

        public void SetCells(AbstractRelationAngle cells) { this.cells = cells; }
        public double GetDifflection() { return deflection_Angle; }
    }
}
