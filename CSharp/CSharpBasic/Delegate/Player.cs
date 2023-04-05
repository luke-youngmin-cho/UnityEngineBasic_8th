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
                //OnHpChanged.Invoke(value); 
                if (value <= _hpMin)
                    OnHpMin?.Invoke();
                else
                    OnHpChanged?.Invoke(value); // null check : ?.Invoke 대리자에 등록된 함수가 없을경우 호출하지 않는구문
            }
        }
        private int _hp;
        private int _hpMax = 100;
        private int _hpMin = 0;
        //public delegate void HpChangedHandler(int hp);
        //public event HpChangedHandler OnHpChanged; // event 한정자 : 대리자를 외부 클래스에서 직접 호출하거나 Invoke 할 수 없도록제한
        public event Action<int> OnHpChanged;
        public event Action OnHpMin;
        private PlayerUI _playerUI;

        // Generic
        public Action<int, int> action; // 반환 타입이 없고, 파라미터는 0개 ~ 16개 까지 정의되어있으므로 쓸 수 있다.
        public Func<int,float> func; // 반환 타입이 있고, "
        public Predicate<int> predicate; // 반환 타입이 bool, 파라미터는 1개 ~ 16개 까지 "

        public Player()
        {
            Hp = _hpMax;
        }
    }
}
