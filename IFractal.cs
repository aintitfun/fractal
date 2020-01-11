using System.Collections.Generic;

namespace fractal
{
    public interface IFractal
    {
        int Iterations{get;set;}
        Point Center{get;set;}
        double ScaleFactor{get;set;}
        public List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step);
        

    }
}