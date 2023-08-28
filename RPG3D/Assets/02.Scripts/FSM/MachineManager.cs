using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.FSM
{
    public enum StateType
    {
        Idle,
        Move,
        Jump,
        Fall,
        Land,
        Somersault,
        Attack = 20,
    }


    [RequireComponent(typeof(Animator))]
    public class MachineManager : MonoBehaviour
    {
        public bool isGrounded => Physics.Raycast(transform.position + Vector3.up,
                                                  Vector3.down,
                                                  out RaycastHit hit,
                                                  _groundCastMaxDistance + 1.0f,
                                                  _groundMask);

        public StateType state;
        public bool hasJumped;
        public bool hasSomersaulted;

        private Animator _animator;

        private int _stateAnimHashID;
        private int _isDirtyAnimHashID;

        public Vector3 move;
        public float moveGain;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCastMaxDistance;

        private Vector3 _inertia;
        private Rigidbody _rigidbody;

        public float horizontal;
        public float vertical;

        public bool ChangeState(Animator animator, StateType newState)
        {
            if (animator.GetInteger(_stateAnimHashID) == (int)newState)
                return false;

            animator.SetInteger(_stateAnimHashID, (int)newState);
            animator.SetBool(_isDirtyAnimHashID, true);
            return true;
        }

        public bool ChangeState(StateType newState)
        {
            if (_animator.GetInteger(_stateAnimHashID) == (int)newState)
                return false;

            _animator.SetInteger(_stateAnimHashID, (int)newState);
            _animator.SetBool(_isDirtyAnimHashID, true);
            return true;
        }

        protected virtual void Awake()
        {
            _stateAnimHashID = Animator.StringToHash("state");
            _isDirtyAnimHashID = Animator.StringToHash("isDirty");
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
            BehaviourBase[] behaviours = _animator.GetBehaviours<BehaviourBase>();

            for (int i = 0; i < behaviours.Length; i++)
            {
                behaviours[i].Initialize(this);
            }
        }

        protected virtual void Update()
        {
            move = Quaternion.LookRotation(transform.forward, transform.up) * new Vector3(horizontal, 0.0f, vertical).normalized;
            _animator.SetFloat("horizontal", Vector3.Dot(move * moveGain, transform.right));
            _animator.SetFloat("vertical", Vector3.Dot(move * moveGain, transform.forward));
        }

        private void FixedUpdate()
        {
            if (isGrounded)
            {
                _inertia = move * moveGain;
                transform.position += move * moveGain * Time.fixedDeltaTime;
            }
            else
            {
                transform.position += _inertia * Time.fixedDeltaTime;
                _inertia = Vector3.Lerp(_inertia, Vector3.zero, _rigidbody.drag);
            }
        }


        #region Animation event binded

        private void FootL() { }
        private void FootR() { }
        private void Land() { }

        private void Hit() { }
        #endregion

    }
}