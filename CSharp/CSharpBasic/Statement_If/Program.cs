//if (조건1)
//{
//    조건1이 참일 때 실행할 내용
//}
//else if (조건2)
//{
//    조건1이 거짓이고 조건2가 참일 때 실행할 내용
//}
//else
//{
//    상위 조건들이 모두 거짓일 때 실행할 내용
//}

bool condition1 = false;
bool condition2 = false;

if (condition1)
{
    Console.WriteLine("조건 1이 참");
}
else if (condition2)
{
    Console.WriteLine("조건 1이 거짓이고 조건 2가 참");
}
else
{
    Console.WriteLine("조건1과 조건2가 거짓");
}