using RPG.Data;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    [CreateAssetMenu(fileName = "new PassiveSkillData", menuName = "RPG/Data/Create PassiveSkillData")]
    public class PassiveSkillData : SkillData
    {
        public List<StatModifier> statModifiers;
    }
}