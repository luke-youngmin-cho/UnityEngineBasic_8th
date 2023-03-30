using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Slime : Monster
    {
        protected override void Breath()
        {
            Console.WriteLine("Slime 이(가) 숨을쉰다.");
        }
    }
}
