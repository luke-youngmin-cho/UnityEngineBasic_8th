using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Slime : Monster
    {
        // override 키워드 : 재정의 키워드 
        // 추상멤버를 다시 정의하고 싶을 때 쓰는 키워드. 
        protected override void Breath()
        {
            Console.WriteLine("Slime 이(가) 숨을쉰다.");
        }
    }
}
