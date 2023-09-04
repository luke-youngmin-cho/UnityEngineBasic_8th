using RPG.Data;
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

        public MachineManager machineManager;
        public SkillID attackID;

        override protected void Awake()
        {
            base.Awake();
            machineManager = GetComponent<MachineManager>();
            stats = new Dictionary<StatType, Stat>();
            foreach (var statPair in _statList)
            {
                stats.Add(statPair.Key, new Stat(statPair.Key, statPair.Value));
            }
        }

        private void Start()
        {
            if (ControllerManager.instance.TryGet(out PlayerController playerController) &&
                ControllerManager.instance.TryGet(out VCam_FollowingPlayer playerFollowingCam))
            {
                playerController.controlEnabled = true;
                playerFollowingCam.controlEnabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void Update()
        {
            machineManager.horizontal = Input.GetAxis("Horizontal");
            machineManager.vertical = Input.GetAxis("Vertical");
            machineManager.moveGain = Input.GetKey(KeyCode.LeftShift) ? 6.0f : 2.0f;

            if (controlEnabled == false)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                machineManager.UseSkill(attackID.value);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (machineManager.isGrounded)
                {
                    if (machineManager.hasJumped == false)
                        machineManager.ChangeState(StateType.Jump);
                }
                else
                {
                    if (machineManager.hasSomersaulted == false)
                        machineManager.ChangeState(StateType.Somersault);
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