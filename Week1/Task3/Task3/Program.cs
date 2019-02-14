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
            //initialize new array "arr2" whose size is doubled

            int[] arr2 = new int[2*arr1.Length];
           
            //variable for indexes in arr2
                int j = 0;
                for (int i = 0; i < arr1.Length; i++)
                    {
                        //initially j is 0, so first element arr1[i] in arr2[j]
                        //arr2[0]=arr1[0]
                
                        arr2[j] = arr1[i];
                        //increment j to put the same value in next arr2[1]
                        //arr2[0]=arr1[0]
                        j++;
                        arr2[j] = arr1[i];
                        //increment j to put in arr2[3] this time another element arr1[1]
                        j++;
                    }
                //output arr2
                foreach (var el in arr2)
                    { 
                        Console.Write(el + " ");
                    }
           
            Console.ReadKey();
        }
    }
}
