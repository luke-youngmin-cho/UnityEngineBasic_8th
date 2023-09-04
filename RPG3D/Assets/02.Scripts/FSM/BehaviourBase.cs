using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.FSM
{
    public class BehaviourBase : StateMachineBehaviour
    {
        protected MachineManager manager;
        protected Transform transform;
        protected Rigidbody rigidbody;

        public virtual void Initialize(MachineManager manager)
        {
            this.manager = manager;
            transform = manager.transform;
            rigidbody = manager.GetComponent<Rigidbody>();
        }

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            base.OnStateMachineEnter(animator, stateMachinePathHash);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            animator.SetBool("isDirty" + layerIndex, false);
            manager.onUpdate = () => OnUpdate(animator, layerIndex);
        }

        public virtual void OnUpdate(Animator animator, int layerIndex)
        {

        }
    }
}