using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Singletons
{
    public class SingletonBase<T>
        where T : SingletonBase<T>
    {
        public T instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Activator.CreateInstance<T>();
                    _instance.Init();
                }
                return _instance;
            }
        }
        private T _instance;

        protected virtual void Init() { }
    }
}