using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateCoding.PartA
{
    public class Point2D
    {
        public int x;
        public int y;

        public static double calculateDistance(Point2D pointOne, Point2D pointTwo)
        {
            //Returns the square root of the difference of the x values squared and the y value difference squared
            return Math.Sqrt(Math.Pow(pointTwo.x - pointOne.x, 2) + Math.Pow(pointTwo.y - pointOne.y, 2));
        }
        public static Point2D[] sort(Point2D[] Points)
        {
            //Defines the origin as (0,0)
            Point2D origin = new Point2D();
            origin.x = 0;
            origin.y = 0;
            //Converts the array of points to a list so it can be sorted using an anonymous function based on the calculateDistance method
            List<Point2D> pointList = Points.ToList();
            pointList.Sort((a, b) => (
            calculateDistance(a, origin).CompareTo(calculateDistance(b, origin)))
            );
            return pointList.ToArray();
        }
    }
}
