using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class SwordMan : Character
    {
        public SwordMan(int hp, int attackPower)
            :base(hp, attackPower) { }

        public override void SayHi()
        {
            base.SayHi();
        }

        protected override void Breath()
        {
            Console.WriteLine("SwordMan 이(가) 숨을쉰다");
        }
    }
}
