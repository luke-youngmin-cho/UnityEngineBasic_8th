using System;

[Serializable]
public struct UKeyValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;
}
