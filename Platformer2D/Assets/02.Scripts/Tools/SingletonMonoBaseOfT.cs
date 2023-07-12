using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBase<T> : MonoBehaviour
    where T : SingletonMonoBase<T>
{
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(nameof(T)).AddComponent<T>();
            }
            return _instance;
        }
    }
    private static T _instance;
}
