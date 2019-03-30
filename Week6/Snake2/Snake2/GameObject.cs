using System;
using System.Collections.Generic;
namespace Snake2
{
    abstract public class GameObject
    {
        public char sign;
        public ConsoleColor color;
        public GameObject(char sign, ConsoleColor color)
        {
            this.sign = sign;
            this.color = color;
        }

        public GameObject()
        {

        }

        public abstract void Draw();        
    }
}

