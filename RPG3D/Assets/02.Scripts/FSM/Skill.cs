using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.FSM
{
    public class Skill : BehaviourBase
    {
        public SkillID skillID;
        protected ActiveSkillData data;
        [SerializeField] private bool _hasExitTime;
        [SerializeField] private StateType _destination;
        private int _comboStack;
        private int _comboStackAnimHashID;
        private bool _isCorouting;
        private Coroutine _coroutine;

        public override void Initialize(MachineManager manager)
        {
            base.Initialize(manager);
            _comboStackAnimHashID = Animator.StringToHash("comboStack");
            data = SkillDataRepository.instance.activeSkillDatum[skillID.value];
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            if (_isCorouting)
            {
                manager.StopCoroutine(_coroutine);
                _isCorouting = false;
            }

            _comboStack = _comboStack < data.comboStackMax ? _comboStack + 1 : 0;
            animator.SetInteger(_comboStackAnimHashID, _comboStack);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            //Debug.Log($"update ... {stateInfo.normalizedTime}");

            if (stateInfo.normalizedTime >= data.comboDelayRatioList[_comboStack])
            {
                // todo -> 콤보 연계 가능하도록 
            }

            if (_hasExitTime &&
                stateInfo.normalizedTime >= 1.0f)
            {
                manager.ChangeState(_destination);
            }
        }

    }
}