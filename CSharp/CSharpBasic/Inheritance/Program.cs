using Inheritance;

Knight knight = new Knight(200, 50);
Wizard wizard = new Wizard(150, 70);
Goblin goblin = new Goblin(100, 20);

// 공변성(Covariance)
// 하위타입을 기반타입으로 참조가 가능한 성질.
Creature[] creatures = new Creature[2];
creatures[0] = knight;
creatures[1] = goblin;

for (int i = 0; i < creatures.Length; i++)
{
    Console.WriteLine(creatures[i].Lv);
}


knight.Attack(goblin);

knight.SayHi();
wizard.SayHi();
Character character1 = knight;
Character character2 = wizard;
character1.SayHi();
character2.SayHi();

Knight[] knights = new Knight[100];
for (int i = 0; i < knights.Length; i++)
{
    knights[i] = new Knight(100, 50);
}

Wizard[] wizards = new Wizard[100];
for (int i = 0; i < wizards.Length; i++)
{
    wizards[i] = new Wizard(80, 60);
}

SwordMan[] swordMen = new SwordMan[100];
for (int i = 0; i < swordMen.Length; i++)
{
    swordMen[i] = new SwordMan(80, 70);
}


for (int i = 0; i < knights.Length; i++)
{
    knights[i].Attack(goblin);
}

for (int i = 0; i < wizards.Length; i++)
{
    wizards[i].Attack(goblin);
}

for (int i = 0; i < swordMen.Length; i++)
{
    swordMen[i].Attack(goblin);
}


Character[] characters = new Character[300];
Array.Copy(knights, characters, 100);
Array.Copy(wizards, characters, 100);
Array.Copy(swordMen, characters, 100);

for (int i = 0; i < characters.Length; i++)
{
    characters[i].Attack(goblin);
}