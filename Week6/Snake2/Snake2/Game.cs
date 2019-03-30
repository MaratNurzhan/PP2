using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace Snake2
{
    [Serializable]
    public class Game
    {
        public List<GameObject> gameObjects;
        public List<Snake> snakes;
        public Snake snake1;
        public Snake snake2;
        public Food food;
        public Wall wall;
        public bool Alive;
        public bool CloseGame;
        public int score1,score2;

        //int showMessageToMills = 0;
        public bool showMessage = false;
        public string message = "";
        public int callDraw = 10000000;
        public int initCallDraw = 10000000;
        public int diffDraw;

        public int speed = 4;
        
        public int X;
        public int Y;

        public static int MarginLeft { get; set; } = 5;
        public static int MarginTop { get; set; } = 5;
        public static int Width { get; set; } = 50;
        public static int Height { get; set; } = 25;

        public long LastMoveMills { get; set; }

        public Game()
        {
            gameObjects = new List<GameObject>();
            snakes = new List<Snake>();
            List<Point> snakeBody1 = new List<Point>
            {
                new Point(20,10),
                new Point(20,11),
                new Point(20,12)
            };
            List<Point> snakeBody2 = new List<Point>
            {
                new Point(30,12),
                new Point(30,13),
                new Point(30,14)
            };
            snake1 = new Snake(snakeBody1, '*', ConsoleColor.Red);
            snake2 = new Snake(snakeBody2, '*', ConsoleColor.Blue);
            food = new Food('o', ConsoleColor.Green);
            wall = new Wall('#', ConsoleColor.DarkYellow);
            while (food.Point.IsCollide(snake1.Points) || food.Point.IsCollide(wall.Points) || food.Point.IsCollide(snake2.Points))
                food.Generate();

            if (food.Point.IsCollide(snake1.Points) || food.Point.IsCollide(wall.Points) || food.Point.IsCollide(snake2.Points))
            {
                food.Generate();
                if (snake1.Points.Count % 5 == 0 || snake2.Points.Count % 5 == 0)
                {
                    wall.NewLevel();
                    if (Point.IsCollide(snake1.Points, wall.Points) || Point.IsCollide(snake2.Points, wall.Points))
                    {
                        Random random = new Random();
                        int a2 = random.Next(1, Game.Width);
                        int b2 = random.Next(1, Game.Height);
                        snake1.SnakeGenerate(a2, b2, snake1.Points.Count);
                        snake2.SnakeGenerate(a2, b2, snake2.Points.Count);
                    }
                    snake1.NoDirection();
                    snake2.NoDirection();
                }
            }

            gameObjects.Add(snake1);
            gameObjects.Add(snake2);
            gameObjects.Add(food);
            gameObjects.Add(wall);

            snakes.Add(snake1);
            snakes.Add(snake2);

            score1 = 0;
            score2 = 0;
            Alive = true;
            CloseGame = false;
        }

        public string userName1;
        public string userName2;
        public void Start()
        {
            DrawGameField();
            string welcomePlayer1 = "Enter name of player1: ";
            string welcomePlayer2 = "Enter name of player2: ";
            Console.SetCursorPosition(MarginLeft*2 + Width - welcomePlayer1.Length, MarginTop + Height / 2 );
            Console.Write(welcomePlayer1);
            userName1 = Console.ReadLine();
            Console.SetCursorPosition(MarginLeft*2 +Width - welcomePlayer2.Length, MarginTop + Height / 2 + 1);
            Console.Write(welcomePlayer1);
            userName2 = Console.ReadLine();

            Console.Clear();
            DrawGameField();
            Thread thread = new Thread(MoveSnake);
            thread.Start();
           
            

            bool startAgain = true;

            while (startAgain)
            {
                do
                {                    
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape) break;
                    snake1.ChangeDirection(key);
                    snake2.ChangeDirection1(key);
                   
                    if (key.Key == ConsoleKey.S)
                    {
                        SaveGame(this);
                        ShowMessage("Saved", 5, 29, 25);
                    }
                } while (Alive);

                do
                {                   
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        DrawGameField();
                        Random random = new Random();
                        int a = random.Next(1, Game.Width);
                        int b = random.Next(1, Game.Height);
                        snake1.SnakeGenerate(a,b,3);
                        int a1 = random.Next(1, Game.Width);
                        int b1 = random.Next(1, Game.Height);
                        snake2.SnakeGenerate(a1,b1,3);
                        snake1.NoDirection();
                        snake2.NoDirection();
                        wall.ReloadLevel();
                        Alive = true;
                        break;
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        Game game = LoadGame();
                        snake1 = game.snake1;
                        snake2 = game.snake2;
                        snakes = new List<Snake> { snake1, snake2 };
                        wall = game.wall;
                        food = game.food;
                        score1 = game.score1;
                        score2 = game.score2;
                        gameObjects = new List<GameObject>
                        {
                            snake1,
                            snake2,
                            wall,
                            food
                        };
                        Alive = true;
                        CloseGame = false;
                        startAgain = true;
                        Console.Clear();
                        DrawGameField();
                        break;
                    }
                    else if (key.Key == ConsoleKey.X)
                    {
                        startAgain = false;
                        CloseGame = true;
                        break;
                    }
                } while (true);
            }
        }
        public void DrawGameField()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = -1; i <= Width; i++)
            {
                Console.SetCursorPosition((MarginLeft + i) * 2, MarginTop-1);
                Console.Write("  ");
                Console.SetCursorPosition((MarginLeft + i) * 2, MarginTop + Height);
                Console.Write("  ");
            }
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition((MarginLeft - 1) * 2, MarginTop + i);
                Console.Write("  ");
                Console.SetCursorPosition((MarginLeft + Width) * 2, MarginTop + i);
                Console.Write("  ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void MoveSnake()
        { 
            while (!CloseGame)
            {
                if (!Alive)
                {
                    ShowMenu();
                    Thread.Sleep(1000);
                    continue;
                }
                snake1.Move();
                snake2.Move();

                if (food.Point.IsCollide(snake1.Points))
                {
                    snake1.Points.Add(new Point(0, 0));
                    score1++;
                    //Thread.Sleep(n/2);
                    //Accelerate(n/2);
                }
                if (food.Point.IsCollide(snake2.Points))
                {
                    snake2.Points.Add(new Point(0, 0));
                    score2++;
                    //Accelerate(n/2);
                    //Thread.Sleep(n/2);
                }
                //if (food.Point.IsCollide(snake2.Points) || food.Point.IsCollide(snake1.Points))
                //        Accelerate(256);

                if (snake1.Points.Count % 7 == 0 || snake2.Points.Count % 7 == 0)
                    SuperFruit();
                if (food.Point.IsCollide(snake1.Points) || food.Point.IsCollide(wall.Points) || food.Point.IsCollide(snake2.Points))
                {
                    food.Generate();
                    if (snake1.Points.Count % 5 == 0 || snake2.Points.Count % 5 == 0)
                    {
                        wall.NewLevel();
                        speed++;
                        if(Point.IsCollide(snake1.Points,wall.Points)|| Point.IsCollide(snake2.Points, wall.Points))
                        {
                            Random random = new Random();
                            int a2 = random.Next(1, Game.Width);
                            int b2 = random.Next(1, Game.Height);
                            snake1.SnakeGenerate(a2, b2, snake1.Points.Count);
                            snake2.SnakeGenerate(a2, b2, snake2.Points.Count);
                        }
                        snake1.NoDirection();
                        snake2.NoDirection();
                    }
                }

                for (int i = 0; i < snakes.Count; i++)
                {
                    bool collideWithWall = Point.IsCollide(wall.Points, snakes[i].Points);
                    bool collideToItSelf = snakes[i].Points.Count > 3 && snakes[i].Points[0].IsCollide(snakes[i].Points.GetRange(3, snakes[i].Points.Count - 3));
                    bool collideSnakes = Point.IsCollide(snake1.Points, snake2.Points);
                    if ( collideWithWall || collideToItSelf || collideSnakes)
                    {
                        Alive = false;
                    }
                }
                Draw();
                DrawResult();
                //SnakeAccelerate();

                Accelerate();
            }          
        }
        //int initCallDraw = 10000000;
        
        public void Draw()
        {
            //Console.Clear();
            //DrawGameField();
            foreach (GameObject gb in gameObjects)
            {
                gb.Draw();
                if (gb is Snake)
                    callDraw--;
            }
            Console.SetCursorPosition(0,0);
        }

        public void Accelerate()
        {
            Thread.Sleep(1000/speed);
        }

        public void SaveGame(Game game)
        {
            if (!Directory.Exists("GameStore")) Directory.CreateDirectory("GameStore");
            File.Delete("GameStore/GameState.txt");
            using (FileStream fs = new FileStream("GameStore/GameState.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Game));
                xs.Serialize(fs, game);
            }
        }

        public Game LoadGame()
        {
            FileStream fs = null;
            Game game = null;
            if (!Directory.Exists("GameStore")) return null;
            if (!File.Exists("GameStore/GameState.txt")) return null;
            try
            {
                fs = new FileStream("GameStore/GameState.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(Game));
                 game = xs.Deserialize(fs) as Game;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                fs.Close();
            }

            return game;
        }

        public void ShowMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(55, 8);
            Console.WriteLine("GAME OVER");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(50, 9);
            Console.WriteLine($"{userName1}'s score is {score1}");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine($"{userName2}'s score is {score2}");
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(50, 11);
            Console.WriteLine("Press X to quit");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(50, 12);
            Console.WriteLine("Press N to start new game\t");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Press D to resume game\n");
        }

        public void DrawResult()
        {
            Console.SetCursorPosition(MarginLeft * 2, MarginTop / 2);
            Console.WriteLine(userName1 + " " + score1);

            string player2info = userName2 + " " + score2;
            Console.SetCursorPosition((MarginLeft + Width) * 2 - player2info.Length, MarginTop / 2);
            Console.WriteLine(userName2+" "+score2);
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string saveGameInfo = "Press S to save game";
            Console.SetCursorPosition(MarginLeft * 2 + Width - saveGameInfo.Length, 1);
            Console.WriteLine(saveGameInfo);

            diffDraw = initCallDraw - callDraw;
            if (showMessage)
            {
                if (diffDraw<=0)
                {
                    showMessage = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(X,Y);
                    Console.WriteLine(message);
                    diffDraw -= 1;
                    //showMessageToMills -= 100;
                }
            }
        }

        public void ShowMessage(string message, int diffDraw, int X, int Y ,int initCallDraw = 10000000)
        {
            this.message = message;
            this.callDraw = callDraw;
            //showMessageToMills = mills;
            diffDraw = initCallDraw - callDraw;
            showMessage = true;
            this.X = X;
            this.Y = Y;
        }

        //public void SnakeAccelerate()
        //{
            //if (wall.GameLevel == 0)
                //Thread.Sleep(100);
            //else if (wall.GameLevel == 1)
                //Thread.Sleep(10);
            //else if (wall.GameLevel == 2)
                //Thread.Sleep(5);
        //}

        public void SuperFruit()
        {
                Console.SetCursorPosition(60, 25);
                ShowMessage("SuperFruit(+10point)",5, 60, 3);
                if(food.Point.IsCollide(snake1.Points)) 
                {
                    snake1.Points.Add(new Point(0, 0));
                    score1 += 10;
                }
                else if (food.Point.IsCollide(snake2.Points))
                {
                    snake2.Points.Add(new Point(0, 0));
                    score2 += 10;
                }
        }
    }
}
