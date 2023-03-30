using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Goblin : Monster, IAttackable
    {
        public int AttackPower
        {
            get
            {
                return _attackPower;
            }
        }
        private int _attackPower;

        public void Attack(IDamageable target)
        {
            target.Damage(_attackPower);
        }

        protected override void Breath()
        {
            Console.WriteLine("Goblin 이(가) 숨을쉰다.");
        }
    }
}
