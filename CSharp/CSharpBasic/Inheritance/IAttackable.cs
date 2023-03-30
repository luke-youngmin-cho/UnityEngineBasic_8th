using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal interface IAttackable
    {
        int AttackPower { get; }
        void Attack(IDamageable target);
    }
}
