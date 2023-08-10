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

        public void Initialize(MachineManager manager)
        {
            this.manager = manager;
            transform = manager.transform;
            rigidbody = manager.GetComponent<Rigidbody>();
        }

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            base.OnStateMachineEnter(animator, stateMachinePathHash);

            animator.SetBool("isDirty", false);
        }
    }
}