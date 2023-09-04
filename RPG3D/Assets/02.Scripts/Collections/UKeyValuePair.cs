using System;

[Serializable]
public struct UKeyValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public UKeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}
