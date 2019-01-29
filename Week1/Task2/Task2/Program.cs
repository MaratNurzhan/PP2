using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        string name;
        string id;
        int yearOfStudy;

        public Student(string name, int yearOfStudy)
        {
            this.name = name;
            this.yearOfStudy = yearOfStudy;
        }
        //Свойство, которое возвращает name
        public string GetName()
        {
            return name;
        }
        //Свойство, которое позволяет задать значение
        public void SetName(string name)
        {
            this.name = name;
        }
       //Свойство возвращает ID
        public string GetID()
        {
            return id;
        }
        //Свойство позволяет задать значение ID
        public void SetID(string id)
        {
            this.id = id;
        }
        //Свойство увеличивает на один год обучения
        public void IncrementYearOfStudy()
        {
            yearOfStudy++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
