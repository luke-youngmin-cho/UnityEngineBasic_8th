using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Knight : Character
    {
        public Knight(int hp, int attackPower)
            : base(hp, attackPower) { }

        public override void SayHi()
        {
            base.SayHi();
        }

        protected override void Breath()
        {
            Console.WriteLine("Knight 이(가) 숨을쉰다.");
        }
    }
}
