using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpAssets : SingletonMonoBase<DamagePopUpAssets>
{
    public DamagePopUp this[LayerMask layer]
    {
        get
        {
            return _dictionary[layer];
        }
        set
        {
            _dictionary[layer] = value;
        }
    }

    [Serializable]
    public struct DamagePopUpPair
    {
        public LayerMask layer;
        public DamagePopUp damagePopUp;
    }
    [SerializeField] private List<DamagePopUpPair> damagePopUpPairs;
    private Dictionary<LayerMask, DamagePopUp> _dictionary;

    private void Awake()
    {
        _dictionary = new Dictionary<LayerMask, DamagePopUp>();
        foreach (var item in damagePopUpPairs)
        {
            _dictionary.Add(item.layer, item.damagePopUp);
        }
    }
}
