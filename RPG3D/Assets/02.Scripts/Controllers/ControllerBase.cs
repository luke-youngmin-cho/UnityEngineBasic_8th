using UnityEngine;

namespace RPG.Controllers
{
    public abstract class ControllerBase : MonoBehaviour, IControllable
    {
        public virtual bool controlEnabled { get; set; }

        protected virtual void Awake()
        {
            ControllerManager.instance.Register(this);
        }
    }
}