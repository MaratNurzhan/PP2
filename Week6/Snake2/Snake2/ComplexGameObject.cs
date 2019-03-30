using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    public abstract class ComplexGameObject : GameObject
    {
        public List<Point> Points { get; set; }
        public ComplexGameObject(List<Point> points, char sign, ConsoleColor color) : base(sign, color)
        {
            Points = points;
        }

        public ComplexGameObject() : base()
        {

        }

        public override void Draw()
        {
            //Console.ForegroundColor = color;
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            foreach (var item in Points) 
            {
                try
                {
                    //Console.SetCursorPosition(item.x, item.y);
                    //Console.Write(sign);
                    Console.SetCursorPosition((int)(Game.MarginLeft + item.x) * 2, (int)(Game.MarginTop + item.y));
                    Console.Write("  ");
                }
                catch (ArgumentOutOfRangeException){ }
            }
            Console.BackgroundColor = defaultColor;
        }

        public void Clear()
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var item in Points)
            {
                Console.SetCursorPosition((int)(Game.MarginLeft + item.x) * 2, (int)(Game.MarginTop + item.y));
                Console.Write("  ");
            }
            Console.BackgroundColor = defaultColor;
        }
    }
}
