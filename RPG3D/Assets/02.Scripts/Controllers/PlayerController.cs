using RPG.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Controllers
{
    public class PlayerController : ControllerBase
    {
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