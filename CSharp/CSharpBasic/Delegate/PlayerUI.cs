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
            //player.OnHpChanged += Refresh; // Refresh 라는 함수를 OnHpChanged 대리자에 구독
            player.OnHpChanged += (hp) =>
            {
                HpText = hp.ToString();
            };
            // 람다식 익명메소드 
            player.OnHpMin += () =>
            {
                Refresh(0);
            };
            //player.OnHpChanged -= Refresh; // 구독취소
            Refresh(player.Hp);

            //익명 대리자
            //delegate (int a, int b)
            //{
            //    return a + b;
            //};
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
