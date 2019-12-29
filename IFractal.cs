using System.Collections.Generic;

namespace fractal
{
    public interface IFractal
    {
        public List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step);
    }
}