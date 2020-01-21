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
        public IFractal fractal;
        private int width;
        private int height;
        public Screen(DrawingArea inDrawingArea, Cairo.Context inCR, IFractal inFractal, MainWindow inWindow)
        {
            drawingArea=inDrawingArea;
            cr=inCR;
            fractal=inFractal;
            window=inWindow;
            window.GetSize(out width,out height);
        }
        public void Pset (int x, int y)
        {
            //DrawingArea darea = new DrawingArea();

            
            //cr.LineTo(100,100);

        }
        public Point GetLeftUpCornerPoint()
        {

            return new Point(fractal.Center.x-(width/2)*fractal.ScaleFactor,fractal.Center.y-(height/2)*fractal.ScaleFactor);
        }

        public Point GetClickFractalPosition(Point clickPosition)
        {
            Point leftUpCornerPoint=GetLeftUpCornerPoint();
            return new Point(leftUpCornerPoint.x+clickPosition.x*fractal.ScaleFactor,leftUpCornerPoint.y+clickPosition.y*fractal.ScaleFactor);
        }

        public Point GetRightDownCornerPoint()
        {

            return new Point(fractal.Center.x+(width/2)*fractal.ScaleFactor,fractal.Center.y+(height/2)*fractal.ScaleFactor);
        }
        public Point GetStep(Point inLeftUpCornerPoint,Point inRightDownCornerPoint)
        {

            //return new Point((System.Math.Abs(inLeftUpCornerPoint.x)-System.Math.Abs(inRightDownCornerPoint.x))/width,(System.Math.Abs(inLeftUpCornerPoint.y)-System.Math.Abs(inRightDownCornerPoint.y))/height);
            return new Point(System.Math.Abs((inLeftUpCornerPoint.x-inRightDownCornerPoint.x)/width),System.Math.Abs((inLeftUpCornerPoint.y-inRightDownCornerPoint.y)/height));
        }
        public void Paint()
        {
            cr.SetSourceRGB (0.1, 0.1, 1);

            Point leftUpCornerPoint=GetLeftUpCornerPoint();
            Point rightDownCornerPoint=GetRightDownCornerPoint();

            Console.WriteLine("corners: "+leftUpCornerPoint.x+" "+leftUpCornerPoint.y+" "+rightDownCornerPoint.x+" "+rightDownCornerPoint.y);

            /*foreach (Point point in fractal.Calculate(GetLeftUpCornerPoint(), GetRightDownCornerPoint(),GetStep(leftUpCornerPoint,rightDownCornerPoint)))
            {
                
                    cr.SetSourceRGB (Math.Sin(point.iteration), Math.Cos(point.iteration), Math.Cos(point.iteration));
                    cr.Rectangle(System.Convert.ToDouble(point.x),System.Convert.ToDouble(point.y),System.Convert.ToDouble(point.x),System.Convert.ToDouble(point.y));
                    cr.Fill(); 

               


            }*/


            /*
            foreach (int iteration in fractal.Calculate(GetLeftUpCornerPoint(), GetRightDownCornerPoint(),GetStep(leftUpCornerPoint,rightDownCornerPoint)))
            {
                //el punto real quyitando el scalefactor+el ancho +el ajuste desde el centrol
                int psetX=System.Convert.ToInt32(System.Math.Abs(System.Math.Abs(point.x/fractal.ScaleFactor)-(width/2+System.Math.Abs(fractal.Center.x/fractal.ScaleFactor))));
                int psetY=System.Convert.ToInt32(System.Math.Abs(System.Math.Abs(point.y/fractal.ScaleFactor)-(height/2+System.Math.Abs(fractal.Center.y/fractal.ScaleFactor))));
                cr.Rectangle(psetX,psetY,psetX+1,psetY+1);
                cr.(Fill);
            }*/
            
            List<int> listIterationValues=new List<int>();
            listIterationValues=fractal.Calculate(GetLeftUpCornerPoint(), new Point(width,height),GetStep(leftUpCornerPoint,rightDownCornerPoint));
            for (int i=0;i<height;i++)
            {
                for (int j=0;j<width;j++)
                {
                    int iterationValue=listIterationValues[i*width+j];
                    cr.SetSourceRGB (Math.Sin(iterationValue), Math.Cos(iterationValue), Math.Cos(iterationValue));
                    cr.Rectangle(j,i,j,i);
                    cr.Fill();

                }
            }
        }
    }
}