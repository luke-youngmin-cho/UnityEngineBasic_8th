using Inheritance;

Knight knight = new Knight();
Goblin goblin = new Goblin();

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