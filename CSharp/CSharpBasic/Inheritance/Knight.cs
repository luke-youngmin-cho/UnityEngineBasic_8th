using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Knight : Character
    {
        protected override void Breath()
        {
            Console.WriteLine("Knight 이(가) 숨을쉰다.");
        }
    }
}
