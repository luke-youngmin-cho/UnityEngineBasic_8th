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
                T resource = Resources.Load<T>(typeof(T).Name);

                if (resource)
                {
                    _instance = Instantiate(resource);
                }
                else
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }

            }
            return _instance;
        }
    }
    private static T _instance;
}
