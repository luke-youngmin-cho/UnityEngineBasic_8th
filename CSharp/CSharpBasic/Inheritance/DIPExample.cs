using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class SwordAssets
    {
        public static Sword GetSword(int lv)
        {
            return ????
        }
    }

    internal class Warrior
    {
        public int Lv
        {
            get => _lv;
            set
            {
                _lv = value;
                _sword = SwordAssets.GetSword(value);
            }
        }
        private int _lv;
        private Sword _sword;
        void SwordActiveSkill()
        {
            _sword.ActiveSkill();
        }
    }

    interface Sword
    {
        void ActiveSkill();
    }

    interface SwordLow : Sword
    {
    }

    interface SwordProper : Sword
    {
    }

    interface SwordHigh : Sword
    {
    }

    interface SwordLegend : Sword
    {
    }
}
