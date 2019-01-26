using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split();

            int[] arr1 = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                int n1 = int.Parse(arr[i]);
                arr1[i] = n1;
            }
            int cnt = 0;
            List<int> list = new List<int>();
            for(int i=0; i<arr1.Length; i++)
            {
                if (isPrime(arr1[i]))
                {
                    cnt++;
                    list.Add(arr1[i]);
                }
            }

            Console.WriteLine(cnt);
            foreach (int item in list)
                Console.Write(item + " ");

            Console.ReadKey();
        }

        static bool isPrime(int n)
        {
            // comments
            if (n <= 0) return false;
            if (n == 1) return false;
            if (n == 2) return true;
            for(int i = 2; i <= Math.Ceiling(Math.Sqrt(n)); i++)
                if (n % i == 0) return false;

            return true;
        }
    }
}
