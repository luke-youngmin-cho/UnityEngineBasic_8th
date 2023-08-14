using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.FSM
{
    public class ComboStackingBehaviour : BehaviourBase
    {
        [SerializeField] private int _comboStackMax;
        private int _comboStack;
        private int _comboStackAnimHashID;
        private WaitForSeconds _waitForSeconds;
        private bool _isCorouting;
        private Coroutine _coroutine;

        public override void Initialize(MachineManager manager)
        {
            base.Initialize(manager);
            _comboStackAnimHashID = Animator.StringToHash("comboStack");
            _waitForSeconds = new WaitForSeconds(0.4f);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            if (_isCorouting)
            {
                manager.StopCoroutine(_coroutine);
                _isCorouting = false;
            }

            _comboStack = _comboStack < _comboStackMax ? _comboStack + 1 : 0;
            animator.SetInteger(_comboStackAnimHashID, _comboStack);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            Debug.Log($"update ... {stateInfo.normalizedTime}");
            if (stateInfo.normalizedTime >= 1.0f)
            {
                OnStateFinished(animator);
            }
        }

        public virtual void OnStateFinished(Animator animator)
        {
            if (_isCorouting)
                manager.StopCoroutine(_coroutine);

            _isCorouting = true;
            _coroutine = manager.StartCoroutine(C_ResetComboStack(animator));

            manager.ChangeState(StateType.Move);
        }

        IEnumerator C_ResetComboStack(Animator animator)
        {
            yield return _waitForSeconds;
            _comboStack = 0;
            animator.SetInteger(_comboStackAnimHashID, _comboStack);
            _isCorouting = false;
            _coroutine = null;
        }
    }
}