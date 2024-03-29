using System.Collections.Generic;

namespace fractal
{
    public interface IFractal
    {
        Point Center{get;set;}
        double ScaleFactor{get;set;}
        int [] listIterationValues { get; set; }
        public List<int> Calculate(int maxIterations,int boilOut,Point leftUpCorner, Point pointsToProcess, Point step);

        public void Calculate(int maxIterations,int boilOut,Point leftUpCorner, Point pointsToProcess, Point step, int line);
    }
}