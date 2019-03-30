using System;
using System.Collections.Generic;
using System.IO;
namespace Snake2
{
    public class Wall : ComplexGameObject
    {
        public int GameLevel { get; set; }
        public int MaxLevelCount
        {
            get
            {
                return levelFileNames.Count;
            }
        }

        public List<string> levelFileNames = null;

        public Wall(char sign, ConsoleColor color) : base(new List<Point>(), sign, color)
        {
            GameLevel = 0;
            InitLevelFileNames();
            LoadLevel();
        }

        public Wall() : base()
        {

        }

        public void InitLevelFileNames()
        {
            levelFileNames = new List<string>();
            int i = 0;
            while (true)
            {
                if (File.Exists("level" + i + ".txt"))
                {
                    levelFileNames.Add("level" + i + ".txt");
                    i++;
                }
                else
                {
                    break;
                }
            }
        }

        public void LoadLevel()
        {
            Points = new List<Point>();
            string fileName = levelFileNames[GameLevel];

            StreamReader sr = new StreamReader(fileName);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '#')
                        Points.Add(new Point(j, i));

        }

        public bool NewLevel()
        {
            if (GameLevel == MaxLevelCount - 1)
                return false;
            Clear();
            GameLevel++;
            LoadLevel();
            return true;
        }

        public void ReloadLevel()
        {
            GameLevel = 0;
            LoadLevel();
        }
    }
}

