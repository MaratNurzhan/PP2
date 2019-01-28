using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split();
            int[] arr1 = new int[n];
            for(int i=0; i<arr.Length; i++)
            {
                int n1 = int.Parse(arr[i]);
                arr1[i] = n1;
            }

            foreach(var el in arr1)
            {
                Console.Write($"{el} {el} ");
            }
            Console.ReadKey();
        }
    }
}
