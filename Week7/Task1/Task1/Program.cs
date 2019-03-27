using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[4];
            for (int i = 1; i <= 3; i++)
            {
                threads[i] = new Thread(PrintName);
                threads[i].Name = "Thread" + " " + i.ToString();

                threads[i].Start();
            }

            Console.ReadKey();

        }

        static void PrintName()
        {
            for (int i = 0; i < 3; i++)
                Console.WriteLine(Thread.CurrentThread.Name + " ");
        }
    }
}

