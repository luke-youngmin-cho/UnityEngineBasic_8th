using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectInstance
{
    internal class Human
    {
        public string Name;
        public int Age;
        public float Height;
        public double Weight;
        public bool IsAvailable;

        public void PrintInfo()
        {
            Console.WriteLine($"{Name}, {Age}, {Height}, {Weight}, {IsAvailable}");
        }
    }
}
