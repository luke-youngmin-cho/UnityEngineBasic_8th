using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal abstract class Monster : Creature, IDamageable
    {
        public int Hp
        {
            get
            {
                return hp;
            }
        }
        protected int hp;

        public Monster()
        {

        }

        public Monster(int hp)
        {
            this.hp = hp;
        }

        public void Damage(IAttackable attacker, int value)
        {
            if (hp - value < 0)
            {
                hp = 0;
                Console.WriteLine($"{attacker} 가 {this} 를 사망하게 하였습니다.");
            }
            else
            {
                hp -= value;
                Console.WriteLine($"{attacker} 가 {this} 에게 데미지 {value} 를 가했습니다. {this} 의 현재 체력 : {hp}");
            }
        }
    }
}
