using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statement_SwitchAndEnum
{
    // Attribute ?
    // 타입의 메타데이터를 정의하는 형태의 클래스 
    // 메타데이터 ? 데이터의 데이터 

    // Flags Attribute
    // 중복된 Flag들을 각 요소들에대한 문자열로 변환해주는 기능을 가지고 있는 Attribute
    [Flags]
    public enum LayerMask
    {
        None    = 0 << 0, // ... 00000000 == 0
        NPC     = 1 << 0, // ... 00000001 == 1
        Enemy   = 1 << 1, // ... 00000010 == 2
        Player  = 1 << 2, // ... 00000100 == 4
        Ground  = 1 << 3, // ... 00001000 == 8
        Wall    = 1 << 4, // ... 00010000 == 16
        //EnemyNPC = NPC | Enemy, // ... 00000011
    }

    public enum LayerMaskDummy
    {
        None,   // ... 00000000
        NPC,    // ... 00000001
        Enemy,  // ... 00000010
        Player, // ... 00000011
        Ground, // ... 00000100
        Wall,   // ... 00000101       
        //EnemyNPC = NPC | Enemy, // ... 00000011 == LayerMaskdummy.Player
    }
}
