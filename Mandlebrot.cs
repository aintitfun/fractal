using System.Collections.Generic;

namespace fractal
{
    public class Mandlebrot : Fractal
    {
        public Mandlebrot()
        {
            MaxIterations=255;
            Center=new Point(-0.02f,-1.3034f);
            ScaleFactor=0.00011f;
        }
        public override List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step)
        {
            List<Point> listPoint=new List<Point>();
            int screenX=0;
            int screenY=0;

            for (double j=leftUpCorner.y;j<rightDownCorner.y;j+=step.y)
            {
                screenY++;
                screenX=0;

                for (double i=leftUpCorner.x;i<rightDownCorner.x;i+=step.x)
                {
                    screenX++;

                    double x=j;
                    double y=i;
                    double x2=j*j;
                    double y2=i*i;
                    bool exits=false;
                    for (int k=0;k<MaxIterations;k++)
                    {
                        x2=x*x;
                        y2=y*y;
                        y=2*x*y+i;
                        x=x2-y2+j;
                        

                        //if (System.Math.Abs(x)>20 || System.Math.Abs(y)>20)
                        if (x*x+y*y>4)
                        {
                            listPoint.Add(new Point(screenX,screenY,k));
                            exits=true;
                            break;

                        }
                        //oldX=x;
                        //oldY=y;
                    }
                    if (exits==false)
                    {
                        listPoint.Add(new Point(screenX,screenY,230));
                    }

                                        
                }
                    
            }
            return listPoint;
        }
    }
}