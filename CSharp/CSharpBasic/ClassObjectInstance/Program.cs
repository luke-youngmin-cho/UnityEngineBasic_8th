using ClassObjectInstance;

// new 키워드 
// 동적할당키워드 

SwordMan swordMan1 = new SwordMan();
SwordMan swordMan2 = new SwordMan();
int a = 3;


// . 멤버접근연산자
swordMan1.Name = "타락파워전사짱짱";
swordMan1.Lv = 1;

swordMan2.Name = "똠양꿍";
swordMan2.Lv = 2;

swordMan1.Slash();
swordMan2.Slash();

