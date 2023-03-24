// using 키워드 
// namespace 를가져다 쓰기위함

using ClassObjectInstance;


// new 키워드 
// 동적할당키워드 

SwordMan swordMan1 = new SwordMan();
SwordMan swordMan2 = new SwordMan();
int a = 3;


// . 멤버접근연산자
swordMan1.Name = "타락파워전사짱짱";
swordMan1.Lv = 1;
swordMan1.Exp = 1.0f;

swordMan2.Name = "똠양꿍";
swordMan2.Lv = 2;

swordMan1.Slash();
swordMan2.Slash();

ClassObjectInstance.SwordMan sw1 = new ClassObjectInstance.SwordMan();
ClassObjectInstance.UISystems.Characters.SwordMan nw2 = new ClassObjectInstance.UISystems.Characters.SwordMan();

Human human1 = new Human();
Human human2 = new Human();
Human human3 = new Human();

human1.Name = "김아무개";
human1.Age = 216;
human1.Height = 123.1f;
human1.Weight = 300.0;
human1.IsAvailable = false;

human2.Name = "이아무개";
human2.Age = 39;
human2.Height = 323.5f;
human2.Weight = 232.2;
human2.IsAvailable = true;

human3.Name = "최아무개";
human3.Age = 142;
human3.Height = 53.1f;
human3.Weight = 144.4;
human3.IsAvailable = true;

human1.PrintInfo();
human2.PrintInfo();
human3.PrintInfo();
