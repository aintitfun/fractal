using System.Collections.Generic;
namespace fractal
{
    public abstract class Fractal : IFractal
    {
        private int iterations;


        public abstract List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step);

    }
}