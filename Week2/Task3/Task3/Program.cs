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
        //function accepts directory and level(количество отступов)
        static void Print(DirectoryInfo directory, int level)
        {
            //we put all files and directroies from basic directory in two separate "arrays of files"
            FileInfo[] file = directory.GetFiles();
            DirectoryInfo[] dir = directory.GetDirectories();
            //for each file we print its name
            foreach(var f in file)
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            //for each directory we print its name and recursively call function again to show the inside of the directory, its level(отступ) will increase
            foreach(var d in dir)
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                Print(d, level + 1);
            }
        }
        static void Main(string[] args)
        {
            //Take apth from console
            string path = Console.ReadLine();
            //Get directory according to path
            DirectoryInfo d = new DirectoryInfo("@" + path);
            Print(d, 0);
            Console.ReadKey();
        }
    }
}
