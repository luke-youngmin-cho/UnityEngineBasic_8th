using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class PlayerUI
    {
        public string HpText;

        public PlayerUI(Player player)
        {
            player.OnHpChanged += Refresh; // Refresh 라는 함수를 OnHpChanged 대리자에 구독
            //player.OnHpChanged -= Refresh; // 구독취소
            Refresh(player.Hp);
        }

        public void Draw()
        {
            Console.WriteLine(HpText);
        }

        public void Refresh(int hp)
        {
            HpText = hp.ToString();
        }
    }
}
