using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    [CreateAssetMenu(fileName = "new ActiveSkillData", menuName = "RPG/Data/Create ActiveSkillData")]
    public class ActiveSkillData : SkillData
    {
        public float coolTime;
        public int comboStackMax;
        public List<float> comboDelayRatioList;

        [Header("Target Casting")]
        public int castTargetMax;
        public Vector3 castCenter;
        public float castHeight;
        public float castRadius;
        public Vector3 castDirection;
        public float castDistance;
    }
}