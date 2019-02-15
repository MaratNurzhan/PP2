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
            //cycle from 2 to 1 is wrong
            if (a == 1)
                return false;
            if (a == 2)
                return true;
           
            //if a is divisible by any number less than sqrt(a) it is not prime=>false    
            for(int i=2; i<=Math.Ceiling(Math.Sqrt(a)); i++)
            
                if (a % i == 0)
                    return false;
            
            //if it pass check then it is prime
            return true;
        }


        static void Main(string[] args)
        {
            //Open stream to the file
            StreamReader sr = new StreamReader(@"C: \Users\Lenovo\Desktop\rcs\files\input_1.txt");
            //Read the line from file and put it in string s
            string s = sr.ReadLine();
            //split string into array of integers(devide by sign in brackets)
            string[] arr = s.Split();
            //initilaize List to put there all primes
            List<int>list = new List<int>();
            foreach(var el in arr)
            {
                //Convert to int
                int n = int.Parse(el);
                //if satisfies function Prime()
                //add to List list
                if (Prime(n))
                    list.Add(n);
            }
            //close the stream
            sr.Close();
            //output in other file the content of list
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
