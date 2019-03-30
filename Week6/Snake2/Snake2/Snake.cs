using System;
using System.Collections.Generic;

namespace Snake2
{
    public class Snake : ComplexGameObject
    {
        public enum Direction
        {
            RIGHT, LEFT, UP, DOWN, NONE
        }

        Direction direction = Direction.NONE;

        Direction lastMoveDirection = Direction.NONE;

        //public float Speed { get; set; }

        public Snake()
        {
        }

        public Snake(List<Point> points, char sign, ConsoleColor color) : base(points, sign, color)
        {
            //Speed = .5f;
        }

        public void Move(long spendMills)
        {
            if (direction == Direction.NONE) return;

            Clear();

            //float movepoint = speed * spendmills / 1000.0f;
            //float diffx = points[0].x - (int)points[0].x;
            //int movecellx = diffx < 0.5f ? (int)math.round(movepoint + diffx) : (int)math.round(movepoint - 1.5f - diffx);
            //float diffy = points[0].y - (int)points[0].y;
            //int movecelly = diffy < 0.5f ? (int)math.round(movepoint + diffy) : (int)math.round(movepoint - 1.5f - diffy);

            //int movecell = math.Max(moveCellX, moveCellY);

            for (int i = Points.Count - 1; i > 0/*MoveCell-1*/; i--)
            {
                Points[i].x = Points[i - 1].x;
                Points[i].y = Points[i - 1].y;
            }

            switch (direction)
            {
                case Direction.UP:
                    //for(int i = Math.Min(moveCell - 1, Points.Count-1); i >= 0; i --)
                    //{
                    //    Points[i].y = Points[0].y - (moveCell - i);
                    //}
                    Points[0].y--;
                    lastMoveDirection = Direction.UP;
                    if (Points[0].y < 0)
                        Points[0].y = Game.Height - 1;
                    break;
                case Direction.DOWN:
                    //for (int i = Math.Min(moveCell - 1, Points.Count-1); i >= 0; i--)
                    //{
                    //    Points[i].y = Points[0].y + (moveCell - i);
                    //}
                    Points[0].y++;
                    lastMoveDirection = Direction.DOWN;
                    if (Points[0].y == Game.Height)
                        Points[0].y = 0;
                    break;
                case Direction.RIGHT:
                    //for (int i = Math.Min(moveCell - 1, Points.Count-1); i >= 0; i--)
                    //{
                    //    Points[i].x = Points[0].x + (moveCell - i);
                    //}
                    Points[0].x++;
                    lastMoveDirection = Direction.RIGHT;
                    if (Points[0].x == Game.Width)
                        Points[0].x = 0;
                    break;
                case Direction.LEFT:
                    //for (int i = Math.Min(moveCell - 1, Points.Count-1); i >= 0; i--)
                    //{
                    //    Points[i].x = Points[0].x - (moveCell - i);
                    //}
                    Points[0].x--;
                    lastMoveDirection = Direction.LEFT;
                    if (Points[0].x < 0)
                        Points[0].x = Game.Width - 1;
                    break;
            }
        }

        public void Move()
        {
            if (direction == Direction.NONE) return;

            Clear();
            for (int i = Points.Count - 1; i > 0; i--)
            {
                Points[i].x = Points[i - 1].x;
                Points[i].y = Points[i - 1].y;
            }

            switch (direction)
            {
                case Direction.UP:
                    Points[0].y--;
                    lastMoveDirection = Direction.UP;
                    if (Points[0].y < 0)
                        Points[0].y = Game.Height-1;
                    break;
                case Direction.DOWN:
                    Points[0].y++;
                    lastMoveDirection = Direction.DOWN;
                    if (Points[0].y == Game.Height)
                        Points[0].y = 0;
                    break;
                case Direction.RIGHT:
                    Points[0].x++;
                    lastMoveDirection = Direction.RIGHT;
                    if (Points[0].x == Game.Width)
                        Points[0].x = 0;
                    break;
                case Direction.LEFT:
                    Points[0].x--;
                    lastMoveDirection = Direction.LEFT;
                    if (Points[0].x < 0)
                        Points[0].x = Game.Width-1;
                    break;
            }
        }

        public void ChangeDirection1(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.T:
                    if (lastMoveDirection == Direction.DOWN) break;
                    direction = Direction.UP;
                    break;
                case ConsoleKey.V:
                    if (lastMoveDirection == Direction.UP) break;
                    direction = Direction.DOWN;
                    break;
                case ConsoleKey.F:
                    if (lastMoveDirection == Direction.RIGHT) break;
                    direction = Direction.LEFT;
                    break;
                case ConsoleKey.G:
                    if (lastMoveDirection == Direction.LEFT) break;
                    direction = Direction.RIGHT;
                    break;
            }
        }

        public void ChangeDirection(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (lastMoveDirection == Direction.DOWN) break;
                    direction = Direction.UP;
                    break;
                case ConsoleKey.DownArrow:
                    if (lastMoveDirection == Direction.UP) break;
                    direction = Direction.DOWN;
                    break;
                case ConsoleKey.LeftArrow:
                    if (lastMoveDirection == Direction.RIGHT) break;
                    direction = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    if (lastMoveDirection == Direction.LEFT) break;
                    direction = Direction.RIGHT;
                    break;
            }
        }

        public void NoDirection()
        {
            direction = Direction.NONE;
        }

        public void SnakeGenerate(int _x, int _y, int l)
        {
            Random random = new Random();
            direction = Direction.NONE;
            Points = new List<Point>();
            for (int i = 0; i < l; i++)
            {
                Points.Add(new Point(_x, _y + i));
            }
        }

        //public void SnakeGenerates(Snake snake)
        //{
        //    for(int i=0; i<snake.Points.Count; i++)
        //    {
        //        Random random
        //    }
        //}
    }

}


