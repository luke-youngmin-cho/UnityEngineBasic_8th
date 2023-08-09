using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Controllers
{
    public class PlayerController : ControllerBase
    {
        public bool isGrounded => Physics.Raycast(transform.position + Vector3.up,
                                                  Vector3.down,
                                                  out RaycastHit hit,
                                                  _groundCastMaxDistance + 1.0f,
                                                  _groundMask);
        private Animator _animator;
        private Vector2 _move;
        private float _moveGain;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCastMaxDistance;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _move = new Vector2(horizontal, vertical).normalized;
            _moveGain = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
            _animator.SetFloat("horizontal", horizontal * _moveGain);
            _animator.SetFloat("vertical", vertical * _moveGain);
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.F) &&
                ((1 << other.gameObject.layer) & (1 << LayerMask.NameToLayer("ItemDropped"))) > 0)
            {
                if (other.TryGetComponent(out ItemDropped itemDropped))
                {
                    itemDropped.PickUp();
                }
            }
        }
    }
}