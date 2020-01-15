using System.Collections.Generic;

namespace fractal
{
    public interface IFractal
    {
        int MaxIterations{get;set;}
        Point Center{get;set;}
        double ScaleFactor{get;set;}
        public List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step);
        

    }
}