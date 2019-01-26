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

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetID()
        {
            return id;
        }

        public void SetID(string id)
        {
            this.id = id;
        }
        //C
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
