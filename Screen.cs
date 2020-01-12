using Gtk;
using Cairo;
using System;

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
        public Point GetLeftUpCornerPoint()
        {
            int width,height;
            window.GetSize(out width,out height);
            return new Point((fractal.Center.x-(width/2))*fractal.ScaleFactor,(fractal.Center.y-(height/2))*fractal.ScaleFactor);
        }

        public Point GetRightDownCornerPoint()
        {
            int width,height;
            window.GetSize(out width,out height);
            return new Point((fractal.Center.x+(width/2))*fractal.ScaleFactor,(fractal.Center.y+(height/2))*fractal.ScaleFactor);
        }
        public Point GetStep(Point inLeftUpCornerPoint,Point inRightDownCornerPoint)
        {
            int width,height;
            window.GetSize(out width,out height);
            //return new Point((System.Math.Abs(inLeftUpCornerPoint.x)-System.Math.Abs(inRightDownCornerPoint.x))/width,(System.Math.Abs(inLeftUpCornerPoint.y)-System.Math.Abs(inRightDownCornerPoint.y))/height);
            Convert.ToDouble(width);
            return new Point(System.Math.Abs((inLeftUpCornerPoint.x-inRightDownCornerPoint.x)/Convert.ToDouble(width)),System.Math.Abs((inLeftUpCornerPoint.y-inRightDownCornerPoint.y)/Convert.ToDouble(height)));
        }
        public void Paint()
        {
            cr.SetSourceRGB (0.1, 0.1, 1);
            int width,height;
            window.GetSize(out width,out height);
            Point leftUpCornerPoint=GetLeftUpCornerPoint();
            Point rightDownCornerPoint=GetRightDownCornerPoint();
            foreach (Point point in fractal.Calculate(GetLeftUpCornerPoint(), GetRightDownCornerPoint(),GetStep(leftUpCornerPoint,rightDownCornerPoint)))
            {
                cr.Rectangle(point.x/fractal.ScaleFactor,point.y/fractal.ScaleFactor,point.x/fractal.ScaleFactor+1,point.y/fractal.ScaleFactor+1);
                cr.Fill();
            }
        }
    }
}