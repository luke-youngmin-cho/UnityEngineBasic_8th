using Collections;
using System.Collections;
using System.Collections.Generic;

bool Match(int x)
{
    return x > 4;
}
#region Dynamic Array
MyDynamicArray myDynamicArray = new MyDynamicArray();
myDynamicArray.Add(5);
myDynamicArray.Add(3);
myDynamicArray.Add(9);
myDynamicArray.Add(7);
myDynamicArray.Add("철수");
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
Object obj2 = (Object)1;

MyDynamicArray<Dummy> dummies = new MyDynamicArray<Dummy>();
MyDynamicArray<float> floats = new MyDynamicArray<float>();

ArrayList arrayList = new ArrayList();
arrayList.Add(3);
arrayList.Add("철수");
arrayList.Contains(3);

List<Dummy> list = new List<Dummy>();
list.Add(new Dummy());
list.Find(dummy => dummy.x < 0);

#endregion


class Dummy : IComparable<Dummy>
{
    public int x, y, z;
    public int CompareTo(Dummy? other)
    {
        // 삼항연산자 어떤조건 ? 조건이참일때값 : 조건이거짓일때값
        return (other != null) && (x == other.x) && (y == other.y) && (z == other.z) ? 0 : -1;

        if (other == null)
            return -1;

        if (x == other.x &&
            y == other.y &&
            z == other.z)
            return 0;
        else
            return -1;
    }
}
