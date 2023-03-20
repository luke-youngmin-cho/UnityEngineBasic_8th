using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectInstance
{
    // 클래스 
    // 캡슐화하기위한 사용자정의 자료형
    internal class SwordMan
    {
        // 멤버 변수들
        string _name;
        int _lv;
        float _exp;
        char _gender;

        // 멤버 함수들
        void Slash()
        {
            Console.WriteLine($"{_name} 이(가) 베기를 시전했다");
        }
    }
}
