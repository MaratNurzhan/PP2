using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake2
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Start();           
        }
    }
}
