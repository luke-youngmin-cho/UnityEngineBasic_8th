using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    public abstract class SkillData : ScriptableObject
    {
        public SkillID id;
        public string description;
        public Sprite icon;
    }
}