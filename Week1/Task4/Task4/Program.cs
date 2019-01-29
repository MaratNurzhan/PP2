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
            int n = int.Parse(Console.ReadLine());
            //2d массив
            string[,] arr = new string[n,n];

            for(int i=0; i < n; i++)
            {
                //С каждым i-ым рядом массива количество в ряду элементов увеличивается на один
                for(int j=0; j<i+1; j++)
                {
                    //Записываю строку в элементы массива
                    arr[i, j] ="[*]";
                }
               
            }
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                //После каждого i-го ряда массивы выводятся с новой строки
                Console.WriteLine();
            }
           
            Console.ReadKey();
        }
    }
}
