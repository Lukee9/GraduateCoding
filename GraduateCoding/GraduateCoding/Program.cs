using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing Part A Question 1:
            Console.WriteLine("Part A Question 1:");
            PartA.Point2D pointOne = new PartA.Point2D();
            PartA.Point2D pointTwo = new PartA.Point2D();
            pointOne.x = 5;
            pointOne.y = 3;
            pointTwo.x = 6;
            pointTwo.y = 9;
            //Checking results
            Console.WriteLine(PartA.Point2D.calculateDistance(pointOne, pointTwo));

            //Testing Part A Question 2:
            Console.WriteLine(Environment.NewLine + "Part A Question 2:");
            PartA.Point2D pointThree = new PartA.Point2D();
            PartA.Point2D pointFour = new PartA.Point2D();
            PartA.Point2D pointFive = new PartA.Point2D();
            pointThree.x = 3;
            pointThree.y = 3;
            pointFour.x = 4;
            pointFour.y = 1;
            pointFive.x = 5;
            pointFive.y = 3;

            PartA.Point2D[] point2DArray = { pointOne, pointTwo, pointThree, pointFour, pointFive };
            //Checking results
            point2DArray = PartA.Point2D.sort(point2DArray);
            foreach (PartA.Point2D p in point2DArray)
            {
                Console.WriteLine($"({p.x}, {p.y})");
            }

            //Testing Part A Question 3:
            Console.WriteLine(Environment.NewLine + "Part A Question 3:");
            PartA.Point2D pointSix = new PartA.Point2D();
            PartA.Point2D pointSeven = new PartA.Point2D();
            pointSix.x = 2;
            pointSix.y = 1;
            pointSeven.x = 3;
            pointSeven.y = 2;

            //Checking results
            //Expecting true
            Console.WriteLine(PartA.Point2D.isAntiClockwise(pointSix, pointSeven, pointThree));
            //Expecting false
            Console.WriteLine(PartA.Point2D.isAntiClockwise(pointFour, pointSeven, pointThree));
            //Expecting true
            Console.WriteLine(PartA.Point2D.isCollinear(pointThree, pointThree, pointSeven));
            //Expecting false
            Console.WriteLine(PartA.Point2D.isCollinear(pointFour, pointSeven, pointThree));

            //Testing Part A Question 4:
            Console.WriteLine(Environment.NewLine + "Part A Question 4:");
            //Checking results
            //Expecting true
            Console.WriteLine(PartA.Point2D.doesIntersect(pointOne, pointTwo, pointThree, pointSix)); //Intersects at (6, 9)
            //Expecting false
            Console.WriteLine(PartA.Point2D.doesIntersect(pointOne, pointTwo, pointThree, pointFour)); //Would eventually intersect at (4.5, 0), both lines stop before reaching y = 0      

            Console.ReadLine();
        }
    }
}
