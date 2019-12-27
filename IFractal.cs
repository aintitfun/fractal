using System.Collections.Generic;

namespace fractal
{
    public interface IFractal
    {
        public void Paint(ref Screen s);
        public List<Point> Calculate();
    }
}