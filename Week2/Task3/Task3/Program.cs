using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    //Change
    class Program
    {
        static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write(" ");
        }

        static void Ex(DirectoryInfo directory, int level)
        {
            FileInfo[] file = directory.GetFiles();
            DirectoryInfo[] dir = directory.GetDirectories();

            foreach(var f in file)
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            foreach(var d in dir)
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                Ex(d, level + 1);
            }
        }
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            DirectoryInfo d = new DirectoryInfo("@" + path);
            Ex(d, 0);
            Console.ReadKey();
        }
    }
}
