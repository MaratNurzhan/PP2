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
        public static bool Palin(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                //check if opposite elements are same
                if (s[i] != s[s.Length - i - 1])
                    return false;
            }
            //if it is palindrome(it passes check for opposite elements) 
            return true;

        }
        static void Main(string[] args)
        {
            //open stream of data to the file input.txt
            StreamReader sr = new StreamReader(@"C:\Users\Lenovo\Desktop\rcs\files\input.txt.txt");
            //string s = System.IO.File.ReadAllText(@"C:\Users\Lenovo\Desktop\rcs\files\input.txt.txt");
            //read only line from the file
            string s = sr.ReadLine();
            
           
           //if it satisfies condition for being palindrome, output "Yes" 
                if (Palin(s))
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");

           //Close stream(поток данных)
            sr.Close();
            Console.ReadKey();

        }
    }

  
}
