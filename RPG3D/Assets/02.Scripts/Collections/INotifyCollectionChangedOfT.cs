using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Collections
{
    public interface INotifyCollectionChanged<T>
    {
        event Action<int, T> onItemChanged;
        event Action<int, T> onItemAdded;
        event Action<int, T> onItemRemoved;
        event Action onCollectionChanged;
    }
}