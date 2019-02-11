using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            FarManager farManager = new FarManager();

            farManager.Start(Directory.GetCurrentDirectory());
        }
    }

    class FarManager
    {
        public int cur;
        public int size;
        bool hideHiddenFiles;
        public FarManager()
        {
            cur = 0;
            hideHiddenFiles = true;
        }

        public void Up()
        {
            cur--;
            if (cur < 0)
                cur = size - 1;
        }

        public void Down()
        {
            cur++;
            if (cur == size)
                cur = 0;
        }

        public void AddDirectory(string path) 
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        public void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }
        public void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public void RenameDirectory(string path, string newPath)
        {
            if (Directory.Exists(path))
                Directory.Move(path, newPath);

        }
        public void RenameFile(string path,string newPath)
        {
            if (File.Exists(path))
                File.Move(path, newPath);
        }
        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cur)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
        }

        public void Show(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            size = fileSystemInfos.Length;
            int index = 0;
            foreach (FileSystemInfo fs in fileSystemInfos)
            {
                if (hideHiddenFiles && fs.Name.StartsWith("."))
                {
                    size--;
                    continue;
                }

                Color(fs, index);

                Console.WriteLine(fs.Name);
                index++;
            }
        }

        public FileSystemInfo GetFSI(DirectoryInfo directory, int cursor)
        {
            FileSystemInfo fs = null;
            int k = 0;
            for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
            {
                if (hideHiddenFiles && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                    continue;
                if (cursor == k)
                {
                    fs = directory.GetFileSystemInfos()[i];
                    break;
                }
                k++;
            }
            return fs;
        }

        public void Start(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("C - create,\tD - delete,\tR - rename");
                Show(path);
                consoleKey = Console.ReadKey();

                switch(consoleKey.Key)
                {
                    case ConsoleKey.Escape:
                        cur = 0;
                        directory = directory.Parent;
                        path = directory.FullName;
                        break;
                    case ConsoleKey.UpArrow:
                        Up();
                        break;
                    case ConsoleKey.DownArrow:
                        Down();
                        break;
                    case ConsoleKey.RightArrow:
                        hideHiddenFiles = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        hideHiddenFiles = true;
                        break;
                    case ConsoleKey.Enter:
                        fs = GetFSI(directory, cur);
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            cur = 0;
                            directory = new DirectoryInfo(fs.FullName);
                            path = fs.FullName;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            using(StreamReader sr = new StreamReader(fs.FullName))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                                Console.ReadKey();
                            }

                        }
                        break;
                    case ConsoleKey.C:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine("Adding new directory");
                        Console.Write("Enter directory name: ");
                        string directoryName = Console.ReadLine();
                        AddDirectory(Path.Combine(path,directoryName));
                        break;
                    case ConsoleKey.D:
                        fs = GetFSI(directory, cur);
                        if (fs.GetType() == typeof(DirectoryInfo))
                            DeleteDirectory(fs.FullName);
                        else
                            DeleteFile(fs.FullName);
                        break;
                    case ConsoleKey.R:
                        fs = GetFSI(directory, cur);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine($"Rename \"{fs.Name}\"");
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        if (fs.GetType() == typeof(DirectoryInfo))
                            RenameDirectory(fs.FullName, Path.Combine(path, newName));
                        else
                        {
                            RenameFile(fs.FullName, Path.Combine(path, newName));
                        }
                        break;

                }
            }
        }
    }
}

