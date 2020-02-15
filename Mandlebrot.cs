using System.Collections.Generic;
using System;

namespace fractal
{
    public class Mandlebrot : Fractal
    {
        public Mandlebrot()
        {
            MaxIterations=100;
            Center=new Point(-0.02,-0.3);
            ScaleFactor=0.004;
        }
        public override List<int> Calculate(Point leftUpCorner, Point pointsToProcess, Point step)
        {
            Console.WriteLine(ScaleFactor+" " + Center.x+" "+Center.y);
            List<int> listIterationValues=new List<int>();
            double xpos=leftUpCorner.x;
            double ypos=leftUpCorner.y;
            for (double i=0;i<pointsToProcess.y;i++)
            {
                for (double j=0;j<pointsToProcess.x;j++)
                {

                    double x=xpos;
                    double y=ypos;
                    double x2=xpos*xpos;
                    double y2=ypos*ypos;
                    bool exits=false;
                    for (int k=0;k<MaxIterations;k++)
                    {
                        x2=x*x;
                        y2=y*y;
                        y=2*x*y+ypos;
                        x=x2-y2+xpos;
                        if (x*x+y*y>4)
                        {
                            listIterationValues.Add(k);
                            exits=true;
                            break;
                        }
                    }
                    if (exits==false)
                        listIterationValues.Add(230);

                    xpos+=step.x;
                }
                xpos=leftUpCorner.x;
                ypos+=step.y;
            }
            Console.WriteLine("iteraciones" + listIterationValues.Count+ " ");
            return listIterationValues;
        }
    }
}