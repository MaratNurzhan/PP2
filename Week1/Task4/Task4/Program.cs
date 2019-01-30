using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Convert string from input into int
            int n = int.Parse(Console.ReadLine());
            //initialize 2d array (nxn)
            string[,] arr = new string[n,n];

            for(int i=0; i < n; i++)
            {
                //with every i-th row the number of elements in them increments
                for(int j=0; j<i+1; j++)
                {
                    //put string into arr[i,j] 
                    arr[i, j] ="[*]";
                }
               
            }
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                //After each i-th row massive starts from new line
                Console.WriteLine();
            }
           
            Console.ReadKey();
        }
    }
}
