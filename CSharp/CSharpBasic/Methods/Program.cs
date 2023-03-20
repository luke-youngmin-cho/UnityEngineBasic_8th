// 함수
// 
// 함수 정의 형태
//
// 반환값타입 함수이름(매개변수1타입 매개변수1이름, 매개변수2타입 매개변수2이름, ...)
// {
//      연산내용
//      return 반환값;
// }

int Sum(int a, int b)
{
    // 지역변수
    // 함수 내에서 선언되고 해당 함수 내에서만 접근이 가능 ( 벗어나면 메모리 해제되는 변수 )
    // 매개변수 ⊂ 지역변수
    int result = a + b;
    PrintInt(result);
    return result;
}

// void 
// 반환 타입이 없을때 사용
void PrintHi()
{
    Console.WriteLine("Hi");
    //return;
}

void PrintInt(int value)
{
    Console.WriteLine(value);
    return;
}

#region Main

// 함수 호출 형태
// 함수이름(인자1, 인자2 ...);
int result = Sum(1, 2);
Console.WriteLine(result);
Sum(3, 3);


#endregion