using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Resource : IDamageable
    {
        public int Hp
        {
            get
            {
                return hp;
            }
        }
        protected int hp;

        public void Damage(IAttackable attacker, int value)
        {
            if (hp - value < 0)
            {
                hp = 0;
                Console.WriteLine($"{attacker} 가 {this} 를 채집하는데 성공했습니다.");
            }
            else
            {
                hp -= value;
                Console.WriteLine($"{attacker} 가 {this} 를 채집중입니다... 남은 체력 : {hp}");
            }
        }
    }
}
