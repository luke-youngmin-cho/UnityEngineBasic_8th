using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    // interface 는 default 접근제한자가 public 임.
    // 멤버들을 추상화하기위한 용도이므로 기본적으로 멤버들 선언만함
    internal interface IDamageable
    {
        int Hp { get; }
        void Damage(int value);
    }
}
