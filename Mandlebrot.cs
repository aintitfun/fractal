using System.Collections.Generic;

namespace fractal
{
    public class Mandlebrot : Fractal
    {
        public override List<Point> Calculate(Point leftUpCorner, Point rightDownCorner, Point step)
        {
            List<Point> listPoint= new List<Point>();
            for (double i=leftUpCorner.x;i<rightDownCorner.x;i+=step.x)
            {

            
                for (double j=leftUpCorner.y;j<rightDownCorner.y;j+=step.y)
                {
                    listPoint.Add(new Point(i,j,0));
                }
                    
            }
            return listPoint;
        }
    }
}