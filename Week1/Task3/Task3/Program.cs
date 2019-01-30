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
            //Convert the input string into int and place in variable n
            int n = int.Parse(Console.ReadLine());
            //string str=Console.ReadLine();
            //string[] arr=str.Split();

            string[] arr = Console.ReadLine().Split();
            int[] arr1 = new int[n];
            for(int i=0; i<arr.Length; i++)
            {
                //Every element of arr is of type string
                //Convert into int using "int.Parse"
                //Converted elements of arr place into int arr1
                int n1 = int.Parse(arr[i]);
                arr1[i] = n1;
            }
            //using foreach cycle we output every element el twice 
            foreach(var el in arr1)
            {
                //using "Write" not to move to the next line(new array will output in one line)
                Console.Write($"{el} {el} ");
            }
            Console.ReadKey();
        }
    }
}
