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
            return Math.Sqrt(Math.Pow(pointTwo.x - pointOne.x, 2) + Math.Pow(pointTwo.y - pointOne.y, 2));
        }
    }
}
