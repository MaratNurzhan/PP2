﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Take path to directory where program is executed
            string commonPath = Directory.GetCurrentDirectory();
            string path = Path.Combine(commonPath + "Path");
            //Create directory in the following path if it exists
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //get path to direcotry where we create file
            string path1 = Path.Combine(commonPath + "Path1");
            //cheack if such path exists
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);
            string filename = "transport";
            //if file with such path exists we delete it 
            if (File.Exists(Path.Combine(path1 + filename)))
                File.Delete(Path.Combine(path1 + filename));
           
            using (StreamWriter sw = new StreamWriter(Path.Combine(path + filename)))
            {                
                sw.Write(Path.Combine(path + filename));
            }
            //We move file from old path to new path
            File.Move(Path.Combine(path + filename), Path.Combine(path1 + filename));

            Console.ReadKey();

        }

       
    }
}