using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    public abstract class ItemData : ScriptableObject
    {
        public int id;
        public int numMax;
        public Sprite icon;
        public string description;
    }
}