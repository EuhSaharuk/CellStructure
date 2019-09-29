using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point MoveX(double delta) => new Point { X = this.X + delta, Y = this.Y };
        public Point MoveY(double delta) => new Point { X = this.X, Y = this.Y + delta };

    }
    public class PointStepper
    {
        public List<Point> Points { set; get; }

        public void ParallelStep(Action<Point, Point> action)
        {
            Parallel.For(0, Points.Count, i =>
            {
                action(Points[i], i + 1 == Points.Count ? Points[0] : Points[i + 1]);
            });

        }

        public void Step(Action<Point, Point> action)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                action(Points[i], i + 1 == Points.Count ? Points[0] : Points[i + 1]);

            }

        }
}
}
