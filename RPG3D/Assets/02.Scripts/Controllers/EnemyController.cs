using RPG.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Controllers
{
    public class EnemyController : ControllerBase
    {
        private NavMeshAgent _agent;
        public Transform target;
        private MachineManager _machineManager;

        protected override void Awake()
        {
            base.Awake();
            _agent = GetComponent<NavMeshAgent>();
            _machineManager = GetComponent<MachineManager>();
        }

        private void Update()
        {
            _agent.destination = target.position;
        }
    }
}