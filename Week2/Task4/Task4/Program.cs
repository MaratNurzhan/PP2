using System;
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
           

            string commonPath = Directory.GetCurrentDirectory();
            string path = Path.Combine(commonPath + "Path");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string path1 = Path.Combine(commonPath + "Path1");
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);
            string filename = "transport.txt";
            if (File.Exists(Path.Combine(path1 + filename)))
                File.Delete(Path.Combine(path1 + filename));

            using (StreamWriter sw = new StreamWriter(Path.Combine(path + filename)))
            {                
                sw.Write(Path.Combine(path + filename));
            }
            File.Move(Path.Combine(path + filename), Path.Combine(path1 + filename));

            Console.ReadKey();

        }

       
    }
}