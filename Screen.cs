using Gtk;
using Cairo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
namespace fractal
{
    public class Screen
    {
        private Cairo.Context cr;
        private Gtk.Frame window;
        public IFractal fractal;
        private int width;
        private int height;
        public Screen( Cairo.Context inCR, IFractal inFractal, Gtk.Frame inWindow)
        {
            cr=inCR;
            fractal=inFractal;
            window=inWindow;
            width=window.AllocatedWidth;
            height=window.AllocatedHeight;
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
            var s=new Stopwatch(); 
            s.Start();
            Parallel.For(0,height,new ParallelOptions{ MaxDegreeOfParallelism = 4 },i => 
                {
                    fractal.Calculate(100,GetLeftUpCornerPoint(), new Point(width, height), GetStep(leftUpCornerPoint, rightDownCornerPoint),i);
                });
            s.Stop();
            Console.WriteLine("elapsed calculation: "+s.ElapsedMilliseconds);
            /*for (int i = 0; i < height; i+=3)
            {
                fractal.Calculate(GetLeftUpCornerPoint(), new Point(width, height), GetStep(leftUpCornerPoint, rightDownCornerPoint),i);
            }*/
            s.Restart();   
            /*Parallel.For(0,height,new ParallelOptions{ MaxDegreeOfParallelism = 1 },i => 
            {
                for (int j=0;j<width;j++)
                {
                    int iterationValue=fractal.listIterationValues[i*width+j];
                    cr.SetSourceRGB (iterationValue, iterationValue, iterationValue);
                    //cr.SetSourceRGB (1, 1, 1);
                    cr.Rectangle(j,i,1,1);
                    cr.Fill();

                }
            }); */
            for (int i=0;i<height;i++)
            {
                for (int j=0;j<width;j++)
                {
                    int iterationValue=fractal.listIterationValues[i*width+j];
                    //cr.SetSourceRGB (iterationValue, iterationValue, iterationValue);
                    if (iterationValue>0)
                    {
                        cr.SetSourceRGB (Math.Cos(iterationValue), Math.Sin(iterationValue), Math.Cos(iterationValue));
                        cr.Rectangle(j,i,1,1);
                        cr.Fill();
 
                    }
                }
            }

            s.Stop();
            Console.WriteLine("elapsed paint: "+s.ElapsedMilliseconds);
        }
    }
}