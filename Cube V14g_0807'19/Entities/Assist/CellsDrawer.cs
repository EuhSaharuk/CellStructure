using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;


namespace Cube_V11
{
    public abstract class CellsDrawer
    {
        protected SLDManager application;

        protected Feature activeSketch;
        protected Feature cut;

        protected CellsDrawer() { }

        abstract public void drawCells();

        /// <summary>
        /// Удаление отверстий
        /// </summary>
        public void deleteCells()
        {
            try {
                cut.Select(true); }
            catch { }
            application.swModel.DeleteSelection(true);
            activeSketch.Select(true);
            application.swModel.DeleteSelection(true);
        }

        /// <summary>
        /// Вырезать по контуру
        /// </summary>
        /// <param name="deepth">глубина выреза</param>
        /// <param name="flip">вырезать внутри контура или снаружи</param>
        /// <param name="mode">режим выреза</param>
        /// <returns>объект "вырез"</returns>
        protected Feature featureCut(double deepth, bool flip = false, swEndConditions_e mode = swEndConditions_e.swEndCondBlind)
        {
            return application.swModel.FeatureManager.FeatureCut2(true, flip, false, (int)mode, (int)mode,
                deepth, 0, false, false, false, false, 0, 0, false, false, false, false, false,
                false, false, false, false, false);
        }
    }
}