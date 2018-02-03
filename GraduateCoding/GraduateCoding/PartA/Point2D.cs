using System;
using System.Collections.Generic;
using System.Linq;

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
            Point2D origin = new Point2D
            {
                x = 0,
                y = 0
            };
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
        public static bool doesIntersect(Point2D lineOnePointOne, Point2D lineOnePointTwo, Point2D lineTwoPointOne, Point2D lineTwoPointTwo)
        {
            //Firstly creates line equations from points in the form y = mx + c.
            double mLineOne;
            double cLineOne;

            double mLineTwo;
            double cLineTwo;

            //Prevents use of incorrect formula with vertical lines
            bool verticalLineOne = false;
            bool verticalLineTwo = false;
            //Calculate gradient m = delta y / delta x
            int denomOne = lineOnePointTwo.x - lineOnePointOne.x; //Prevents crashing when m = 0 (vertical line)
            int denomTwo = lineTwoPointTwo.x - lineTwoPointOne.x;

            if (denomOne == 0)
            {
                mLineOne = 0;
                verticalLineOne = true;
            }
            else
                mLineOne = (lineOnePointTwo.y - lineOnePointOne.y) / denomOne;
            if (denomTwo == 0)
            {
                mLineTwo = 0;
                verticalLineTwo = true;
            }
            else
                mLineTwo = (lineTwoPointTwo.y - lineTwoPointOne.y) / denomTwo;

            //If gradients are equal, lines are parallel and will never intercept so can avoid unnecessary processing
            if (mLineOne == mLineTwo) return false;

            //Calculate constant c by substituting known points


            if (mLineOne == 0 && !verticalLineOne) //for horizontal lines
                cLineOne = lineOnePointOne.y;
            else
            {
                cLineOne = lineOnePointOne.y - mLineOne * lineOnePointOne.x;
            }
            if (mLineTwo == 0 && !verticalLineTwo)
                cLineTwo = lineTwoPointOne.y;
            else
            {
                cLineTwo = lineTwoPointOne.y - mLineTwo * lineTwoPointOne.x;
            }

            //At point of intersection y1 = y2 therefore m1x + c1 = m2x + c2 so solve to find x coordinate
            double intersectx;
            double intersecty;

            if (verticalLineOne) //Vertical line
                intersectx = lineOnePointOne.x;
            else if (verticalLineTwo)
                intersectx = lineTwoPointOne.x;
            else
            {
                //Rearranged so x = (c2 - c1)/(m1 - m2)
                intersectx = (cLineTwo - cLineOne) / (mLineOne - mLineTwo);
            }
            intersecty = mLineOne * intersectx + cLineOne;
            //Substitute known point back into equation using x intersection to find y coordinate


            //Point of intersection is now known as (intersectx, intersecty).
            //However this may only occur if the lines are infinite which in our case they may not be.
            //Apply constraints to intersection point to see if our lines intersect

            //Calculate the minimax and maximin of seen x and y value to add constraints
            Point2D[] lineOne = { lineOnePointOne, lineOnePointTwo };
            Point2D[] lineTwo = { lineTwoPointOne, lineTwoPointTwo };
            int minx = Math.Max(min(lineOne, true), min(lineTwo, true));
            int maxx = Math.Min(max(lineOne, true), max(lineTwo, true));
            int miny = Math.Max(min(lineOne, false), min(lineTwo, false));
            int maxy = Math.Min(max(lineOne, false), max(lineTwo, false));

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
            //Needs fixing, intersections == 2 when going through corner. Use a second check for minvalue and work from there

            int intersections = 0;
            //Define an infinite point, in an ideal world the values would be infinity but we cannot do that within a computing environment
            Point2D Infinity = new Point2D();
            Infinity.x = int.MaxValue;
            Infinity.y = int.MaxValue;

            //If a line drawn between the given point and a point placed at infinity intersects with any of the edges of the shape once, then it must be inside that shape
            for (int i = 1; i < Polygon.Length; i++)
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
