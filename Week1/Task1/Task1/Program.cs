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
            //convert the input data into int type to place it into int variable n
            int n = int.Parse(Console.ReadLine());
            // string str = Console.ReadLine();
            //string[] arr = str.Split();
            //Split the string according to the condition in commas of "Split()", if it is empty
            //devide by gaps
            //Save it into array od strings
             string[] arr = Console.ReadLine().Split();
           
           //allocate memeory for array arr1 of length n
            int[] arr1 = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                //Convert every arr[i] element into int type because arr is array of strings
                //Running through every arr[i] element put them in variable n1
                //as here are several elements we must put every n1 into arr1 array while for(cycle)is implemented
                
                
                int n1 = int.Parse(arr[i]);
                arr1[i] = n1;
            }
            //variable counter
            int cnt = 0;
            //Create list to save all prime numbers in it
            //The amount of prime numbers is unknown,that is why I use List(its size change dynamically)
            List<int> list = new List<int>();
            for(int i=0; i<arr1.Length; i++)
            {
                //Call function "isPrime" for each element of array
                if (isPrime(arr1[i]))
                {
                   //If arr[i] satisfies condition of "isPrime" counter "cnt" will be incremented 
                    cnt++;
                    //And it wil be added to List "list"
                    list.Add(arr1[i]);
                }
            }
            //Output amiunt of primes to console
            Console.WriteLine(cnt);
            //Output content of "list" to console
            foreach (int item in list)
                Console.Write(item + " ");
            //Write command to enter a symbol to prevent closing of the console
            Console.ReadKey();
        }
        //I make function is prime that returns true or false
        //depending on whether obtained n is prime or not
        static bool isPrime(int n)
        {
            //Negative numbers are not considered as prime
            if (n <= 0) return false;
            if (n == 1) return false;
            if (n == 2) return true;
            //Number is prime if it is nit divisible by any number less than its square root
            //In case n==1 or n==2 we write condition separately, because 
            //cycle will run from 2 to 1 or from 2 to 2( 2 is divisible by 2 => false, but the right answer should be true)
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(n)); i++)
                if (n % i == 0) return false;
            //If the number passes the test(not divisible), return true 
            return true;
        }
    }
}
