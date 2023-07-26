using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data 
{
    public abstract class UsableItemData : ItemData
    {
        public abstract void Use();
    }
}