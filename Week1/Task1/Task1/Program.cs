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
            //Вводимые данные перевожу в тип int и помещяю в переменной n
            int n = int.Parse(Console.ReadLine());
            // string str = Console.ReadLine();
            //string[] arr = str.Split();
             string[] arr = Console.ReadLine().Split();
           
           //Выделяю память для нового массива arr1 длиной n
            int[] arr1 = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                //Пробегаясь по элементам массива передаем в переменную n1
                //в новый массив arr1 передаю элементы n1
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
                    //Добавляю в List простые числа
                    list.Add(arr1[i]);
                }
            }

            Console.WriteLine(cnt);
            foreach (int item in list)
                Console.Write(item + " ");

            Console.ReadKey();
        }
        //Создаю функцию isPrime, которая возвращает true или false 
        //в зависомости от получаемого значения в качестве аргумента n
        static bool isPrime(int n)
        {
            //Отрицательные значения не рассматриваются
            if (n <= 0) return false;
            //в случае полученя 1 или 2 мишем возвращаемый результат отдельно, так как 
            //цикл будет пробегаться от 2 до 1 или от 2 до 2(здесь 2 делится на 2, будет false, должно быть true)
            if (n == 1) return false;
            if (n == 2) return true;
            //Число Prime, если оно не делится на числа меньше квадратного корня данного числа
            for(int i = 2; i <= Math.Ceiling(Math.Sqrt(n)); i++)
                if (n % i == 0) return false;
            //Если число проходит проверку(не делится) то возвращаю true
            return true;
        }
    }
}
