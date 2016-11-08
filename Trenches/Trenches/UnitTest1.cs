using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trenches
{
    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var directions = new string[] { "right", "right", "up", "left", "down", "down", "left", "left" };
            Assert.AreEqual(new Point(1,0),CalculatePointOfIntersection( directions));
        }
        Point CalculatePointOfIntersection(string[] directions)
        {
            var pointArray = new Point[directions.Length + 1];
            pointArray[0].x = 0;
            pointArray[0].y = 0;
            GeneratePointsOfCoordinates(directions, pointArray);
            Point pointOfIntersection = CheckForPoint(pointArray);
            return pointOfIntersection;
        }

        private static void GeneratePointsOfCoordinates(string[] directions, Point[] pointArray)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                pointArray[i + 1].x = pointArray[i].x;
                pointArray[i + 1].y = pointArray[i].y;

                if (directions[i] == "right") pointArray[i + 1].x += 1;
                else if (directions[i] == "left") pointArray[i + 1].x -= 1;
                else if (directions[i] == "up") pointArray[i + 1].y += 1;
                else if (directions[i] == "down") pointArray[i + 1].y -= 1;
            }
        }

        Point CheckForPoint(Point[] pointArray)
        {
            var pointOfIntersection = new Point();
            for (int i = 0; i < pointArray.Length - 1; i++)
            {
                for (int j = i + 1; j < pointArray.Length; j++)
                {
                    if (pointArray[j].x == pointArray[i].x && pointArray[j].y == pointArray[i].y)
                    {
                        pointOfIntersection = pointArray[j];
                        return pointOfIntersection;
                    }                   
                }
            }
            return pointOfIntersection;        
        }
    }
}
