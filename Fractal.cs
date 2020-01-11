using System.Collections.Generic;
namespace fractal
{
    public abstract class Fractal : IFractal
    {
        public int Iterations {get;set;}
        public Point Center{get;set;}
        public double ScaleFactor{get;set;}


        public abstract List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step);

    }
}