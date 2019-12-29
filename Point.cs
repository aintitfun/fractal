namespace fractal
{
    public class Point
    {
        public double x;
        public double y;
        public int iteration;

        public Point(double inX, double inY, int inIteration=0)
        {
            x=inX;
            y=inY;
            iteration=inIteration;
        }
    }
}