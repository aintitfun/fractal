using Gtk;
using Cairo;

namespace fractal
{
    public class Screen
    {
        private DrawingArea drawingArea;
        private Cairo.Context cr;
        private MainWindow window;
        IFractal fractal;

        public Screen(ref DrawingArea inDrawingArea, ref Cairo.Context inCR, ref IFractal inFractal, MainWindow inWindow)
        {
            drawingArea=inDrawingArea;
            cr=inCR;
            fractal=inFractal;
            window=inWindow;

        }
        public void Pset (int x, int y)
        {
            //DrawingArea darea = new DrawingArea();

            
            //cr.LineTo(100,100);

        }
        public void Paint()
        {
            cr.SetSourceRGB (0.1, 0.1, 1);
            int width,height;
            window.GetSize(out width,out height);
            foreach (Point point in fractal.Calculate(new Point(0,0), new Point(width,height),new Point (1,1)))
            {
                cr.Rectangle(point.x,point.y,point.x+1,point.y+1);
                cr.Fill();
            }
        }
    }
}