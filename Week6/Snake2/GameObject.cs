using System;
using System.Collections.Generic;
namespace Snake2
{
    public class GameObject
    {
        public char sign;
        public ConsoleColor color;
        public List<Point> body;
        public GameObject(int x,int y, char sign,ConsoleColor color)
        {
            body = new List<Point>
            {
                new Point(x,y)
            };

            this.sign = sign;
            this.color = color;
        }
        
        public void Draw()
        {
            Console.Foreground = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y)
            }

        }
    }
}

