/*
           ________________
          /|              /|
         / |             / |
        /  |            /  |
       /   |           /   |
      /    |          /    |
     /     |_ _ _ _ _/_ _ _|
   H|---------------|      /
   E|     /         |     /T
   I|    /          |    /H
   G|   /           |   /G
   H|  /            |  /N
   T| /             | /E
    |/______________|/L
           WIDTH

*/

namespace Cube_V11
{
    public class BodyParametrs
    {
        private double V;
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public BodyParametrs(double bodyWidth, double bodyHeight, double bodyLenght)
        {
            Width = bodyWidth;
            Height = bodyHeight;
            Length = bodyLenght;
            V = bodyWidth * bodyHeight * bodyLenght;
        }

        public double GetWidth() { return Width; }
        public double GetHeight() { return Height; }
        public double GetLenght() { return Length; }
        public double GetV() { return V; }
    }
}
