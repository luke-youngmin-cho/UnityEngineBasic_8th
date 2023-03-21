using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    internal struct SwordMan
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
