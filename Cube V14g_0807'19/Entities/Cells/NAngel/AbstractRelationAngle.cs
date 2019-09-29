using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11
{
    /**
        Промежуточный класс для классов с полем "зависимость от площади"
        */
    abstract class AbstractRelationAngle : AbstractAngle
    {
        protected double k_x;
        protected double k_y;

        public const double maxCoef = Math.PI / 4; // максимальное соотношение локали и окружности в неё вписаной
        protected double relation; // Отношение площадей окружности к локали

        public AbstractRelationAngle(BodyParametrs body) : base(body){ }

        public double GetRelations() { return relation; }

        public double GetKX() { return k_x; }
        public double GetKY() { return k_y; }
    }
}
