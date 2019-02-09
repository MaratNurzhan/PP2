using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        //modifier is private by default(if not written)
        string name;
        string id;
        int yearOfStudy;
        //Constructor to give values for name and yearOfStudy
        public Student(string name, int yearOfStudy)
        {
            //name/yearOfStudy are values that we put in this.name/this.yearOfStudy
            //"this." is used to show to what we refer(value entered by user or memeory area) 
            this.name = name;
            this.yearOfStudy = yearOfStudy;
        }
        //Property that allow to get "name" of type string 
        //It does not set "name"
        public string GetName()
        {
            return name;
        }
        //Property that does not return anything(void type), and gets "name" (as argument)
        //We can set value for this.name
        public void SetName(string name)
        {
            this.name = name;
        }
       //Property that returns ID
        public string GetID()
        {
            return id;
        }
        //Property that set value for ID
        public void SetID(string id)
        {
            this.id = id;
        }
        //Property that neither set or get value
        //Property increments the year of study
        public void IncrementYearOfStudy()
        {
            yearOfStudy++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Nurzhan", 2);
           
            Console.WriteLine( student1.GetName());
            Console.ReadKey();
        }
    }
}
