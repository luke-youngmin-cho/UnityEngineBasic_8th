using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    // 구조체 
    // 사용자 정의 자료형
    public struct Stats
    {
        // 멤버 변수들
        public int STR;
        public int DEX;
        public int INT;
        public int LUK;

        // 멤버 함수들 
        public int GetCombotPower()
        {
            return STR + DEX + INT + LUK;
        }
    }
}
