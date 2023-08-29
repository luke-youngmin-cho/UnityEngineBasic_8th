using RPG.FSM;
using RPG.GameElements.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Controllers
{
    public class PlayerController : ControllerBase
    {
        [SerializeField] private List<UKeyValuePair<StatType, float>> _statList;
        public Dictionary<StatType, Stat> stats;

        private MachineManager _machineManager;

        override protected void Awake()
        {
            base.Awake();
            _machineManager = GetComponent<MachineManager>();
            stats = new Dictionary<StatType, Stat>();
            foreach (var statPair in _statList)
            {
                stats.Add(statPair.Key, new Stat(statPair.Key, statPair.Value));
            }
        }

        private void Update()
        {
            _machineManager.horizontal = Input.GetAxis("Horizontal");
            _machineManager.vertical = Input.GetAxis("Vertical");
            _machineManager.moveGain = Input.GetKey(KeyCode.LeftShift) ? 6.0f : 2.0f;

            if (Input.GetMouseButtonDown(0))
            {
                _machineManager.ChangeState(StateType.Attack);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_machineManager.isGrounded)
                {
                    if (_machineManager.hasJumped == false)
                        _machineManager.ChangeState(StateType.Jump);
                }
                else
                {
                    if (_machineManager.hasSomersaulted == false)
                        _machineManager.ChangeState(StateType.Somersault);
                }
            }
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