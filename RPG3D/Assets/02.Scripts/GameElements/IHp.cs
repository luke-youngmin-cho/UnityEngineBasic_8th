using RPG.FSM;
using System;
using UnityEngine;

namespace RPG.GameElements
{
    public interface IHp
    {
        float hp { get; set; }
        float hpMax { get; }
        float hpMin { get; }

        event Action<float> onHpChanged; // 변경된 값
        event Action<float> onHpRecovered; // 회복된 양
        event Action<float> onHpDepleted; // 감소된 양
        event Action onHpMax;
        event Action onHpMin;


        void RecoverHp(MachineManager characterMachine, float amount);
        void DepleteHp(MachineManager characterMachine, float amount);
    }
}