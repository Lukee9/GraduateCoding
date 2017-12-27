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
            PartA.Point2D pointOne = new PartA.Point2D();
            PartA.Point2D pointTwo = new PartA.Point2D();
            pointOne.x = 5;
            pointOne.y = 3;
            pointTwo.x = 6;
            pointTwo.y = 9;
            //Checking results
            Console.WriteLine(PartA.Point2D.calculateDistance(pointOne, pointTwo));

            //Testing Part A Question 2:
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
            Console.ReadLine();
        }
    }
}
