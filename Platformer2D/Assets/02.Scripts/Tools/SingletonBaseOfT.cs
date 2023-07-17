using System;
using System.Reflection; // 런타임중에 어셈블리 등의 코드에 접근하는용도 (메타데이터) 의 기능을 제공하는 네임스페이스

public class SingletonBase<T> 
    where T : SingletonBase<T>
{
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                //ConstructorInfo constructorInfo = typeof(T).GetConstructor(new Type[] { });
                //_instance = constructorInfo.Invoke(new object[] { }) as T;

                _instance = Activator.CreateInstance<T>();
            }
            
            return _instance;
        }
    }
    private static T _instance;
}