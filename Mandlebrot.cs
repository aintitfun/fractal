using System.Collections.Generic;

namespace fractal
{
    public class Mandlebrot : Fractal
    {
        public override List<Point> Calculate()
        {
            List<Point> listPoint= new List<Point>();
            for (int i=0;i<200;i++)
                for (int j=0;j<200;j++)
                    listPoint.Add(new Point(i,j,0));
            return listPoint;
        }
    }
}