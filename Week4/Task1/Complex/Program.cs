using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Complex
{
    [Serializable]
    class Complex
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex = new Complex();
            FileStream fs = null;
            BinaryFormatter bn = new BinaryFormatter();
            using (fs = new FileStream("complex.txt", FileMode.OpenOrCreate))
            {
                bn.Serialize(fs, complex);
            }

            using(fs=new FileStream("complex.txt", FileMode.OpenOrCreate))
            {
                complex = bn.Deserialize(fs) as Complex;
            }

        }
    }
}
