using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static bool Prime(int a)
        {
            if (a == 1)
                return false;
            if (a == 2)
                return true;
                
            for(int i=2; i<Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }


        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C: \Users\Lenovo\Desktop\rcs\files\input_1.txt");
            string s = sr.ReadLine();
            string[] arr = s.Split();
            List<int>list = new List<int>();
            foreach(var el in arr)
            {
                int n = int.Parse(el);

                if (Prime(n))
                    list.Add(n);
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(@"C: \Users\Lenovo\Desktop\rcs\files\input_2.txt");
            foreach(var l in list)
            {
                sw.Write(l + " ");
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}
