using System.Collections.Generic;

namespace fractal
{
    public class Mandlebrot : Fractal
    {
        public Mandlebrot()
        {
            Iterations=60;
            Center=new Point(-5,-5);
            ScaleFactor=0.02;
        }
        public override List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step)
        {
            List<Point> listPoint= new List<Point>();
            for (double i=leftUpCorner.x;i<rightDownCorner.x;i+=step.x)
            {

            
                for (double j=leftUpCorner.y;j<rightDownCorner.y;j+=step.y)
                {

                    double x=0;
                    double y=0;
                    double oldX=0;
                    for (int k=0;k<Iterations;k++)
                    {
                        x=x*x-y*y+i;
                        oldX=x;
                        y=2*x*oldX+j;

                        if (System.Math.Abs(x)>20 || System.Math.Abs(y)>20)
                        {
                            listPoint.Add(new Point(i,j,k));
                            break;

                        }
                    }
                                        
                }
                    
            }
            return listPoint;
        }
    }
}