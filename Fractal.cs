using System.Collections.Generic;
namespace fractal
{
    public abstract class Fractal : IFractal
    {
        public int MaxIterations {get;set;}
        public Point Center{get;set;}
        public double ScaleFactor{get;set;}
        public List<int> listIterationValues { get; set; }
        public abstract List<int> Calculate(Point leftUpCorner, Point pointsToProcess, Point step);
        public abstract void Calculate(Point leftUpCorner, Point pointsToProcess, Point step, int line);

    }
}