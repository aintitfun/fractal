using Gtk;
using Cairo;

namespace fractal
{
    public class Screen
    {
        private MainWindow win=new MainWindow();
        private DrawingArea drawingArea;
        private Cairo.Context cr;
        IFractal fractal;

        public Screen(ref DrawingArea inDrawingArea, ref Cairo.Context inCR, ref IFractal inFractal)
        {
            drawingArea=inDrawingArea;
            cr=inCR;
            fractal=inFractal;
        }
        public void Pset (int x, int y)
        {
            win.SetDefaultSize(230, 150);
            win.SetPosition(WindowPosition.Center);
            //DrawingArea darea = new DrawingArea();

            
            //cr.LineTo(100,100);

        }
        public void Paint()
        {
            cr.SetSourceRGB (0.1, 0.1, 1);
            
            
            foreach (Point point in fractal.Calculate())
            {
                cr.Rectangle(point.x,point.y,point.x+1,point.y+1);
                cr.Fill();
            }
            

        }
        public MainWindow GetWindow(){
            return win;
        }
    }
}