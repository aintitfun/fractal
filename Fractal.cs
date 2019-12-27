using System.Collections.Generic;
namespace fractal
{
    public abstract class Fractal : IFractal
    {
        private int iterations;

        public void Paint(ref Screen s)
        {
            s.Pset(100,100);
        }
        public abstract List<Point> Calculate();

    }
}