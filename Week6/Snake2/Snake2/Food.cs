using System;
namespace Snake2
{
    public class Food : SimpleGameObject
    {
        public Food(Point point, char sign, ConsoleColor color) : base(point, sign, color)
        {
        }

        public Food() : base()
        {

        }

        public Food(char sign, ConsoleColor color) : base(new Point(0,0), sign, color)
        {
            Generate();
        }

        public void Generate()
        {
            Random random = new Random();
            Point.x = random.Next(1, Game.Width);
            Point.y = random.Next(1, Game.Height);
        }

       
    }

}
