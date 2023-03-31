using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Wizard : Character
    {
        public Wizard(int hp, int attackPower)
            : base(hp, attackPower) { }

        public override void SayHi()
        {
            base.SayHi();
            Console.WriteLine("너는 뭐니?");
        }

        protected override void Breath()
        {
            Console.WriteLine("Wizard 이(가) 숨을쉰다.");
        }
    }
}
