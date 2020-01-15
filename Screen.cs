using Gtk;
using Cairo;
using System;
using System.Collections.Generic;

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
            return new Point(fractal.Center.x-(width/2f)*fractal.ScaleFactor,fractal.Center.y-(height/2f)*fractal.ScaleFactor);
        }

        public Point GetRightDownCornerPoint()
        {
            int width,height;
            window.GetSize(out width,out height);
            return new Point(fractal.Center.x+(width/2)*fractal.ScaleFactor,fractal.Center.y+(height/2)*fractal.ScaleFactor);
        }
        public Point GetStep(Point inLeftUpCornerPoint,Point inRightDownCornerPoint)
        {
            int width,height;
            window.GetSize(out width,out height);
            //return new Point((System.Math.Abs(inLeftUpCornerPoint.x)-System.Math.Abs(inRightDownCornerPoint.x))/width,(System.Math.Abs(inLeftUpCornerPoint.y)-System.Math.Abs(inRightDownCornerPoint.y))/height);
            return new Point(System.Math.Abs((inLeftUpCornerPoint.x-inRightDownCornerPoint.x)/Convert.ToDouble(width)),System.Math.Abs((inLeftUpCornerPoint.y-inRightDownCornerPoint.y)/Convert.ToDouble(height)));
        }
        public void Paint()
        {
            cr.SetSourceRGB (0.1, 0.1, 1);
            int width,height;
            window.GetSize(out width,out height);
            Point leftUpCornerPoint=GetLeftUpCornerPoint();
            Point rightDownCornerPoint=GetRightDownCornerPoint();

            int i=0;
            int j=0;
            foreach (Point point in fractal.Calculate(GetLeftUpCornerPoint(), GetRightDownCornerPoint(),GetStep(leftUpCornerPoint,rightDownCornerPoint)))
            {
                
                    cr.SetSourceRGB (Math.Sin(point.iteration), Math.Cos(point.iteration), Math.Cos(point.iteration));
                    cr.Rectangle(System.Convert.ToDouble(point.x),System.Convert.ToDouble(point.y),System.Convert.ToDouble(point.x),System.Convert.ToDouble(point.y));
                    cr.Fill(); 

               


            }



            /*foreach (int iteration in fractal.Calculate(GetLeftUpCornerPoint(), GetRightDownCornerPoint(),GetStep(leftUpCornerPoint,rightDownCornerPoint)))
            {
                //el punto real quyitando el scalefactor+el ancho +el ajuste desde el centrol
                int psetX=System.Convert.ToInt32(System.Math.Abs(System.Math.Abs(point.x/fractal.ScaleFactor)-(width/2+System.Math.Abs(fractal.Center.x/fractal.ScaleFactor))));
                int psetY=System.Convert.ToInt32(System.Math.Abs(System.Math.Abs(point.y/fractal.ScaleFactor)-(height/2+System.Math.Abs(fractal.Center.y/fractal.ScaleFactor))));
                cr.Rectangle(psetX,psetY,psetX+1,psetY+1);
                cr.Fill();
            }*/
        }
    }
}