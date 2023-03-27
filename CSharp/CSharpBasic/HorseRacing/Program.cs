// 진행 방식
//
// 말 클래스 필요
// 말 클래스는 달린거리, 이동하기(달리기) 라는 함수를 가집니다. 
//
// 프로그램 시작시 
// 말 다섯마리를 만들고 
// 각 말의 이름은 "경주마i" (i : 1 ~ 5) 로 해줍니다.
// 각 말은 초당 10.0 ~ 20.0 범위의 거리를 랜덤하게 전진.
// 각각의 말은 200.0 거리에 도달하면 도착으로 간주하고 더이상 전진하지 않고,
// 매 초마다 모든 말들의 상태 (도착했다면 "도착함", 달리고있다면 현재 달린 누적 거리) 를 출력 해줍니다.
// 모든 말들이 도착했다면 경주를 끝내고 등수 순서대로 말들의 이름을 콘솔창에 출력 해줍니다.

using HorseRacing;
using System;
using System.Threading;

Random _random;
double _speedMin = 10.0;
double _speedMax = 20.0;
double _posGoal = 200.0;
bool _isGameFinished = false;
int _currentGrade = 0;
int _sec = 0;
Horse[] _horsesArrived = new Horse[5];

// 말 다섯마리 생성 및 이름 멤버 변수 초기화
Horse[] horses = new Horse[5];
for (int i = 0; i < horses.Length; i++)
{
    horses[i] = new Horse();
    horses[i].Name = $"경주마{i + 1}";
}


// 말 달리는 루프
while (_isGameFinished == false)
{
    Console.WriteLine($"=========================== {_sec} 초 경과 ===========================");

    for (int i = 0; i < horses.Length; i++)
    {
        if (horses[i].IsFinished)
        {
            Console.WriteLine($"{horses[i]} 는 도착함");
        }
        else
        {
            _random = new Random();
            double deltaMovePerSec = (_random.NextDouble() + 1.0) * 10.0;
            horses[i].Move(deltaMovePerSec);

            if (horses[i].TotalDistance >= _posGoal)
            {
                horses[i].IsFinished = true;
                _horsesArrived[_currentGrade] = horses[i];
                _currentGrade++;
            }
            Console.WriteLine($"{horses[i].Name} 의 현재거리 : {horses[i].TotalDistance}");
        }
    }

    if (_currentGrade >= 5)
    {
        break; // _isGameFinished = true;
    }

    // 모든 말들을
    // if (말.isFinished)
    // {
    //      cw.(말.Name 도착함)
    // }
    // else
    // {
    //      랜덤하게 10.0~20.0 거리만큼 전진
    //_random = new Random();
    //double deltaMovePerSec = (_random.NextDouble() + 1.0 ) * 10.0;
    //      전진한 말의 누적거리가 200.0 이상이면 IsFinished = true.
    // }

    // if ( 모든 말들이 들어왔는지  (현재까지 들어온 말의 등수가 5등 인지 체크))
    //      break; or _isGameFinished = ture;

    Thread.Sleep(1000);
    _sec++;
}

Console.WriteLine("경기종료");
// 등수별로 말들.Name 출력
for (int i = 0; i < _horsesArrived.Length; i++)
{
    Console.WriteLine($"{i + 1} 등 : {_horsesArrived[i].Name}");
}