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


            Console.ReadLine();
        }
    }
}
