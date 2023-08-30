
using RPG.Singletons;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    public class SkillDataRepository : SingletonMonoBase<SkillDataRepository>
    {
        public SkillData this[int skillID] => skillDatum[skillID];
        public Dictionary<int, SkillData> skillDatum;
        public Dictionary<int, ActiveSkillData> activeSkillDatum;
        public Dictionary<int, PassiveSkillData> passiveSkillDatum;
        [SerializeField] private List<ActiveSkillData> _activeSkillDatum;
        [SerializeField] private List<PassiveSkillData> _passiveSkillDatum;

        private void Awake()
        {
            skillDatum = new Dictionary<int, SkillData>();
            activeSkillDatum = new Dictionary<int, ActiveSkillData>();
            passiveSkillDatum = new Dictionary<int, PassiveSkillData>();

            foreach (var item in _activeSkillDatum)
            {
                activeSkillDatum.Add(item.id.value, item);
                skillDatum.Add(item.id.value, item);
            }

            foreach (var item in _passiveSkillDatum)
            {
                passiveSkillDatum.Add(item.id.value, item);
                skillDatum.Add(item.id.value, item);
            }
        }
    }
}