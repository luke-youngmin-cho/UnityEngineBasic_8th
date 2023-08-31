using RPG.Controllers;
using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
    public class StatusUI : UIMonoBehaviour
    {
        [SerializeField] private SkillID _attackSkillID;
        [SerializeField] private Image _attackCoolTimeFill;

        protected override void Update()
        {
            base.Update();

            if (ControllerManager.instance.TryGet(out PlayerController player))
            {
                _attackCoolTimeFill.fillAmount
                    = player.machineManager.skillCoolTimers[_attackSkillID.value] 
                    / SkillDataRepository.instance.activeSkillDatum[_attackSkillID.value].coolTime;
            }
        }
    }
}