using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace class_mark
{
    [Serializable]
    class Mark
    {
        public int points;

        public virtual string getLetter()
        {

            if (95 <= points) return "A";
            if (90 <= points) return "A-";
            if (85 <= points) return "B+";
            if (80 <= points) return "B";
            if (75 <= points) return "B-";
            if (70 <= points) return "C+";
            if (65 <= points) return "C";
            if (60 <= points) return "C-";
            if (55 <= points) return "D+";
            if (50 <= points) return "D";
            else return "F";
        }

        public override string ToString()
        {
            return getLetter();
        }
    }

    class Program
    {
        public static void Serialize(List<Mark> marks)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("mark.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, marks);
                Console.WriteLine("Object serialized");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public static List<Mark> Deserialize()
        {
            FileStream fs = null;
            List<Mark> marks = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fs = new FileStream("mark.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                marks = formatter.Deserialize(fs) as List<Mark>;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return marks;
        }


        static void Main(string[] args)
        {
            List<Mark> marks = new List<Mark>
            {
                new Mark
                {
                    points=95
                },
                new Mark
                {
                    points=100
                },
                new Mark
                {
                    points=73
                },
                new Mark
                {
                    points=99
                }
            };
            Serialize(marks);
            List<Mark> dmarks = Deserialize();

            foreach (var item in dmarks)
            {
               // string res = item + " - " + item.points;
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
