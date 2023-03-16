// 변수 

// 변수 선언
// 자료형 변수이름
// 변수를 선언한다는 것 : 메모리상에 자료형 크기만큼의 공간을 할당함.
// 변수의 초기화 : 변수 선언 시 대입연산자로 초기화할 값을 대입해줌.
int a = 8; // 4byte 부호가 있는 정수형
short short1 = 1332; // 2byte 부호가 있는 정수형
long long1 = 1321; // 8byte 부호가 있는 정수형
uint uint1 = 1; // unsigned int 4byte 부호가 없는 정수형
float hight = 22.4f; // 4byte 실수형
double weight = 42.1; // 8byte 실수형
char gender = 'A'; // 65 = 2^6 * 1 + 2^0 * 1, 2byte 문자형 (아스키코드표에 따라 정수형으로 계산함)
string name = "Luke"; // 문자열형, 문자 하나당 2byte + 마지막에 null 문자(1byte).
                      // null 문자 붙는 이유 : C 계통 언어는 문자열 끝을 인식할때 null 문자로 판단한다.
bool isActivated =  true; // 1byte 논리형. true 또는 false 값을 쓰는 자료형. 
                          // true : 0 이 아닌 값 , false : 0 
