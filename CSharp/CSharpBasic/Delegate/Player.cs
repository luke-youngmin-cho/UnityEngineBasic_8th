using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Player
    {
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                if (_hp == value)
                    return;

                _hp = value;
                //OnHpChanged(value);
                //OnHpChanged.Invoke(value); // Invoke 는 대리자에 등록된 함수들의 RaceCondition 을 방지하기위해 사용하는함수
                OnHpChanged?.Invoke(value); // null check : ?.Invoke 대리자에 등록된 함수가 없을경우 호출하지 않는구문
            }
        }
        private int _hp;
        private int _hpMax = 100;
        public delegate void HpChangedHandler(int hp);
        public HpChangedHandler OnHpChanged;
        private PlayerUI _playerUI;

        public Player()
        {
            Hp = _hpMax;
        }
    }
}
