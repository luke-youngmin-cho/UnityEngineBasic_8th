using Delegate;
using System.Threading.Tasks;

Player player = new Player();
PlayerUI playerUI = new PlayerUI(player);


// Game Logic 
while (true)
{
    player.Hp -= 1;
    playerUI.Draw();
    Thread.Sleep(1000);
}