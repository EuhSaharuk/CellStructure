using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_V11.Entities
{
    public class NodeStressStrainModel
    {
        public int NodeId { get; set; }

        public float StressValue { get; set; }

        public float StrainValue { get; set; }
    }

    public class NodeStressXYZModel
    {
        public int NodeId { get; set; }

        public float StressValue { get; set; }

        public float XY { get; set; }

        public float XZ { get; set; }

        public float YZ { get; set; }
    }

    public class NodeStrainXYZModel
    {
        public int NodeId { get; set; }

        public float StrainValue { get; set; }

        public float XY { get; set; }

        public float XZ { get; set; }

        public float YZ { get; set; }
    }

    public class TotalStressModel
    {
        /// <summary>
        /// Node ID
        /// </summary>
        public int NodeId { get; set; }
        /// <summary>
        /// Normal stress in the X-direction of the selected reference geometry
        /// </summary>
        public float SX { get; set; }
        /// <summary>
        /// Normal stress in the Y-direction of the selected reference geometry
        /// </summary>
        public float SY { get; set; }
        /// <summary>
        /// Normal stress in the Z-direction of the selected reference geometry
        /// </summary>
        public float SZ { get; set; }
        /// <summary>
        /// Shear stress in the Y-direction acting in the YZ plane of the selected reference geometry
        /// </summary>
        public float XY { get; set; }
        /// <summary>
        /// Shear stress in the Z-direction acting in the YZ plane of the selected reference geometry
        /// </summary>
        public float XZ { get; set; }
        /// <summary>
        /// Shear stress in the Z-direction acting in the XZ plane of the selected reference geometry
        /// </summary>
        public float YZ { get; set; }
        /// <summary>
        /// Normal stress in the first principal direction
        /// </summary>
        public float P1 { get; set; }
        /// <summary>
        /// Normal stress in the second principal direction
        /// </summary>
        public float P2 { get; set; }
        /// <summary>
        /// Normal stress in the third principal direction
        /// </summary>
        public float P3 { get; set; }
        /// <summary>
        /// von Mises stress
        /// </summary>
        public float VON { get; set; }
        /// <summary>
        /// Stress intensity = P1 - P3
        /// </summary>
        public float INT { get; set; }
    }

    public class TotalStrainModel
    {
        /// <summary>
        /// Node ID
        /// </summary>
        public int NodeId { get; set; }
        /// <summary>
        /// Normal stress in the X-direction of the selected reference geometry
        /// </summary>
        public float SX { get; set; }
        /// <summary>
        /// Normal stress in the Y-direction of the selected reference geometry
        /// </summary>
        public float SY { get; set; }
        /// <summary>
        /// Normal stress in the Z-direction of the selected reference geometry
        /// </summary>
        public float SZ { get; set; }
        /// <summary>
        /// Shear stress in the Y-direction acting in the YZ plane of the selected reference geometry
        /// </summary>
        public float XY { get; set; }
        /// <summary>
        /// Shear stress in the Z-direction acting in the YZ plane of the selected reference geometry
        /// </summary>
        public float XZ { get; set; }
        /// <summary>
        /// Shear stress in the Z-direction acting in the XZ plane of the selected reference geometry
        /// </summary>
        public float YZ { get; set; }
        /// <summary>
        /// Equivalent strain
        /// </summary>
        public float ESTRN { get; set; }
        /// <summary>
        /// Strain energy density
        /// </summary>
        public float SEDENS { get; set; }
        /// <summary>
        /// Total strain energy
        /// </summary>
        public float ENERGY { get; set; }
        /// <summary>
        /// Normal strain in the first principal direction
        /// </summary>
        public float E1 { get; set; }
        /// <summary>
        /// Normal strain in the second principal direction
        /// </summary>
        public float E2 { get; set; }
        /// <summary>
        /// Normal strain in the third principal direction
        /// </summary>
        public float E3 { get; set; }
    }

    public class Node
    {
        public int Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }
    }
}
