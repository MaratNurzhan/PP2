using System;
using System.Collections.Generic;

namespace Snake2
{
    public class Point
    {
        public float x, y;
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point()
        {

        }

        public static bool operator ==(Point p1, Point p2)
        {
            return Math.Round(p1.x) == Math.Round(p2.x) && Math.Round(p1.y) == Math.Round(p2.y);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        public bool IsCollide(List<Point> list)
        {
            foreach (var item in list)
                if (this == item)
                    return true;
            return false;
        }

        public static bool IsCollide(List<Point> points1, List<Point> points2)
        {
            foreach (var p1 in points1)
                if (p1.IsCollide(points2))
                    return true;
            return false;
        }
    }

}
