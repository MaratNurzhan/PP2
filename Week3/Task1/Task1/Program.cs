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
        /// <summary>
        /// field to show position of current directory/file in showing list
        /// </summary>
        public int cur;
        //size of content of directory(number of directories/files
        public int size;
        //bool variable that is used to define if we conceal or show hiddenfiles
        bool hideHiddenFiles;
        //constructor that sets value for cur(it starts from first file/directory) and that hideHiddenFiles is true
        public FarManager()
        {
            cur = 0;
            hideHiddenFiles = true;
        }
        //to prevent cur to go beyond the contents of directory
        //write function that in case user moves up the file/directory after 0 index,the cur move to the end
        public void Up()
        {
            //cur is decrements because it approach the first file/directory
            cur--;
            if (cur < 0)
                cur = size - 1;
        }
        //Down() in case cur will be incrementing after the last file/directory
        public void Down()
        {
            cur++;
            if (cur == size)
                cur = 0;
        }
        //function to add directory, we send to function the path, 
        //because we must include the name of new directory that will be the part of path
        //then we must access path
        public void AddDirectory(string path) 
        {
            //if the given path(including name) exists, we must prevent creating new directory
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        //Delete directory if it exists in both cases when it is empty or not(true:перегрузка метода)
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
        //RenameDirectory(accepts to paths)
        //method move works also as renaming, because when we change path we can simply change the name 
        //of directory(replacing the part od path with name of directory
        
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
        //function color gets the content of directory(FileSystemInfo fs) and index to define when 
        //the index of fle/directory coincide with the cur(current) what color will be applied to show user where he is
        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cur)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                //to differentiate directories and files we color the directories and files
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
            //running through fileSystemInfos we check if the file is hidden, if it is we skip it and reduce size of fileSystemInfos
            for (int i = 0, j = 1; i < fileSystemInfos.Length; i ++)
            {
                FileSystemInfo fs = fileSystemInfos[i];
                if (hideHiddenFiles && fs.Name.StartsWith("."))
                {
                    size--;
                    continue;
                }
                //if fs is not hidden call function Color() sending the file and its index
                //so it will be shown according to conditions in Color()
                Color(fs, index);
                //Output on console name of fs 
                Console.WriteLine((j++) + ": " + fs.Name);
                //increment index
                index++;
            }
        }
        public void Show(FileSystemInfo[] files)
        {
            for (int i = 0, j = 1; i < files.Length; i++)
            {
                FileSystemInfo fs = files[i];
                Color(fs, i);
                Console.WriteLine((j++) + ": " + fs.Name);
            }
        }

        /// <summary>
        /// return FileSystemInfo that shows cursor in parent directory
        /// </summary>
        /// <param name="parentDirectory"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public FileSystemInfo GetFSI(DirectoryInfo parentDirectory, int cursor)
        {
            for (int i = 0, k = 0; i < parentDirectory.GetFileSystemInfos().Length; i++)
            {
                if (hideHiddenFiles && parentDirectory.GetFileSystemInfos()[i].Name.StartsWith("."))
                    continue;
                if (cursor == k)
                    return parentDirectory.GetFileSystemInfos()[i];

                k++;
            }

            return null;
        }

        public void ClearConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            //Clear() used to clear console after each pressing of key to hide history
            Console.Clear();
        }

        public FileSystemInfo[] GetShowingList(DirectoryInfo parentDirectory)
        {
            List<FileSystemInfo> showingList = new List<FileSystemInfo>();
            for (int i = 0; i < parentDirectory.GetFileSystemInfos().Length; i++)
            {
                FileSystemInfo file = parentDirectory.GetFileSystemInfos()[i];
                bool isFileHidden = hideHiddenFiles ? file.Name.StartsWith(".") : false;
                if (!isFileHidden) showingList.Add(file);
            }
            size = showingList.Count();
            return showingList.ToArray();
        }

        public void Start(string path)
        {
            DirectoryInfo parentDirectory = new DirectoryInfo(path);
            FileSystemInfo[] showingArray = GetShowingList(parentDirectory);
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                ClearConsole();
                Console.WriteLine("C - create,\tD - delete,\tR - rename");
                //output contents as in Show()
                //Show(path);
                Show(showingArray);
                //Read the key we press
                consoleKey = Console.ReadKey();

                switch(consoleKey.Key)
                {
                    case ConsoleKey.Escape:
                        //go the parent directory 
                        //cur is positioned at 0
                        //path changes
                        cur = 0;
                        parentDirectory = parentDirectory.Parent;
                        path = parentDirectory.FullName;
                        showingArray = GetShowingList(parentDirectory);
                        break;
                    case ConsoleKey.UpArrow:
                        Up();
                        break;
                    case ConsoleKey.DownArrow:
                        Down();
                        break;
                    case ConsoleKey.RightArrow:
                        //show hidden files
                        hideHiddenFiles = false;
                        showingArray = GetShowingList(parentDirectory);
                        break;
                    case ConsoleKey.LeftArrow:
                        //conceal hidden files
                        hideHiddenFiles = true;
                        showingArray = GetShowingList(parentDirectory);
                        break;
                    case ConsoleKey.Enter:
                        //the FileSystemInfo fs is returned by function "GetFSI()"
                        fs = showingArray[cur];// GetFSI(parentDirectory, cur);
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            //if press "enter" to directory path changes
                            cur = 0;
                            parentDirectory = new DirectoryInfo(fs.FullName);
                            showingArray = GetShowingList(parentDirectory);
                            path = fs.FullName;
                        }
                        else
                        {
                            //if we press "enter" to a file, we clear console to output the content of the file
                            ClearConsole();
                            //"using" closes the stream
                            using(StreamReader sr = new StreamReader(fs.FullName))
                            {
                                //we output on console what we read from file
                                Console.WriteLine(sr.ReadToEnd());
                                Console.ReadKey();
                            }

                        }
                        break;
                    case ConsoleKey.C:
                        //clear console and input the name of derectory we add
                        ClearConsole();
                        Console.WriteLine("Adding new directory");
                        Console.Write("Enter directory name: ");
                        string directoryName = Console.ReadLine();
                        
                        AddDirectory(Path.Combine(path,directoryName));
                        break;
                    case ConsoleKey.D:
                        fs = showingArray[cur];// GetFSI(parentDirectory, cur);
                        if (fs.GetType() == typeof(DirectoryInfo))
                            DeleteDirectory(fs.FullName);
                        else
                            DeleteFile(fs.FullName);
                        break;
                    case ConsoleKey.R:
                        fs = showingArray[cur];// GetFSI(parentDirectory, cur);
                        ClearConsole();
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

