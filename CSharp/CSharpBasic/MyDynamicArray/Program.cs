using Collections;

bool Match(int x)
{
    return x > 4;
}

MyDynamicArray myDynamicArray = new MyDynamicArray();
myDynamicArray.Add(5);
myDynamicArray.Add(3);
myDynamicArray.Add(9);
myDynamicArray.Add(7);
int tmpIndex = myDynamicArray.FindIndex(7);
if (myDynamicArray.Remove(tmpIndex))
{
    Console.WriteLine($"{tmpIndex} index of myDynamicArray has removed");
}
myDynamicArray.RemoveAt(tmpIndex);

for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.WriteLine(myDynamicArray[i]);
}

int tmpValue = (int)myDynamicArray.Find(x => (int)x > 4); //myDynamicArray.Find(Match);

// object : C# 모든 타입의 기반 타입. 
object obj = (object)1; // boxing : (object 타입 변환, 힙 영역에 object 타입 객체를 만들고 값을 할당)
obj = "안녕";
tmpValue = (int)obj; // unboxing : (object 객체의 데이터를 내가 원하는 자료형으로 형변환 하는것)