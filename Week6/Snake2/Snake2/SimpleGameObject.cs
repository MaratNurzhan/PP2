using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    public abstract class SimpleGameObject : GameObject
    {
        public Point Point { get; set; }
        public SimpleGameObject(Point point, char sign, ConsoleColor color) : base(sign, color)
        {
            this.Point = point;
        }
        public SimpleGameObject() : base()
        {

        }

        public override void Draw()
        {
            //Console.ForegroundColor = color;
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            //Console.SetCursorPosition(Point.x, Point.y);
            //Console.Write(sign);
            Console.SetCursorPosition((int)(Game.MarginLeft + Point.x) * 2, (int)(Game.MarginTop + Point.y));
            Console.Write("  ");
            Console.BackgroundColor = defaultColor;
        }

        public void Clear()
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition((int)(Game.MarginLeft + Point.x) * 2, (int)(Game.MarginTop + Point.y));
            Console.Write("  ");
            Console.BackgroundColor = defaultColor;
        }
    }
}
