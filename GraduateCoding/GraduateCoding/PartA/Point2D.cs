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
        public static bool isAntiClockwise(Point2D pointOne, Point2D pointTwo, Point2D pointThree)
        {
            return twiceSignedArea(pointOne, pointTwo, pointThree) > 0;
        }
        public static bool isCollinear(Point2D pointOne, Point2D pointTwo, Point2D pointThree)
        {
            return twiceSignedArea(pointOne, pointTwo, pointThree) == 0;
        }
        private static int twiceSignedArea(Point2D pointOne, Point2D pointTwo, Point2D pointThree)
        {
            return (pointTwo.x - pointOne.x) * (pointThree.y - pointOne.y) - (pointTwo.y - pointOne.y) * (pointThree.x - pointOne.x);
        }
        //Perhaps create a new class for line2D, would keep things more clean
        public static bool doesIntersect(Point2D lineOnePointOne, Point2D lineOnePointTwo, Point2D lineTwoPointOne, Point2D lineTwoPointTwo)
        {
            //Firstly creates line equations from points in the form y = mx + c.
            double mLineOne;
            double cLineOne;

            double mLineTwo;
            double cLineTwo;
            //Calculate gradient m = delta y / delta x
            mLineOne = (lineOnePointTwo.y - lineOnePointOne.y) / (lineOnePointTwo.x - lineOnePointOne.x);
            mLineTwo = (lineTwoPointTwo.y - lineTwoPointOne.y) / (lineTwoPointTwo.x - lineTwoPointOne.x);

            //If gradients are equal, lines are parallel and will never intercept so can avoid unnecessary processing
            if (mLineOne == mLineTwo) return false;

            //Calculate constant c by substituting known points
            cLineOne = lineOnePointOne.y - mLineOne * lineOnePointOne.x;
            cLineTwo = lineTwoPointOne.y - mLineTwo * lineTwoPointOne.x;

            //At point of intersection y1 = y2 therefore m1x + c1 = m2x + c2 so solve to find x coordinate
            double intersectx;
            double intersecty;
            //Rearranged so x = (c2 - c1)/(m1 - m2)
            intersectx = (cLineTwo - cLineOne) / (mLineOne - mLineTwo);
            //Substitute known point back into equation using x intersection to find y coordinate
            intersecty = mLineOne * intersectx + cLineOne;

            //Point of intersection is now known as (intersectx, intersecty).
            //However this may only occur if the lines are infinite which in our case they may not be.
            //Apply constraints to intersection point to see if our lines intersect

            //Calculate the minimum and maximum seen x and y value
            Point2D[] Points = { lineOnePointOne, lineOnePointTwo, lineTwoPointOne, lineTwoPointTwo };
            int minx = min(Points, true);
            int maxx = max(Points, true);
            int miny = min(Points, false);
            int maxy = max(Points, false);

            //Return whether point of intersection is valid within our lines
            if (intersectx >= minx && intersectx <= maxx && intersecty >= miny && intersecty <= maxy) return true;
            else return false;
        }
        private static int min(Point2D[] Points, bool x)
        {
            int minimum = int.MaxValue;
            foreach (Point2D p in Points)
            {
                if (x) minimum = Math.Min(minimum, p.x);
                else minimum = Math.Min(minimum, p.y);
            }
            return minimum;
        }
        private static int max(Point2D[] Points, bool x)
        {
            int maximum = int.MinValue;
            foreach (Point2D p in Points)
            {
                if (x) maximum = Math.Max(maximum, p.x);
                else maximum = Math.Max(maximum, p.y);
            }
            return maximum;
        }
        public static bool isInsidePolygon(Point2D[] Polygon, Point2D Point)
        {
            int intersections = 0;
            //Define an infinite point, in an ideal world the values would be infinity but we cannot do that within a computing environment
            Point2D Infinity = new Point2D();
            Infinity.x = int.MaxValue;
            Infinity.y = int.MinValue;

            //If a line drawn between the given point and a point placed at infinity intersects with any of the edges of the shape once, then it must be inside that shape
            for(int i = 1; i < Polygon.Length; i++)
            {
                if (doesIntersect(Polygon[i - 1], Polygon[i], Point, Infinity)) intersections++;
            }
            //Check the final edge which is skipped by the for loop (the edge between the first point and final point of the polygon)
            if (doesIntersect(Polygon[Polygon.Length - 1], Polygon[0], Point, Infinity)) intersections++;

            //If the infinity line intersects more than once then it was outside the shape and went through the shape
            if (intersections == 1) return true;
            else return false;
        }
    }
}
