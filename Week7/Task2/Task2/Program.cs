using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task2
{
    class MyThread
    {
        public Thread threadField;

        public MyThread(string name)
        {
            threadField = new Thread(StartThread);
            threadField.Name = name;
            threadField.Start();
        }



        public void StartThread()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " " + "выводит" + " " + (i + 1));
                Thread.Sleep(0);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " " + "завершился");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");


            t1.StartThread();
            t2.StartThread();

            Console.Read();
        }
    }
}
