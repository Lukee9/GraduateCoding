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
            testPartA();
            Console.WriteLine(Environment.NewLine);
            testPartB();
            Console.ReadLine();
        }
        static void testPartA()
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
            Console.WriteLine(PartA.Point2D.doesIntersect(pointOne, pointTwo, pointTwo, pointSix)); //Intersects at (6, 9)
            //Expecting false
            Console.WriteLine(PartA.Point2D.doesIntersect(pointOne, pointTwo, pointThree, pointFour)); //Would eventually intersect at (4.5, 0), both lines stop before reaching y = 0      

            //Testing Part A Question 5:
            Console.WriteLine(Environment.NewLine + "Part A Question 5:");
            PartA.Point2D cornerOne = new PartA.Point2D();
            PartA.Point2D cornerTwo = new PartA.Point2D();
            PartA.Point2D cornerThree = new PartA.Point2D();
            PartA.Point2D cornerFour = new PartA.Point2D();
            cornerOne.x = 0;
            cornerOne.y = 0;
            cornerTwo.x = 2;
            cornerTwo.y = 0;
            cornerThree.x = 2;
            cornerThree.y = 2;
            cornerFour.x = 0;
            cornerFour.y = 2;

            PartA.Point2D[] square = new PartA.Point2D[] { cornerOne, cornerTwo, cornerThree, cornerFour };

            PartA.Point2D inside = new PartA.Point2D();
            PartA.Point2D outside = new PartA.Point2D();
            PartA.Point2D outsideCorner = new PartA.Point2D(); //In line with corners, testing for false positive

            inside.x = 1;
            inside.y = 1;
            outside.x = -5;
            outside.y = 3;
            outsideCorner.x = -1;
            outsideCorner.y = -1;
            //Checking results
            //Expecting true
            Console.WriteLine(PartA.Point2D.isInsidePolygon(square, inside));
            //Expecting false
            Console.WriteLine(PartA.Point2D.isInsidePolygon(square, outside));
            //Expecting false
            Console.WriteLine(PartA.Point2D.isInsidePolygon(square, outsideCorner));
        }
        static void testPartB()
        {
            //Defining our tournament of 20 players
            String[] players = { "Valentina Ruiz", "Nina Jordan", "Alexander Lucas", "Julie Marks", "Miranda Richards", "Josephine Palmer", "Maxwell Horne", "Angeline Rodgers", "Abbey Woodward", "Kaitlyn Mayo", "Saige Mcneil ", "Andrea Fitzpatrick", "Antoine Castillo", "Giuliana Montes", "Duncan Clayton", "Iris Swanson", "Vanessa Graves", "Carly Rosario", "Myles Mack", "Danika Cross" };
            PartB.Tournament t = new PartB.Tournament(players);
            //Testing Part B Question 1 and 3:
            Console.WriteLine("Part B Question 1 (and 3):");
            String[] matches = t.generateMatches();
            //Checking results
            foreach (String match in matches)
            {
                Console.WriteLine(match);
            }

            //Testing Part B Question 2:
            Console.WriteLine(Environment.NewLine + "Part B Question 2:");
            //Checking results
            Console.WriteLine(t.outputMatches(Environment.CurrentDirectory)); //Expecting true

            //Testing bonus question:
            String[] players19 = { "Valentina Ruiz", "Nina Jordan", "Alexander Lucas", "Julie Marks", "Miranda Richards", "Josephine Palmer", "Maxwell Horne", "Angeline Rodgers", "Abbey Woodward", "Kaitlyn Mayo", "Saige Mcneil ", "Andrea Fitzpatrick", "Antoine Castillo", "Giuliana Montes", "Duncan Clayton", "Iris Swanson", "Vanessa Graves", "Carly Rosario", "Myles Mack" };
            PartB.Tournament t19 = new PartB.Tournament(players19);
            String[] matches19 = t.generateMatches();
            //Checking results
            foreach (String match in matches19)
            {
                Console.WriteLine(match);
            }
            Console.WriteLine(t19.outputMatches(Environment.CurrentDirectory)); //Expecting true

        }
    }
}
